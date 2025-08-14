using ProjectPersonas.Application.DTOs;
using ProjectPersonas.Domain.Repositories;
using ProjectPersonas.Domain.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPersonas.Application.Services
{
    public class AuthService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly ITokenService _tokenService;
        private readonly IPasswordHasher _passwordHasher;
        public AuthService(IUsuarioRepository usuarioRepository, ITokenService tokenService, IPasswordHasher passwordHasher)
        {
            _usuarioRepository = usuarioRepository;
            _tokenService = tokenService;
            _passwordHasher = passwordHasher;
        }
        public async Task<AuthResultDto> RegisterAsync(RegisterDto registerDto)
        {
            if (string.IsNullOrWhiteSpace(registerDto.Username) || string.IsNullOrWhiteSpace(registerDto.Password))
            {
                throw new ArgumentException("Username and password cannot be empty.");
            }
            if (await _usuarioRepository.GetByUsernameAsync(registerDto.Username) != null)
            {
                throw new InvalidOperationException("Username already exists.");
            }
            _passwordHasher.CreateHash(registerDto.Password, out byte[] passwordHash, out byte[] passwordSalt);
            var usuario = new Domain.Entities.Usuario
            {
                Username = registerDto.Username,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt
            };
            await _usuarioRepository.AddAsync(usuario);
            var token = _tokenService.CreateToken(usuario);
            return new AuthResultDto(usuario.Username, token);
        }
        public async Task<AuthResultDto> LoginAsync(LoginDto loginDto)
        {
            if (string.IsNullOrWhiteSpace(loginDto.Username) || string.IsNullOrWhiteSpace(loginDto.Password))
            {
                throw new ArgumentException("Username and password cannot be empty.");
            }
            var usuario = await _usuarioRepository.GetByUsernameAsync(loginDto.Username);
            if (usuario == null || !usuario.Activo.HasValue || !usuario.Activo.Value)
            {
                throw new InvalidOperationException("Invalid username or account is inactive.");
            }
            if (!_passwordHasher.VerifyHash(loginDto.Password, usuario.PasswordHash, usuario.PasswordSalt))
            {
                throw new UnauthorizedAccessException("Invalid password.");
            }
            var token = _tokenService.CreateToken(usuario);
            return new AuthResultDto(usuario.Username, token);
        }
    }
}

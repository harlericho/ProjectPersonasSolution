using Microsoft.EntityFrameworkCore;
using ProjectPersonas.Domain.Entities;
using ProjectPersonas.Domain.Repositories;
using ProjectPersonas.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPersonas.Infrastructure.Repositories
{
    public class UsuarioRepository : BaseRepository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(AppDbContext context) : base(context)
        {
      
        }

        public async Task<Usuario?> GetByUsernameAsync(string username)
        {
            if (string.IsNullOrWhiteSpace(username))
            {
                throw new ArgumentException("Username cannot be empty.", nameof(username));
            }
           return await _context.Usuario.FirstOrDefaultAsync(u => u.Username == username);
        }
    }
}

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
    public class PersonaRepository : BaseRepository<Persona>, IPersonaRepository
    {
        public PersonaRepository(AppDbContext context) : base(context)
        {
        }
        // Metodo especifico para traer personas con su especialidad
        public async Task<IEnumerable<Persona>> GetAllWithEspecialidadAsync()
        {
            return await _context.Persona
                .Include(p => p.Especialidad)
                .ToListAsync();
        }
        public async Task<Persona?> GetByIdWithEspecialidadAsync(int id)
        {
            return await _context.Persona
                                 .Include(p => p.Especialidad)
                                 .FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}

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
    }
}

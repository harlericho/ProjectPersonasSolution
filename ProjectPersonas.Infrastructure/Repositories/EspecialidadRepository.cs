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
    public class EspecialidadRepository : BaseRepository<Especialidad>, IEspecialidadRepository
    {
        public EspecialidadRepository(AppDbContext context) : base(context)
        {
        }
    }
}

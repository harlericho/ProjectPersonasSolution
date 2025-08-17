using ProjectPersonas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPersonas.Domain.Repositories
{
    public interface IPersonaRepository :IRepository<Persona>
    {
        // Metodo especifico para traer personas con su especialidad
        Task<IEnumerable<Persona>> GetAllWithEspecialidadAsync();
        Task<Persona?> GetByIdWithEspecialidadAsync(int id);
    }
}

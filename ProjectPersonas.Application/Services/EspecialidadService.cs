using ProjectPersonas.Application.DTOs;
using ProjectPersonas.Domain.Entities;
using ProjectPersonas.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPersonas.Application.Services
{
    public class EspecialidadService
    {
        private readonly IEspecialidadRepository _especialidadRepository;
        public EspecialidadService(IEspecialidadRepository especialidadRepository)
        {
            _especialidadRepository = especialidadRepository ?? throw new ArgumentNullException(nameof(especialidadRepository));
        }
        public async Task<IEnumerable<Especialidad>> GetAllEspecialidadAsync()
        {
            return await _especialidadRepository.GetAllAsync();
        }
        public async Task<Especialidad> GetEspecialidadByIdAsync(int id)
        {
            return await _especialidadRepository.GetByIdAsync(id);
        }
        public async Task<EspecialidadDto> AddEspecialidadAsync(CreateEspecialidadDto especialidad)
        {
            if (especialidad == null)
            {
                throw new ArgumentNullException(nameof(especialidad));
            }
            var newEspecialidad = new Especialidad
            {
                Descripcion = especialidad.Descripcion,
            };
            await _especialidadRepository.AddAsync(newEspecialidad);
            return new EspecialidadDto(newEspecialidad.Id, newEspecialidad.Descripcion);
        }
        public async Task UpdateEspecialidadAsync(int id, UpdateEspecialidadDto especialidad)
        {
            if (especialidad == null)
            {
                throw new ArgumentNullException(nameof(especialidad));
            }
            var existingEspecialidad = await _especialidadRepository.GetByIdAsync(id);
            if (existingEspecialidad == null)
            {
                throw new KeyNotFoundException($"Especialidad with ID {id} not found.");
            }
            existingEspecialidad.Descripcion = especialidad.Descripcion;
            await _especialidadRepository.UpdateAsync(existingEspecialidad);
        }
        public async Task DeleteEspecialidadAsync(int id)
        {
            var existingEspecialidad = await _especialidadRepository.GetByIdAsync(id);
            if (existingEspecialidad == null)
            {
                throw new KeyNotFoundException($"Especialidad with ID {id} not found.");
            }
            await _especialidadRepository.DeleteAsync(id);
        }

    }
}

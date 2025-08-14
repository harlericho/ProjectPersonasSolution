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
    public class PersonaService
    {
        private readonly IPersonaRepository _personaRepository;
        private readonly IEspecialidadRepository _especialidadRepository;
        public PersonaService(IPersonaRepository personaRepository, IEspecialidadRepository especialidadRepository)
        {
            _personaRepository = personaRepository ?? throw new ArgumentNullException(nameof(personaRepository));
            _especialidadRepository = especialidadRepository ?? throw new ArgumentNullException(nameof(especialidadRepository));
        }
        public async Task<IEnumerable<Persona>> GetAllPersonasAsync()
        {
            return await _personaRepository.GetAllAsync();
        }
        public async Task<Persona> GetPersonaByIdAsync(int id)
        {
            return await _personaRepository.GetByIdAsync(id);
        }
        public async Task AddPersonaAsync(CreatePersonaDto persona)
        {
            if (persona == null)
            {
                throw new ArgumentNullException(nameof(persona));
            }
            var especialidad = await _especialidadRepository.GetByIdAsync(persona.EspecialidadId);
            if (especialidad == null)
            {
                throw new ArgumentException("Especialidad not found", nameof(persona.EspecialidadId));
            }
            var newPersona = new Persona
            {
                Cedula = persona.Cedula,
                Nombres = persona.Nombres,
                Direccion = persona.Direccion,
                Telefono = persona.Telefono,
                Id_Especialidad = persona.EspecialidadId,
            };
            await _personaRepository.AddAsync(newPersona);
        }
        public async Task UpdatePersonaAsync(int id, UpdatePersonaDto persona)
        {
            if (persona == null)
            {
                throw new ArgumentNullException(nameof(persona));
            }
            var existingPersona = await _personaRepository.GetByIdAsync(id);
            if (existingPersona == null)
            {
                throw new KeyNotFoundException($"Persona with ID {id} not found.");
            }
            var especialidad = await _especialidadRepository.GetByIdAsync(persona.EspecialidadId);
            if (especialidad == null)
            {
                throw new ArgumentException("Especialidad not found", nameof(persona.EspecialidadId));
            }
            existingPersona.Nombres = persona.Nombres;
            existingPersona.Direccion = persona.Direccion;
            existingPersona.Telefono = persona.Telefono;
            existingPersona.Id_Especialidad = persona.EspecialidadId;
            await _personaRepository.UpdateAsync(existingPersona);
        }
        public async Task DeletePersonaAsync(int id)
        {
            var existingPersona = await _personaRepository.GetByIdAsync(id);
            if (existingPersona == null)
            {
                throw new KeyNotFoundException($"Persona with ID {id} not found.");
            }
            await _personaRepository.DeleteAsync(id);

        }
    }
}

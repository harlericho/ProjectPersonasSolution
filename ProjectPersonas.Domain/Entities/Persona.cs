using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPersonas.Domain.Entities
{
    public class Persona
    {
        public int Id { get; set; }
        public string? Cedula { get; set; }
        public string? Nombres { get; set; }
        public string? Direccion { get; set; }
        public string? Telefono { get; set; }
        public int EspecialidadId { get; set; }
        public Especialidad? Especialidad { get; set; }  
    }
}

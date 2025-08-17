using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ProjectPersonas.Domain.Entities
{
    public class Especialidad
    {
        public int Id { get; set; }
        public string? Descripcion { get; set; }
        [JsonIgnore]
        public ICollection<Persona> Personas { get; set; } = new List<Persona>();
    }
}

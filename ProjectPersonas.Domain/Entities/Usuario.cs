using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPersonas.Domain.Entities
{
    public class Usuario
    {
        public int Id { get; set; }
        public string? Username { get; set; }
        public byte[]? PasswordHash { get; set; }
        public byte[]? PasswordSalt { get; set; }
        public bool Activo { get; set; } = true; // Default to true (1) for active users
    }
}

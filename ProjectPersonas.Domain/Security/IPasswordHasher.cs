using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPersonas.Domain.Security
{
    public interface IPasswordHasher
    {
        void CreateHash(string password, out byte[] passwordHash, out byte[] passwordSalt);
        bool VerifyHash(string password, byte[] storedHash, byte[] storedSalt);
    }
}

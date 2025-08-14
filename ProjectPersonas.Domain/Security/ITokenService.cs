using ProjectPersonas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPersonas.Domain.Security
{
    public interface ITokenService
    {
        string CreateToken(Usuario usuario);
    }
}

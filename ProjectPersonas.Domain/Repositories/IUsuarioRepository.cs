using ProjectPersonas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPersonas.Domain.Repositories
{
    public interface IUsuarioRepository: IRepository<Usuario>
    {
        Task<Usuario?> GetByUsernameAsync(string username);
    }
}

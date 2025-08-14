using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPersonas.Application.DTOs
{
    public record EspecialidadDto(int Id, string Descripcion);
    public record CreateEspecialidadDto(string Descripcion);
    public record UpdateEspecialidadDto(string Descripcion);
}

using FluentValidation;
using ProjectPersonas.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPersonas.Application.Validatiors
{
    public class CreateEspecialidadValidator : AbstractValidator<CreateEspecialidadDto>
    {
        public CreateEspecialidadValidator()
        {
            RuleFor(x => x.Descripcion).NotEmpty().MaximumLength(120);
        }
    }

    public class UpdateEspecialidadValidator : AbstractValidator<UpdateEspecialidadDto>
    {
        public UpdateEspecialidadValidator()
        {
            RuleFor(x => x.Descripcion).NotEmpty().MaximumLength(120);
        }
    }

}

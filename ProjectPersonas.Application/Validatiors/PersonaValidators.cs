using FluentValidation;
using ProjectPersonas.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPersonas.Application.Validatiors
{
    public class CreatePersonaValidator : AbstractValidator<CreatePersonaDto>
    {
        public CreatePersonaValidator()
        {
            RuleFor(x => x.Cedula).NotEmpty().Length(8, 20);
            RuleFor(x => x.Nombres).NotEmpty().MaximumLength(150);
            RuleFor(x => x.EspecialidadId).GreaterThan(0);
        }
    }

    public class UpdatePersonaValidator : AbstractValidator<UpdatePersonaDto>
    {
        public UpdatePersonaValidator()
        {
            RuleFor(x => x.Nombres).NotEmpty().MaximumLength(150);
            RuleFor(x => x.EspecialidadId).GreaterThan(0);
        }
    }

}

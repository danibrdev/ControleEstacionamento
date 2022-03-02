using FluentValidation;
using System;
using TesteBenner.DAO.Entities;

namespace TesteBenner.Business.Validation
{
    public class ParametroValidation : AbstractValidator<Parametro>
    {
        public ParametroValidation()
        {
            RuleSet("Default", () =>
            {
                RuleFor(d => d.VigenciaInicio)
                   .Must(BeAValidDate).WithMessage("O campo {PropertyName} precisa ser uma data válida");

                RuleFor(d => d.VigenciaFim)
                   .Must(BeAValidDate).WithMessage("O campo {PropertyName} precisa ser uma data válida");

                RuleFor(d => d.ValorHoraInicial)
                   .GreaterThan(0).WithMessage("O campo {PropertyName} deve ser maior do que 0");

                RuleFor(d => d.ValorHoraFinal)
                   .GreaterThan(0).WithMessage("O campo {PropertyName} deve ser maior do que 0");
            });

            RuleSet("Insert", () =>
            {
                RuleFor(d => d.VigenciaInicio)
                   .NotNull().WithMessage("Por favor, digite um valor para o campo {PropertyName}");

                RuleFor(d => d.VigenciaFim)
                   .NotNull().WithMessage("Por favor, digite um valor para o campo {PropertyName}");

                RuleFor(d => d.ValorHoraInicial)
                   .NotNull().WithMessage("Por favor, digite um valor para o campo {PropertyName}");

                RuleFor(d => d.ValorHoraFinal)
                   .NotNull().WithMessage("Por favor, digite um valor para o campo {PropertyName}");
            });

            RuleSet("Insert", () =>
            {
                RuleFor(d => d.ID)
                   .NotNull().WithMessage("{PropertyName} inválido")
                   .GreaterThan(0).WithMessage("{PropertyName} deve ser maior do que 0");
            });
        }

        private bool BeAValidDate(DateTime data)
        {
            return !data.Equals(default(DateTime));
        }
    }
}

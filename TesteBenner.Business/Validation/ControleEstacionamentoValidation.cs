using FluentValidation;
using System;
using TesteBenner.DAO.Entities;

namespace TesteBenner.Business.Validation
{

    public class ControleEstacionamentoValidation : AbstractValidator<ControleEstacionamento>
    {
        public ControleEstacionamentoValidation()
        {

            RuleSet("Default", () =>
            {
                RuleFor(d => d.PlacaVeiculo)
                  .NotEmpty().WithMessage("O campo {PropertyName} precisa ser preenchido");
            });

            RuleSet("InsertEntrada", () =>
            {
                RuleFor(d => d.Entrada)
                   .NotNull().WithMessage("Por favor, digite um valor para o campo {PropertyName}")
                   .Must(BeAValidDate).WithMessage("O campo {PropertyName} precisa ser uma data válida"); ;
            });

            RuleSet("InsertSaida", () =>
            {
                RuleFor(d => d.ID)
                   .NotNull().WithMessage("{PropertyName} inválido")
                   .GreaterThan(0).WithMessage("{PropertyName} deve ser maior do que 0");

                RuleFor(d => d.Saida)
                   .NotNull().WithMessage("Por favor, digite um valor para o campo {PropertyName}")
                   .Must(BeAValidNullableDate).WithMessage("O campo {PropertyName} precisa ser uma data válida")
                   .GreaterThan(d => d.Entrada).WithMessage("A data de saída deve ser maior do que a data de entrada")
                   .LessThanOrEqualTo(DateTime.Now).WithMessage("A data e hora de saída deve ser menor ou igual a data e hora de agora");
            });
        }

        private bool BeAValidDate(DateTime data)
        {
            return !data.Equals(default(DateTime));
        }

        private bool BeAValidNullableDate(DateTime? data)
        {
            return !data.Equals(default(DateTime));
        }
    }
}

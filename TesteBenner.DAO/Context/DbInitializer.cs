using System;
using System.Linq;
using TesteBenner.DAO.Entities;

namespace TesteBenner.DAO.Context
{
    public static class DbInitializer
    {
        public static void Initialize(EstacionamentoContext context)
        {
            context.Database.EnsureCreated();

            if (context.Parametros.Any())
                return; //Banco já está preenchido

            var parametros = new Parametro[]
            {
                new Parametro{VigenciaInicio = new DateTime(2022, 01, 01).Date, VigenciaFim = new DateTime(2022, 01, 31).Date, ValorHoraInicial = 10, ValorHoraFinal = 20},
                new Parametro{VigenciaInicio = new DateTime(2022, 02, 01).Date, VigenciaFim = new DateTime(2022, 02, 28).Date, ValorHoraInicial = 5, ValorHoraFinal = 10}
            };

            foreach (var parametro in parametros)
            {
                context.Add(parametro);
            }

            var controlesEstacionamento = new ControleEstacionamento[]
            {
                new ControleEstacionamento{Entrada = new DateTime(2022, 01, 10, 10, 35, 42), Saida = new DateTime(2022, 01, 10, 12, 00, 35), PlacaVeiculo = "JYM6917", Valor = 30},
                new ControleEstacionamento{Entrada = new DateTime(2022, 02, 25, 14, 42, 33), PlacaVeiculo = "JQO3174" },
            };
            foreach (var controle in controlesEstacionamento)
            {
                context.Add(controle);
            }

            context.SaveChanges();
        }
    }
}

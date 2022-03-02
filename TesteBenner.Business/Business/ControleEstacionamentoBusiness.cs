using System;
using System.Collections.Generic;
using System.Linq;
using TesteBenner.DAO.Context;
using TesteBenner.DAO.Entities;
using TesteBenner.DAO.Repository;

namespace TesteBenner.Business.Business
{
    public class ControleEstacionamentoBusiness
    {
        private readonly ControleEstacionamentoRepository _controleEstacionamentoRepository;
        private readonly ParametroRepository _parametroRepository;

        public ControleEstacionamentoBusiness(EstacionamentoContext context)
        {
            _controleEstacionamentoRepository = new ControleEstacionamentoRepository(context);
            _parametroRepository = new ParametroRepository(context);
        }

        public string InserirEntrada(ControleEstacionamento entradaObj)
        {
            try
            {
                var controleEstacionamentoObj = _controleEstacionamentoRepository.BuscarControleAbertoPorPlacaVeiculo(entradaObj.PlacaVeiculo);
                if (controleEstacionamentoObj != null)
                    return "Já há um controle de estacionamento aberto para esse veículo";

                _controleEstacionamentoRepository.Insert(entradaObj);
                _controleEstacionamentoRepository.SaveChanges();

                return "Sucesso";
            }
            catch (Exception ex)
            {
                return $"Erro ao tentar inserir a entrada: {ex.Message}";
            }
        }

        public string InserirSaida(ControleEstacionamento saidaObj)
        {
            try
            {
                var controleEstacionamentoObj = _controleEstacionamentoRepository.BuscarControleAbertoPorPlacaVeiculo(saidaObj.PlacaVeiculo);
                if (controleEstacionamentoObj == null)
                    return "Não há controle de estacionamento aberto para esse veículo";

                controleEstacionamentoObj.Saida = saidaObj.Saida;
                controleEstacionamentoObj.Valor = CalcularHoraEstacionamento(controleEstacionamentoObj);

                _controleEstacionamentoRepository.Merge(controleEstacionamentoObj);
                _controleEstacionamentoRepository.SaveChanges();

                return "Sucesso";
            }
            catch (Exception ex)
            {
                return $"Erro ao tentar inserir o saída: {ex.Message}";
            }
        }

        public List<ControleEstacionamento> BuscarControle()
        {
            return _controleEstacionamentoRepository.Get().ToList();
        }

        public decimal CalcularHoraEstacionamento(ControleEstacionamento controleEstacionamentoObj)
        {
            var parametros = _parametroRepository.BuscarPorData(controleEstacionamentoObj.Entrada);
            if (parametros != null)
            {
                var totalMinutos = ((DateTime)controleEstacionamentoObj.Saida).Subtract(controleEstacionamentoObj.Entrada).TotalMinutes;
                var totalHoras = Math.Floor((decimal)totalMinutos / 60);
                var totalRestoHoras = totalMinutos % 60;

                //Calculo hora Inicial 
                if (totalMinutos <= 30)
                    return parametros.ValorHoraInicial / 2;
                else if (totalMinutos <= 70)
                    return parametros.ValorHoraInicial;

                //Calculo horas adicionais
                if (totalRestoHoras <= 10)
                    return parametros.ValorHoraInicial + (totalHoras - 1) * parametros.ValorHoraFinal;
                else if (totalRestoHoras <= 30)
                    return parametros.ValorHoraInicial + (totalHoras - 1) * parametros.ValorHoraFinal + parametros.ValorHoraFinal / 2;
                else
                    return parametros.ValorHoraInicial + (totalHoras - 1) * parametros.ValorHoraFinal + parametros.ValorHoraFinal;
            }
            return 0;
        }
    }
}

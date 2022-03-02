using System;
using System.Collections.Generic;
using System.Linq;
using TesteBenner.DAO.Context;
using TesteBenner.DAO.Entities;
using TesteBenner.DAO.Repository;

namespace TesteBenner.Business.Business
{
    public class ParametroBusiness
    {
        private readonly ParametroRepository _parametroRepository;

        public ParametroBusiness(EstacionamentoContext context) => _parametroRepository = new ParametroRepository(context);

        public string InserirParametro(Parametro parametroObj)
        {
            try
            {
                var parametrosInicio = _parametroRepository.BuscarPorData(parametroObj.VigenciaInicio);
                var parametroFim = _parametroRepository.BuscarPorData(parametroObj.VigenciaFim);

                if (parametrosInicio != null || parametroFim != null)
                    return "Já existe um parâmetro com essa data";

                _parametroRepository.Insert(parametroObj);
                _parametroRepository.SaveChanges();

                return "Sucesso";
            }
            catch (Exception ex)
            {
                return $"Erro ao tentar inserir o parâmetro: {ex.Message}";
            }
        }

        public List<Parametro> BuscarParametros()
        {
            return _parametroRepository.Get().ToList();
        }
    }
}

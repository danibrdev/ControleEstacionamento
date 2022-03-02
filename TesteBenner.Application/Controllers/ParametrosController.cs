using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using TesteBenner.Business.Business;
using TesteBenner.Business.Validation;
using TesteBenner.DAO.Context;
using TesteBenner.DAO.Entities;

namespace TesteBenner.Application.Controllers
{
    public class ParametrosController : Controller
    {
        private readonly ParametroBusiness _business;

        public ParametrosController(EstacionamentoContext context) => _business = new ParametroBusiness(context);

        public IActionResult Index()
        {
            return View(_business.BuscarParametros());
        }

        public IActionResult InserirParametro()
        {
            return View();
        }

        [HttpPost]
        public IActionResult InserirParametro([Bind("VigenciaInicio,VigenciaFim,ValorHoraInicial,ValorHoraFinal,ID")][CustomizeValidator(RuleSet = "Insert, Default")] Parametro parametro)
        {
            var retorno = "";
            var validador = new ParametroValidation().Validate(parametro);
            validador.AddToModelState(ModelState, null);
            if (ModelState.IsValid)
                retorno = _business.InserirParametro(parametro);

            if (retorno != "Sucesso")
                ModelState.AddModelError("", retorno);

            return View(parametro);
        }
    }
}

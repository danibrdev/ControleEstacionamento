using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using TesteBenner.Business.Business;
using TesteBenner.Business.Validation;
using TesteBenner.DAO.Context;
using TesteBenner.DAO.Entities;

namespace TesteBenner.Application.Controllers
{
    public class ControleEstacionamentoController : Controller
    {
        private readonly ControleEstacionamentoBusiness _business;
        public ControleEstacionamentoController(EstacionamentoContext context) => _business = new ControleEstacionamentoBusiness(context);

        public IActionResult Index()
        {
            return View(_business.BuscarControle());
        }

        public IActionResult InserirEntrada()
        {
            return View();
        }

        [HttpPost]
        public IActionResult InserirEntrada([Bind("Entrada,PlacaVeiculo")][CustomizeValidator(RuleSet = "InsertEntrada, Default")] ControleEstacionamento controleEstacionamento)
        {
            var retorno = "";
            var validador = new ControleEstacionamentoValidation().Validate(controleEstacionamento);
            validador.AddToModelState(ModelState, null);

            if (ModelState.IsValid)
                retorno = _business.InserirEntrada(controleEstacionamento);

            if (retorno != "Sucesso")
                ModelState.AddModelError("", retorno);

            return View(controleEstacionamento);
        }

        public IActionResult InserirSaida()
        {
            return View();
        }

        [HttpPost]
        public IActionResult InserirSaida([Bind("Saida,PlacaVeiculo")][CustomizeValidator(RuleSet = "InsertSaida, Default")] ControleEstacionamento controleEstacionamento)
        {
            var retorno = "";
            var validador = new ControleEstacionamentoValidation().Validate(controleEstacionamento);
            validador.AddToModelState(ModelState, null);

            if (ModelState.IsValid)
                retorno = _business.InserirSaida(controleEstacionamento);

            if (retorno != "Sucesso")
                ModelState.AddModelError("", retorno);

            return View(controleEstacionamento);
        }
    }
}

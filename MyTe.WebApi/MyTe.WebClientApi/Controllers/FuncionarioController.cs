using Microsoft.AspNetCore.Mvc;
using MyTe.WebClientApi.Models;
using MyTe.WebClientApi.Services;

namespace MyTe.WebClientApi.Controllers
{
    public class FuncionarioController : Controller
    {
        private readonly FuncionariosService funcionariosService;
        public FuncionarioController(FuncionariosService funcionariosService)
        {
            this.funcionariosService = funcionariosService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> ListarFuncionarios()
        {
            try
            {
                var funcionarios = await funcionariosService.ListarFuncionariosAsync();
                return View(funcionarios);
            }
            catch (Exception ex)
            {
                return View("_Erro", ex);
            }
        }

        [HttpGet]
        public IActionResult IncluirFuncionario()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> IncluirFuncionario(FuncionarioClient funcionario)
        {
            try
            {
                await funcionariosService.IncluirFuncionarioAsync(funcionario);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View("_Erro", ex);
            }
        }
    }
}
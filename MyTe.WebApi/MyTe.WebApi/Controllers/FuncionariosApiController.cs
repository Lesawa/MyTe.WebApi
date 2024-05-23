using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyTe.WebApi.Models.Entities;
using MyTe.WebApi.Services;

namespace MyTe.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuncionariosApiController : ControllerBase
    {
        private readonly FuncionariosService funcionariosService;
        public FuncionariosApiController(FuncionariosService funcionariosService)
        {
            //this.horasService = horasService;
            this.funcionariosService = funcionariosService;
        }

        [HttpGet]
        public IActionResult ListarFuncionarios()
        {
            return Ok(funcionariosService.Listar());
        }

        [HttpPost]
        public IActionResult IncluirFuncionario(Funcionario funcionario)
        {
            funcionariosService.Incluir(funcionario);
            return Created("/api/candidatosapi/", funcionario);
        }
        [HttpPut]
        public IActionResult AlterarFuncionario(Funcionario funcionario)
        {
            funcionariosService.Alterar(funcionario);
            return NoContent();
        }

        [HttpDelete]
        public IActionResult RemoverFuncionario(Funcionario funcionario)
        {
            try
            {
                funcionariosService.Remover(funcionario);
                return NoContent();
            }
            catch (Exception ex)
            {
                var erro = new
                {
                    status = 403,
                    mensagem = ex.Message
                };
                return BadRequest(erro);
            }
        }

        [HttpDelete("remover/{email}")]
        public IActionResult RemoverFuncionario(string email)
        {
            try
            {
                var funcionario = funcionariosService.Buscar(email);
                if (funcionario == null)
                {
                    throw new Exception("Nenhum Funcionario com este E-mail");
                }
                funcionariosService.Remover(funcionario!);
                return NoContent();
            }
            catch (Exception ex)
            {
                var erro = new
                {
                    status = 403,
                    mensagem = ex.Message
                };
                return BadRequest(erro);
            }

        }
    }
}

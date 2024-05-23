using Microsoft.AspNetCore.Mvc;
using MyTe.WebApi.Services;

namespace MyTe.WebApi.Controllers
{ 

    [Route("api/[controller]")]
    [ApiController]
    public class HorasApiController : ControllerBase
    {
        private readonly HorasService _horasService;
        public HorasApiController(HorasService horasService) 
        {
        this._horasService = horasService;        
        }

        [HttpGet]
        public IActionResult ListarResumoFuncionarios()
        {
            return Ok(_horasService.ListarResumoFuncionarios());
        }
    }
}

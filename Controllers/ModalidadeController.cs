using APIEscolaArabe.Data;
using Microsoft.AspNetCore.Mvc;

namespace APIEscolaArabe.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModalidadeController : ControllerBase
    {
        private readonly ApplicationDbContext database;

        [HttpGet]  
        public IActionResult ListarModalidade()
        {
            return Ok();
        }
        [HttpGet("{id}")]
        public IActionResult ListarModalidadeComId(int id)
        {
            return Ok("ok" + id);
        }//falta metodo post
    }
}
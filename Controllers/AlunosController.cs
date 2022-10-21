using Microsoft.AspNetCore.Mvc;
using APIEscolaArabe.Models;
using APIEscolaArabe.Data;

namespace APIEscolaArabe.Controllers
{   
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AlunosController : ControllerBase
    {
        private readonly ApplicationDbContext database;
        [HttpPost("registro")]
        public IActionResult Registro([FromBody] Aluno aluno)
        {
            database.Add(aluno);
            database.SaveChanges();
            return Ok(new{Msg = "Usuário cadastrado com sucesso!"});           
        } 
    }
}
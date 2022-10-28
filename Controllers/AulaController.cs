using System;
using System.Linq;
using APIEscolaArabe.Data;
using APIEscolaArabe.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIEscolaArabe.Controllers
{
    [ApiController]
    public class AulaController : ControllerBase
    {
        private readonly ApplicationDbContext database;

        [HttpGet]
        public IActionResult Get()
        {
            var aulas = database.Aulas.ToList();
            return Ok("");
        }

        [HttpPost]
        public IActionResult Post([FromBody] AulaDto model)
        {
            try
            {
                AulaDto aulas = new AulaDto();

                aulas.HorarioAula = model.HorarioAula;

                database.Add(aulas);
                database.SaveChanges();

                return Ok(new { Msg = "Aula criada com sucesso!" });

            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar criar uma categoria. Erro: {ex.Message}");
            }

        }

    }
}
using System;
using System.Linq;
using APIEscolaArabe.Data;
using APIEscolaArabe.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIEscolaArabe.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModalidadeController : ControllerBase
    {
        private readonly ApplicationDbContext database;

        [HttpGet]
        public IActionResult Get()
        {
            var modalidades = database.Modalidades.ToList();
            return Ok("");
        }
        [HttpGet("{id}")]
        public IActionResult ListarModalidadeComId(int id)
        {
            return Ok("ok" + id);
        }

        [HttpPost]
        public IActionResult Post([FromBody] ModalidadeDto model)
        {
            try
            {

                ModalidadeDto modalidades = new ModalidadeDto();

                modalidades.DiasSemana = model.DiasSemana;
                modalidades.HorarioAula = model.HorarioAula;
                modalidades.NomeCurso = model.NomeCurso;
                modalidades.NomeProf = model.NomeProf;

                database.Add(modalidades);
                database.SaveChanges();

                return Ok(new { Msg = "Modalidade criada com sucesso!" });

            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar criar uma categoria. Erro: {ex.Message}");
            }
        }
    }
}
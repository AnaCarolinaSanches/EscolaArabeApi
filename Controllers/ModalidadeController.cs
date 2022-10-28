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
        public ModalidadeController(ApplicationDbContext database)
        {
            this.database = database;
        }

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
        [HttpPatch]
        public IActionResult Patch([FromBody] Modalidade model)
        {
            if (model.Id > 0)
            {
                try
                {
                    var m = database.Modalidades.First(mtemp => mtemp.Id == model.Id);
                    if (m != null)
                    {
                        m.DiasSemana = m.DiasSemana != null ? model.DiasSemana : m.DiasSemana;
                        m.HorarioAula = m.HorarioAula != null ? model.HorarioAula : m.HorarioAula;
                        m.NomeCurso = m.NomeCurso != null ? model.NomeCurso : m.NomeCurso;
                        m.NomeProf = m.NomeProf != null ? model.NomeProf : m.NomeProf;

                        database.SaveChanges();
                        return Ok();
                    }
                    else
                    {
                        Response.StatusCode = 400;
                        return new ObjectResult(new { msg = "Modalidade não encontrada" });
                    }
                }
                catch
                {
                    Response.StatusCode = 400;
                    return new ObjectResult(new { msg = "Modalidade não encontrada" });
                }

            }
            else
            {
                Response.StatusCode = 400;
                return new ObjectResult(new { msg = "Id Inválido!" });
            }

        }

    }
}
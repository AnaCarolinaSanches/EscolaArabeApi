using System;
using System.Linq;
using APIEscolaArabe.Data;
using APIEscolaArabe.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIEscolaArabe.Controllers
{
    [Route("api/v1/[controller]")]
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
            return Ok(modalidades);
        }

        [HttpPost]
        public IActionResult Post([FromBody] ModalidadeDto model)
        {
            try
            {

                Modalidade modalidades = new Modalidade();

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
                    $"Erro ao tentar cadastrar uma modalidade. Erro: {ex.Message}");
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
                        return Ok(new { msg = "Modalidade editada com sucesso." });
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

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var modalidade = database.Modalidades.First(m => m.Id == id);
                database.Remove(modalidade);
                database.SaveChanges();
                return Ok();

            }
            catch (Exception)
            {
                Response.StatusCode = 404;
                return new ObjectResult("");

            }

        }

    }
}
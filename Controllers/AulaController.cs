using System;
using System.Linq;
using APIEscolaArabe.Data;
using APIEscolaArabe.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIEscolaArabe.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AulaController : ControllerBase
    {
        private readonly ApplicationDbContext database;
        public AulaController(ApplicationDbContext database)
        {
            this.database = database;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var aulas = database.Aulas.ToList();
            return Ok(aulas);
        }

        [HttpPost]
        public IActionResult Post([FromBody] AulaDto model)
        {
            try
            {
                Aula aulas = new Aula();

                aulas.HorarioAula = model.HorarioAula;

                database.Add(aulas);
                database.SaveChanges();

                return Ok(new { Msg = "Aula criada com sucesso!" });

            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar cadastrar uma aula. Erro: {ex.Message}");
            }

        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var aula = database.Aulas.First(a => a.Id == id);
                database.Remove(aula);
                database.SaveChanges();
                return Ok();

            }
            catch (Exception)
            {
                Response.StatusCode = 404;
                return new ObjectResult("");

            }

        }

        [HttpPatch]
        public IActionResult Patch([FromBody] Aula aula)
        {
            if (aula.Id > 0)
            {
                try
                {
                    var a = database.Aulas.First(atemp => atemp.Id == aula.Id);
                    if (a != null)
                    {
                        a.HorarioAula = a.HorarioAula != null ? aula.HorarioAula : a.HorarioAula;

                        database.SaveChanges();
                        return Ok(new { msg = "Aula editada com sucesso." });
                    }
                    else
                    {
                        Response.StatusCode = 400;
                        return new ObjectResult(new { msg = "Aula não encontrado" });
                    }
                }
                catch
                {
                    Response.StatusCode = 400;
                    return new ObjectResult(new { msg = "Aula não encontrado" });
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
using Microsoft.AspNetCore.Mvc;
using APIEscolaArabe.Models;
using APIEscolaArabe.Data;
using System.Linq;
using EscolaArabeApi.Models.DTO;
using System;
using Microsoft.AspNetCore.Http;

namespace APIEscolaArabe.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AlunosController : ControllerBase
    {
        private readonly ApplicationDbContext database;

        [HttpGet]
        public IActionResult Get()
        {
            var alunos = database.Alunos.ToList();
            return Ok("");
        }

        [HttpPost("registro")]
        public IActionResult Registro([FromBody] Aluno aluno)
        {
            database.Add(aluno);
            database.SaveChanges();
            return Ok(new { Msg = "Usuário cadastrado com sucesso!" });
        }
        [HttpPatch]
        public IActionResult Patch([FromBody] Aluno aluno)
        {
            if (aluno.Id > 0)
            {
                try
                {
                    var a = database.Alunos.First(atemp => atemp.Id == aluno.Id);
                    if (a != null)
                    {
                        a.NomeCompleto = a.NomeCompleto != null ? aluno.NomeCompleto : a.NomeCompleto;
                        a.Matricula = a.Matricula != null ? aluno.Matricula : a.Matricula;
                        a.CPF = a.CPF != null ? aluno.CPF : a.CPF;
                        a.Telefone = a.Telefone != null ? aluno.Telefone : a.Telefone;


                        database.SaveChanges();
                        return Ok();
                    }
                    else
                    {
                        Response.StatusCode = 400;
                        return new ObjectResult(new { msg = "Produto não encontrado" });
                    }
                }
                catch
                {
                    Response.StatusCode = 400;
                    return new ObjectResult(new { msg = "Produto não encontrado" });
                }

            }
            else
            {
                Response.StatusCode = 400;
                return new ObjectResult(new { msg = "Id Inválido!" });
            }

        }
        [HttpPost]
        public IActionResult Post([FromBody] AlunoDto model)
        {
            try
            {
                Aluno aluno = new Aluno();
                aluno.NomeCompleto = model.NomeCompleto;
                aluno.Matricula = model.Matricula;
                aluno.CPF = model.CPF;
                database.Add(aluno);
                database.SaveChanges();

                return Ok(new { Msg = "Alunos criado com sucesso!" });

            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar criar uma categoria. Erro: {ex.Message}");

            }


        }
    }
}
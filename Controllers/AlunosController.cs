using Microsoft.AspNetCore.Mvc;
using APIEscolaArabe.Models;
using APIEscolaArabe.Data;
using System.Linq;
using EscolaArabeApi.Models.DTO;
using System;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace APIEscolaArabe.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AlunosController : ControllerBase
    {
        private readonly ApplicationDbContext database;
        public AlunosController(ApplicationDbContext database)
        {
            this.database = database;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAlunos()
        {
            IQueryable<Aluno> query = database.Alunos.Include(pe => pe.AlunosModalidades)
                    .ThenInclude(ad => ad.modalidade);


            var result = await query.ToArrayAsync();
            return Ok(result);

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
                        return Ok(new { msg = "Aluno editado com sucesso." });
                    }
                    else
                    {
                        Response.StatusCode = 400;
                        return new ObjectResult(new { msg = "Aluno não encontrado" });
                    }
                }
                catch
                {
                    Response.StatusCode = 400;
                    return new ObjectResult(new { msg = "Aluno não encontrado" });
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
                aluno.Telefone = model.Telefone;
                aluno.Endereco = database.Enderecos.First(endereco => endereco.Id == model.EnderecoId);
                //aluno.Modalidade = database.Modalidades.First(modalidade => modalidade.Id == model.ModalidadeId);

                database.Add(aluno);
                database.SaveChanges();

                return Ok(new { Msg = "Aluno criado com sucesso!" });

            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar cadastrar um aluno. Erro: {ex.Message}");

            }


        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var aluno = database.Alunos.First(a => a.Id == id);
                database.Remove(aluno);
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
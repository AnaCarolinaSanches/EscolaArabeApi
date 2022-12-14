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
    public class EnderecoController : ControllerBase
    {
        private readonly ApplicationDbContext database;
        public EnderecoController(ApplicationDbContext database)
        {
            this.database = database;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var enderecos = database.Enderecos.ToList();
            return Ok(enderecos);
        }

        [HttpPost]
        public IActionResult Post([FromBody] EnderecoDto model)
        {
            try
            {
                Endereco endereco = new Endereco();

                endereco.Bairro = model.Bairro;
                endereco.CEP = model.CEP;
                endereco.Cidade = model.Cidade;
                endereco.Numero = model.Numero;
                endereco.Rua = model.Rua;

                database.Add(endereco);
                database.SaveChanges();

                return Ok(new { Msg = "Endereço criado com sucesso!" });

            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar cadastrar um endereço. Erro: {ex.Message}");
            }

        }

        [HttpPatch]
        public IActionResult Patch([FromBody] Endereco model)
        {
            if (model.Id > 0)
            {
                try
                {
                    var e = database.Enderecos.First(etemp => etemp.Id == model.Id);
                    if (e != null)
                    {
                        e.Bairro = e.Bairro != null ? model.Bairro : e.Bairro;
                        e.CEP = e.CEP != null ? model.CEP : e.CEP;
                        e.Cidade = e.Cidade != null ? model.Cidade : e.Cidade;
                        e.Numero = e.Numero != null ? model.Numero : e.Numero;
                        e.Rua = e.Rua != null ? model.Rua : e.Rua;

                        database.SaveChanges();
                        return Ok(new { msg = "Endereço editado com sucesso." });
                    }
                    else
                    {
                        Response.StatusCode = 400;
                        return new ObjectResult(new { msg = "Endereço não encontrada" });
                    }
                }
                catch
                {
                    Response.StatusCode = 400;
                    return new ObjectResult(new { msg = "Endereço não encontrada" });
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
                var endereco = database.Enderecos.First(e => e.Id == id);
                database.Remove(endereco);
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
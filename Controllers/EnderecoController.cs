using System;
using System.Linq;
using APIEscolaArabe.Data;
using APIEscolaArabe.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIEscolaArabe.Controllers
{
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
            return Ok("");
        }

        [HttpPost]
        public IActionResult Post([FromBody] EnderecoDto model)
        {
            try
            {
                EnderecoDto enderecos = new EnderecoDto();

                enderecos.Bairro = model.Bairro;
                enderecos.CEP = model.CEP;
                enderecos.Cidade = model.Cidade;
                enderecos.Numero = model.Numero;
                enderecos.Rua = model.Rua;

                database.Add(enderecos);
                database.SaveChanges();

                return Ok(new { Msg = "Endereço criado com sucesso!" });

            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                     $"Erro ao tentar criar uma categoria. Erro: {ex.Message}");
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
                        return Ok();
                    }
                    else
                    {
                        Response.StatusCode = 400;
                        return new ObjectResult(new { msg = "Rua não encontrada" });
                    }
                }
                catch
                {
                    Response.StatusCode = 400;
                    return new ObjectResult(new { msg = "Rua não encontrada" });
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
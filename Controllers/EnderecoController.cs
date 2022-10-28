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

    }
}
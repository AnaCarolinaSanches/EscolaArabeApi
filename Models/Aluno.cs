using System.Collections;
using System.Collections.Generic;
using EscolaArabeApi.Models;

namespace APIEscolaArabe.Models
{
    public class Aluno
    {
        public int Id { get; set; }
        public string NomeCompleto { get; set; }
        public string CPF { get; set; }
        public string Telefone { get; set; }
        public string Matricula { get; set; }
        public Endereco Endereco { get; set; }
        public IEnumerable<AlunoModalidade> AlunosModalidades { get; set; }

    }
}
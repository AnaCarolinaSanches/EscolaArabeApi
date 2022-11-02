
using System;

namespace APIEscolaArabe.Models
{
    public class Aula
    {
        public Aluno aluno { get; set; }
        public Modalidade modalidade { get; set; }
        public int Id { get; set; }
        public DateTime HorarioAula { get; set; }
    }
}
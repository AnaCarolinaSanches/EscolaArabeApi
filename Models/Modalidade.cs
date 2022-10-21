using System;

namespace APIEscolaArabe.Models
{
    public class Modalidade
    {
        public int Id { get; set; }
        public string NomeCurso { get; set; }
        public string NomeProf { get; set; }
        public DateTime HorarioAula { get; set; }
        public DateTime DiasSemana { get; set; }
    }
}
using System;
using System.Collections.Generic;
using EscolaArabeApi.Models;

namespace APIEscolaArabe.Models
{
    public class Modalidade
    {
        public int Id { get; set; }
        public string NomeCurso { get; set; }
        public string NomeProf { get; set; }
        public DateTime HorarioAula { get; set; }
        public DateTime DiasSemana { get; set; }
        public IEnumerable<ModalidadeAula> ModalidadeAulas { get; set; }
    }
}
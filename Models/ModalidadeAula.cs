using APIEscolaArabe.Models;

namespace EscolaArabeApi.Models
{
    public class ModalidadeAula
    {
        public ModalidadeAula() { }
        public ModalidadeAula(int aulaId, int modalidadeId)
        {
            this.AulaId = aulaId;
            this.ModalidadeId = modalidadeId;
        }
        public int AulaId { get; set; }
        public Aula aula { get; set; }
        public int ModalidadeId { get; set; }
        public Modalidade modalidade { get; set; }
    }
}
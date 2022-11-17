using APIEscolaArabe.Models;

namespace EscolaArabeApi.Models
{
    public class AlunoModalidade
    {
        public AlunoModalidade() { }
        public AlunoModalidade(int alunoId, int modalidadeId)
        {
            this.AlunoId = alunoId;
            this.ModalidadeId = modalidadeId;
        }
        public int AlunoId { get; set; }
        public Aluno Aluno { get; set; }
        public int ModalidadeId { get; set; }
        public Modalidade modalidade { get; set; }
    }
}
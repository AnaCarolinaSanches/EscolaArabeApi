using APIEscolaArabe.Models;

namespace EscolaArabeApi.Models.DTO
{
    public class AlunoDto
    {
        public string NomeCompleto { get; set; }
        public string CPF { get; set; }
        public string Telefone { get; set; }
        public string Matricula { get; set; }
        public int EnderecoId { get; set; }
        public int ModalidadeId { get; set; }
        public int AulaId { get; set; }

    }
}
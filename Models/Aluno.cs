namespace APIEscolaArabe.Models
{
    public class Aluno
    {
        public int Id { get; set; }
        public string NomeCompleto { get; set; }
        public string CPF { get; set; }
        public string Telefone { get; set; }
        public string Matricula { get; set; }
        public int IdEndereco { get; set; }
        public int IdCurso { get; set; }
    }
}
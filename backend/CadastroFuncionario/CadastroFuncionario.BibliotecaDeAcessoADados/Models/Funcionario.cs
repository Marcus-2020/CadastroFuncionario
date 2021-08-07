namespace CadastroFuncionario.BibliotecaDeAcessoADados.Models
{

    public class Funcionario : IFuncionario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string DataNascimento { get; set; }
        public string Setor { get; set; }
        public string Funcao { get; set; }
        public string Experiencia { get; set; }
        public string TipoDeTrabalho { get; set; }
        public decimal Salario { get; set; }
    }
}
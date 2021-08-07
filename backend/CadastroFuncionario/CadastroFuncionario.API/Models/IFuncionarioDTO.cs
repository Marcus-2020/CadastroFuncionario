namespace CadastroFuncionario.API.Models
{
    public interface IFuncionarioDTO
    {
        int Id { get; set; }
        string Nome { get; set; }
        string Sobrenome { get; set; }
        string DataNascimento { get; set; }
        string Setor { get; set; }
        string Funcao { get; set; }
        string Experiencia { get; set; }
        string TipoDeTrabalho { get; set; }
        decimal Salario { get; set; }

    }
}
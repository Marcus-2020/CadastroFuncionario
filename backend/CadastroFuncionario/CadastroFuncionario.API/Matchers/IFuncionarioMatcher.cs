using CadastroFuncionario.API.Models;
using CadastroFuncionario.BibliotecaDeAcessoADados.Models;

namespace CadastroFuncionario.API.Matchers
{
    public interface IFuncionarioMatcher
    {
        Funcionario MatchFuncionario(IFuncionarioDTO dto);
        FuncionarioDTO MatchFuncionarioDTO(IFuncionario funcionario);
    }
}
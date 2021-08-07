using System.Collections.Generic;
using System.Threading.Tasks;

namespace CadastroFuncionario.BibliotecaDeAcessoADados.Repositories
{
    public interface IRepository<T>
    {
         Task<List<T>> GetTodos();

         Task<T> GetPorId(int id);

         Task<T> Criar(T entidade);

         Task<T> AtualizarPorId(int id, T entidade);

         Task<T> DeletarPorId(int id);

    }
}
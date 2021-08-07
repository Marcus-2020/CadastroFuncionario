using System.Collections.Generic;
using System.Threading.Tasks;
using CadastroFuncionario.BibliotecaDeAcessoADados.Contexts;
using CadastroFuncionario.BibliotecaDeAcessoADados.Models;
using Microsoft.EntityFrameworkCore;

namespace CadastroFuncionario.BibliotecaDeAcessoADados.Repositories
{
    public class FuncionarioRepository : IFuncionarioRepository
    {
        private readonly ApiContext _context;

        public FuncionarioRepository(ApiContext context)
        {
            this._context = context;
        }

        public async Task<List<IFuncionario>> GetTodos()
        {
            var funcionarios = await _context.Funcionarios.ToListAsync();
            
            return funcionarios;
        }

        public async Task<IFuncionario> GetPorId(int id)
        {
            var entidade = await _context.Funcionarios.FirstOrDefaultAsync(e => e.Id == id);

            return entidade;
        }

        public async Task<IFuncionario> Criar(IFuncionario entidade)
        {
            var resultado = (IFuncionario) await _context.AddAsync(entidade);

            return resultado;
        }
        
        public async Task<IFuncionario> AtualizarPorId(int id, IFuncionario entidade)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IFuncionario> DeletarPorId(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
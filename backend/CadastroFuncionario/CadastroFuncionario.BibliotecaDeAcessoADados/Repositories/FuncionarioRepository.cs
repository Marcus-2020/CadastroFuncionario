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

        public async Task<List<Funcionario>> GetTodos()
        {
            List<Funcionario> funcionarios = new List<Funcionario>();
            await _context.Funcionarios.ForEachAsync((f) => {
                Funcionario funcionario = f;
                funcionarios.Add(funcionario);
            });
            
            return funcionarios;
        }

        public async Task<Funcionario> GetPorId(int id)
        {
            var entidade = await _context.Funcionarios.FirstOrDefaultAsync(e => e.Id == id);

            return entidade;
        }

        public async Task<Funcionario> Criar(Funcionario entidade)
        {
            var resultado = await _context.Funcionarios.AddAsync(entidade);
            await _context.SaveChangesAsync();

            return resultado.Entity;
        }
        
        public async Task<Funcionario> AtualizarPorId(int id, Funcionario entidade)
        {
            throw new System.NotImplementedException();
        }

        public async Task<Funcionario> DeletarPorId(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
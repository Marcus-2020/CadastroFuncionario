using CadastroFuncionario.BibliotecaDeAcessoADados.Models;
using Microsoft.EntityFrameworkCore;

namespace CadastroFuncionario.BibliotecaDeAcessoADados.Contexts
{
    public class ApiContext : DbContext
    {
        public ApiContext(DbContextOptions<ApiContext> options) : base(options)
        {}

        public DbSet<IFuncionario> Funcionarios { get; set; }
    }
}
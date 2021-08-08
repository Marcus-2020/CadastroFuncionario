using System.Collections.Generic;
using System.Threading.Tasks;
using CadastroFuncionario.API.Controllers;
using CadastroFuncionario.API.Matchers;
using CadastroFuncionario.API.Models;
using CadastroFuncionario.BibliotecaDeAcessoADados.Models;
using CadastroFuncionario.BibliotecaDeAcessoADados.Repositories;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace CadastroFuncionario.API.Testes.Testes
{
    public class FuncionariosControllerTest
    {
        private readonly FuncionariosController _funcionariosController;
        private Mock<List<IFuncionarioDTO>> _listaFuncionariosMock;
        private readonly Mock<FuncionarioRepository> _funcionariosRepository;
        private readonly Mock<FuncionarioMatcher> _funcionarioMatcher;

        public FuncionariosControllerTest()
        {
            _listaFuncionariosMock = new Mock<List<IFuncionarioDTO>>();
            _funcionariosRepository = new Mock<FuncionarioRepository>();
            _funcionarioMatcher = new Mock<FuncionarioMatcher>();
            _funcionariosController = new FuncionariosController(_funcionariosRepository.Object, _funcionarioMatcher.Object);
        }

        [Fact]
        public void GetTeste_BuscarFuncionariosNoBancoRetornaLista()
        {            
            // act
            var resultado = _funcionariosController.GetTodosFuncionarios();

            // assert
            var modelo = Assert.IsAssignableFrom<Task<ActionResult<List<IFuncionarioDTO>>>>(resultado);
        }

        [Fact]
        public void GetTeste_BuscarFuncionarioNoBancoRetornaFuncionario()
        {
            // act
            var resultado = _funcionariosController.GetFuncionarioPorId(1);

            // assert
            var modelo = Assert.IsAssignableFrom<Task<ActionResult<IFuncionarioDTO>>>(resultado);
        }

        [Fact]
        public void PostTeste_InserirFuncionarioNoBancoRetornaFuncionario()
        {
            FuncionarioDTO funcionario = new FuncionarioDTO { 
                                            Nome = "Marcus", 
                                            Sobrenome = "Santos", 
                                            DataNascimento = "1997-02-12",
                                            Setor = "Desenovolvimento/Inovação",
                                            Funcao = "Desenvolvedor",
                                            Experiencia = "Júnior",
                                            TipoDeTrabalho = "Remoto",
                                            Salario = 3000.00M };
            // act
            var resultado = _funcionariosController.PostFuncionario(funcionario);

            // assert
            var modelo = Assert.IsAssignableFrom<Task<ActionResult<IFuncionarioDTO>>>(resultado);
        }
    }
}
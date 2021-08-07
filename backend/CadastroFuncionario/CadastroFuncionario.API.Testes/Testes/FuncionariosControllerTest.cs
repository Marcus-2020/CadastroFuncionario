using System.Collections.Generic;
using System.Threading.Tasks;
using CadastroFuncionario.API.Controllers;
using CadastroFuncionario.API.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace CadastroFuncionario.API.Testes.Testes
{
    public class FuncionariosControllerTest
    {
        private readonly FuncionariosController _funcionariosController;
        private Mock<List<IFuncionarioDTO>> _listaFuncionariosMock;

        public FuncionariosControllerTest()
        {
            _listaFuncionariosMock = new Mock<List<IFuncionarioDTO>>();
            _funcionariosController = new FuncionariosController();
            //_funcionariosController = new FuncionariosController(_listaFuncionariosMock.Object);
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
    }
}
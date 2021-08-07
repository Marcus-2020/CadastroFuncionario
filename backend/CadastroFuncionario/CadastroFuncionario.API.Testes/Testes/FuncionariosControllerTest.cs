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
            _funcionariosController = new FuncionariosController(_listaFuncionariosMock.Object);
        }

        [Fact]
        public void GetTeste_BuscarFuncionarioNoBancoRetornaLista()
        {
            // arrange
            var mockFuncionarios = new List<IFuncionarioDTO> {
                                        new FuncionarioDTO { 
                                            Nome = "Marcus", 
                                            Sobrenome = "Santos", 
                                            DataNascimento = "1997-02-12",
                                            Setor = "Desenovolvimento/Inovação",
                                            Funcao = "Desenvolvedor",
                                            Experiencia = "Júnior",
                                            TipoDeTrabalho = "Remoto",
                                            Salario = 3000.00M }
                                    };
            
            _listaFuncionariosMock.Object.AddRange(mockFuncionarios);
            
            // act
            var resultado = _funcionariosController.GetTodosFuncionarios();

            // assert
            var modelo = Assert.IsAssignableFrom<Task<ActionResult<List<IFuncionarioDTO>>>>(resultado);
        }
    }
}
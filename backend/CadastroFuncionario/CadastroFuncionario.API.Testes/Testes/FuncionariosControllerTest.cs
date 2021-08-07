using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace CadastroFuncionario.API.Testes.Testes
{
    public class FuncionariosControllerTest
    {
        private readonly FuncionariosController _funcionariosController;
        private Mock<List<Funcionario>> _listaFuncionariosMock;

        public FuncionariosControllerTest()
        {
            _listaFuncionariosMock = new Mock<List<Funcionario>>();
            _funcionariosController = new FuncionariosController(_listaFuncionariosMock.Object);
        }

        [Fact]
        public void GetTeste_BuscarFuncionarioNoBancoSeNaoEncontrarRetornaNulo()
        {
            // arrange
            var mockFuncionarios = new List<Funcionario> {
                                        new Funcionario { 
                                            Nome = "Marcus", 
                                            Sobrenome = "Santos", 
                                            DataNascimento = "1997-02-12",
                                            Setor = "Desenovolvimento/Inovação",
                                            Funcao = "Desenvolvedor",
                                            Experiencia = "Júnior",
                                            TipoDeTrabalho = "Remoto",
                                            Salario = 3000.00M },
                                            new Funcionario { 
                                            Nome = "Otávio", 
                                            Sobrenome = "Carmelo", 
                                            DataNascimento = "1991-04-08",
                                            Setor = "Desenovolvimento/Inovação",
                                            Funcao = "Desenvolvedor",
                                            Experiencia = "Pleno",
                                            TipoDeTrabalho = "Remoto",
                                            Salario = 4200.00M }
                                    };
            
            _listaFuncionariosMock.Object.AddRange(mockFuncionarios);
            
            // act
            var resultado = _funcionariosController.GetTodosFuncionarios();

            // assert
            var modelo = Assert.IsAssignableFrom<ActionResult<List<Funcionario>>>(resultado);
            //Assert.Equal(2, modelo.Value.Count);
        }
    }
}
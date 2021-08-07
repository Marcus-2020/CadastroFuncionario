using System;
using CadastroFuncionario.API.Helpers;
using CadastroFuncionario.API.Models;
using CadastroFuncionario.BibliotecaDeAcessoADados.Models;

namespace CadastroFuncionario.API.Matchers
{
    public class FuncionarioMatcher
    {
        private readonly IFuncionario _funcionario;
        private readonly IFuncionarioDTO _funcionarioDto;

        public FuncionarioMatcher(IFuncionario funcionario, IFuncionarioDTO funcionarioDto)
        {
            this._funcionario = funcionario;
            this._funcionarioDto = funcionarioDto;
        }
        public IFuncionario MatchFuncionario(IFuncionarioDTO dto)
        {
            // Clona o objeto injetado IFuncionario vázio para um novo objeto IFuncionario
            var funcionario = (IFuncionario)ClonarObjetoHelper.ClonarObjeto(_funcionario);

            // Transfere os dados do DTO para o objeto IFuncionario
            funcionario.Nome = dto.Nome;
            funcionario.Sobrenome = dto.Sobrenome;
            funcionario.DataNascimento = dto.DataNascimento;
            funcionario.Setor = dto.Setor;
            funcionario.Funcao = dto.Funcao;
            funcionario.Experiencia = dto.Experiencia;
            funcionario.TipoDeTrabalho = dto.TipoDeTrabalho;
            funcionario.Salario = dto.Salario;
            
            return funcionario;
        }

        public IFuncionarioDTO MatchFuncionarioDTO(IFuncionario funcionario)
        {
            // Clona o objeto injetado IFuncionarioDTO vázio para um novo objeto IFuncionarioDTO
            var dto = (IFuncionarioDTO)ClonarObjetoHelper.ClonarObjeto(_funcionario);

            // Transfere os dados do IFuncionario para o DTO 
            dto.Nome = funcionario.Nome;
            dto.Sobrenome = funcionario.Sobrenome;
            dto.DataNascimento = funcionario.DataNascimento;
            dto.Setor = funcionario.Setor;
            dto.Funcao = funcionario.Funcao;
            dto.Experiencia = funcionario.Experiencia;
            dto.TipoDeTrabalho = funcionario.TipoDeTrabalho;
            dto.Salario = funcionario.Salario;

            return dto;
        }
    }
}
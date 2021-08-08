using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CadastroFuncionario.API.Matchers;
using CadastroFuncionario.API.Models;
using CadastroFuncionario.BibliotecaDeAcessoADados.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CadastroFuncionario.API.Controllers
{
    [Route("api/v1/funcionarios")]
    [ApiController]
    public class FuncionariosController : ControllerBase
    {
        private readonly IFuncionarioRepository _repositorio;
        private readonly IFuncionarioMatcher _matcher;

        public FuncionariosController(IFuncionarioRepository repositorio, IFuncionarioMatcher matcher)
        {
            this._repositorio = repositorio;
            this._matcher = matcher;
        }

        [HttpGet("")]
        public async Task<ActionResult<List<FuncionarioDTO>>> GetTodosFuncionarios()
        {
            var funcionarios = new List<FuncionarioDTO>();

            try
            {
                var todos = await _repositorio.GetTodos();

                todos.ForEach((f) => {
                    var dto = _matcher.MatchFuncionarioDTO(f);
                    funcionarios.Add(dto);
                });
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return Ok(funcionarios);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<FuncionarioDTO>> GetFuncionarioPorId(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            var funcionario = await _repositorio.GetPorId((int)id);

            if (funcionario == null)
            {
                return NotFound(funcionario);
            }

            var dto = _matcher.MatchFuncionarioDTO(funcionario);

            return Ok(dto);
        }

        [HttpPost]
        public async Task<ActionResult<FuncionarioDTO>> PostFuncionario(FuncionarioDTO dto)
        {
            if (dto == null)
            {
                return BadRequest(dto);
            }

            var funcionarioParaInserir = _matcher.MatchFuncionario(dto);

            var funcionarioInserido = await _repositorio.Criar(funcionarioParaInserir);

            var dtoDeRetorno =  _matcher.MatchFuncionarioDTO(funcionarioInserido);

            return Ok(dtoDeRetorno);
        }

    }
}
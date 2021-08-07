using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CadastroFuncionario.API.Matchers;
using CadastroFuncionario.API.Models;
using CadastroFuncionario.BibliotecaDeAcessoADados.Contexts;
using CadastroFuncionario.BibliotecaDeAcessoADados.Models;
using CadastroFuncionario.BibliotecaDeAcessoADados.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CadastroFuncionario.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuncionariosController : ControllerBase
    {
        private readonly IFuncionarioRepository _repositorio;
        private readonly FuncionarioMatcher _matcher;
        private List<IFuncionarioDTO> _funcionarios;

        public FuncionariosController()
        {
        }
        
        public FuncionariosController(List<IFuncionarioDTO> funcionarios)
        {
            this._funcionarios = funcionarios;
        }

        public FuncionariosController(IFuncionarioRepository repositorio, FuncionarioMatcher matcher)
        {
            this._repositorio = repositorio;
            this._matcher = matcher;
        }

        [HttpGet("")]
        public async Task<ActionResult<List<IFuncionarioDTO>>> GetTodosFuncionarios()
        {
            var funcionarios = new List<IFuncionarioDTO>();

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
        public async Task<ActionResult<IFuncionarioDTO>> GetFuncionarioPorId(int? id)
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

        public async Task<ActionResult<IFuncionarioDTO>> PostFuncionario(IFuncionarioDTO dto)
        {
            if (dto == null)
            {
                return BadRequest(dto);
            }

            var funcionarioParaInserir = _matcher.MatchFuncionario(dto);

            var funcionarioInserido = (IFuncionario) await _repositorio.Criar(funcionarioParaInserir);

            var dtoDeRetorno =  _matcher.MatchFuncionarioDTO(funcionarioInserido);

            return Ok(dtoDeRetorno);
        }

    }
}
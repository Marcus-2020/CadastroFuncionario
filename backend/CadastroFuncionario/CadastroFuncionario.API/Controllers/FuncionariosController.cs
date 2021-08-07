using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CadastroFuncionario.API.Matchers;
using CadastroFuncionario.API.Models;
using CadastroFuncionario.BibliotecaDeAcessoADados.Contexts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CadastroFuncionario.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuncionariosController : ControllerBase
    {
        private readonly ApiContext _apiContext;
        private readonly FuncionarioMatcher _matcher;
        private List<IFuncionarioDTO> _funcionarios;

        public FuncionariosController()
        {
        }
        
        public FuncionariosController(List<IFuncionarioDTO> funcionarios)
        {
            this._funcionarios = funcionarios;
        }

        public FuncionariosController(ApiContext apiContext, FuncionarioMatcher matcher)
        {
            this._apiContext = apiContext;
            this._matcher = matcher;
        }

        [HttpGet("")]
        public async Task<ActionResult<List<IFuncionarioDTO>>> GetTodosFuncionarios()
        {
            var funcionarios = new List<IFuncionarioDTO>();

            try
            {
                await _apiContext.Funcionarios.ForEachAsync((f) => {
                    var func = _matcher.MatchFuncionarioDTO(f);
                    funcionarios.Add(func);
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

            var funcionario = await _apiContext.Funcionarios.FirstOrDefaultAsync(f => f.Id == id);

            if (funcionario == null)
            {
                return NotFound(funcionario);
            }

            var dto = _matcher.MatchFuncionarioDTO(funcionario);

            return Ok(dto);
        }

    }
}
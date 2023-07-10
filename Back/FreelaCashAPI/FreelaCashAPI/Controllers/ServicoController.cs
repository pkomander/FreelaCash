using FreelaCash.Dominio;
using FreelaCash.Repository.Dto;
using FreelaCash.Repository.Services.Interface;
using FreelaCashAPI.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FreelaCashAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicoController : ControllerBase
    {
        private readonly IServicoService _servicoService;
        private readonly IAccountService _accountService;

        public ServicoController(IServicoService servicoService, IAccountService accountService)
        {
            _servicoService = servicoService;
            _accountService = accountService;
        }

        [HttpPost]
        public async Task<IActionResult> PostServico([FromBody] ServicoDto model)
        {
            try
            {
                var servico = await _servicoService.AddServico(User.GetUserId(), model);

                if(servico == null)
                {
                    return NoContent();
                }

                return Ok(servico);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar adicionar Servico. Erro: {ex.Message}");
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllServicos()
        {
            var servicos = await _servicoService.GetAllServicos();

            if (servicos == null)
                return NoContent();

            return Ok(servicos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetServicoById(int id)
        {
            try
            {
                var servico = await _servicoService.GetServicoById(id);

                if (servico == null)
                    return NoContent();

                return Ok(servico);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar recuperar Servico. Erro: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateServico(int id, [FromBody] ServicoDto model)
        {
            try
            {
                var servico = await _servicoService.UpdateServicoById(id, model);

                if (servico == null)
                    return NoContent();

                return Ok(servico);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar atualizar Servico. Erro: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteServico(int id)
        {
            try
            {
                var servico = await _servicoService.DeleteServicoById(id);

                if (servico == false)
                    return BadRequest("Erro ao tentar deletar Servico.");

                return Ok(new { message = "Deletado" });
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar deletar Servico. Erro: {ex.Message}");
            }
        }
    }
}

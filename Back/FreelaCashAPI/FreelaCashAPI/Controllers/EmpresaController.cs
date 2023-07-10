using AutoMapper;
using FreelaCash.Repository.Dto;
using FreelaCash.Repository.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FreelaCashAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpresaController : ControllerBase
    {
        private readonly IEmpresaService _empresaService;

        public EmpresaController(IEmpresaService empresaService)
        {
            _empresaService = empresaService;
        }

        [HttpPost]
        public async Task<IActionResult> PostEmpresa([FromBody] EmpresaDto model)
        {
            try
            {
                var empresa = await _empresaService.AddEmpresa(model);

                if (empresa == null)
                {
                    return NoContent();
                }

                return Ok(empresa);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar adicionar Servico. Erro: {ex.Message}");
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEmpresa()
        {
            try
            {
                var empresa = await _empresaService.GetAllEmpresaAsync();

                if (empresa == null)
                {
                    return NoContent();
                }

                return Ok(empresa);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar adicionar Servico. Erro: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmpresaById(int id)
        {
            try
            {
                var empresa = await _empresaService.GetEmpresaByIdAsync(id);

                if (empresa == null)
                {
                    return NoContent();
                }

                return Ok(empresa);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar adicionar Servico. Erro: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmpresa(int id)
        {
            try
            {
                var empresa = await _empresaService.GetAllEmpresaAsync();

                if (empresa == null)
                {
                    return NoContent();
                }

                return Ok(empresa);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar adicionar Servico. Erro: {ex.Message}");
            }
        }
    }
}

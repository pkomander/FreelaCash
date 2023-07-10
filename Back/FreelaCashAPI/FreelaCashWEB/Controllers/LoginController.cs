using FreelaCashWEB.Helper;
using FreelaCashWEB.Models;
using FreelaCashWEB.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using NuGet.Common;
using NuGet.Protocol;

namespace FreelaCashWEB.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILoginService _loginService;
        private readonly ISessao _sessao;

        public LoginController(ILoginService loginService, ISessao sessao)
        {
            _loginService = loginService;
            _sessao = sessao;
        }

        public async Task<IActionResult> Index()
        {
            //se o usuario estiver logado, redirecione para a home

            if( await _sessao.BuscarSessaoDoUsuarioAsync() != null)
            {
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        public async Task<IActionResult> Sair()
        {
            _sessao.RemoverSessaoDoUsuarioAsync();

            return RedirectToAction("Index", "Login");
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] Login login)
        {
            try
            {
                var usuario = await _loginService.LoginAsync(login);

                if (usuario != null)
                {
                    // Salvar as informações na sessão
                    await _sessao.CriarSessaoDoUsuarioAsync(usuario);

                    return Ok(usuario);
                }

                return BadRequest("Erro ao tentar fazer login!");
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar realizar login Usuario. Erro: {ex.Message}");
            }
        }
    }
}

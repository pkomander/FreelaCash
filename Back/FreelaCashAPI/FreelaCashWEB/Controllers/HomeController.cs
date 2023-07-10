using FreelaCashWEB.Helper;
using FreelaCashWEB.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FreelaCashWEB.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ISessao _sessao;

        public HomeController(ILogger<HomeController> logger, ISessao sessao)
        {
            _logger = logger;
            _sessao = sessao;
        }

        public async Task<IActionResult> Index()
        {
            var usuario = await _sessao.BuscarSessaoDoUsuarioAsync();
            
            return View(usuario);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
using FreelaCashWEB.Helper;
using FreelaCashWEB.Models;
using FreelaCashWEB.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FreelaCashWEB.Controllers
{
    public class ServicoController : Controller
    {

        private readonly IServicoService _servicoService;
        private readonly ISessao _sessao;
        public ServicoController(IServicoService servicoService, ISessao sessao)
        {
            _servicoService = servicoService;
            _sessao = sessao;
        }

        // GET: ServicoController
        public async Task<IActionResult> Index()
        {
            var token = await _sessao.BuscarSessaoDoUsuarioAsync();
            var servicos = await _servicoService.RecuperaServicosAsync(token.Token);


            return View(servicos);
        }

        // GET: ServicoController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ServicoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ServicoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ServicoController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ServicoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ServicoController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ServicoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}

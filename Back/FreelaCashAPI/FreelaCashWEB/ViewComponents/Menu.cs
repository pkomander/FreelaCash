using FreelaCashWEB.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FreelaCashWEB.ViewComponents
{
    public class Menu : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            string sessaoUsuario = HttpContext.Session.GetString("sessaoUsuarioLogado");

            if (string.IsNullOrEmpty(sessaoUsuario))
            {
                return null;
            }

            RetornoAuth usuario = JsonConvert.DeserializeObject<RetornoAuth>(sessaoUsuario);

            return View(usuario);
        }
    }
}

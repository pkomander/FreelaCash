using FreelaCashWEB.Models;
using Newtonsoft.Json;

namespace FreelaCashWEB.Helper
{
    public class Sessao : ISessao
    {
        private readonly IHttpContextAccessor _httpContext;

        public Sessao(IHttpContextAccessor httpContext)
        {
            _httpContext = httpContext;
        }

        public async Task<RetornoAuth> BuscarSessaoDoUsuarioAsync()
        {
            string sessaoUsuario = _httpContext.HttpContext.Session.GetString("sessaoUsuarioLogado");

            if (string.IsNullOrEmpty(sessaoUsuario))
                return null;

            return JsonConvert.DeserializeObject<RetornoAuth>(sessaoUsuario);
        }

        public async Task CriarSessaoDoUsuarioAsync(RetornoAuth model)
        {
            string valor = JsonConvert.SerializeObject(model);
            _httpContext.HttpContext.Session.SetString("sessaoUsuarioLogado", valor);
        }

        public async Task RemoverSessaoDoUsuarioAsync()
        {
            _httpContext.HttpContext.Session.Remove("sessaoUsuarioLogado");
        }
    }
}

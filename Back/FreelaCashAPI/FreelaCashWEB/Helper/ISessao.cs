using FreelaCashWEB.Models;

namespace FreelaCashWEB.Helper
{
    public interface ISessao
    {
        Task CriarSessaoDoUsuarioAsync(RetornoAuth model);
        Task RemoverSessaoDoUsuarioAsync();
        Task<RetornoAuth> BuscarSessaoDoUsuarioAsync();
    }
}

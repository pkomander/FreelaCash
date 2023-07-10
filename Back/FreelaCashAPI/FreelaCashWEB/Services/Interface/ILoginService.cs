using FreelaCashWEB.Models;

namespace FreelaCashWEB.Services.Interface
{
    public interface ILoginService
    {
        Task<RetornoAuth> LoginAsync(Login model);
    }
}

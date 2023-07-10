using FreelaCashWEB.Models;

namespace FreelaCashWEB.Services.Interface
{
    public interface IServicoService
    {
        Task<Servico> AdicionaServicoAsync(string token, Servico model);
        Task<List<Servico>> RecuperaServicosAsync(string token);
        Task<Servico> RecuperaServicoIdAsync(string token);
        Task<Servico> UpdateServicoIdAsync(string token, Servico model);
        Task<bool> DeletaServicoIdAsync(string token, int servicoId);
    }
}

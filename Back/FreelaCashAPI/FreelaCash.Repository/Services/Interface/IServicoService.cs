using FreelaCash.Dominio;
using FreelaCash.Repository.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreelaCash.Repository.Services.Interface
{
    public interface IServicoService
    {
        Task<ServicoDto> AddServico(int userId, ServicoDto model);
        Task<List<ServicoDto>> GetAllServicos();
        Task<ServicoDto> GetServicoById(int id);

        Task<ServicoDto> UpdateServicoById(int id, ServicoDto model);
        Task<bool> DeleteServicoById(int id);

    }
}

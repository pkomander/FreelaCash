using FreelaCash.Dominio;
using FreelaCash.Repository.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreelaCash.Repository.Services.Interface
{
    public interface IEmpresaService
    {
        Task<EmpresaDto> AddEmpresa(EmpresaDto model);
        Task<List<EmpresaDto>> GetAllEmpresaAsync();
        Task<EmpresaDto> GetEmpresaByIdAsync(int id);
        Task<bool> DeleteEmpresaAsync(int id);
    }
}

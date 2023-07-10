using AutoMapper;
using FreelaCash.Dominio;
using FreelaCash.Repository.Dto;
using FreelaCash.Repository.Services.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreelaCash.Repository.Services.Repository
{
    public class EmpresaRepository : IEmpresaService
    {

        private readonly Context _context;
        private readonly IMapper _mapper;

        public EmpresaRepository(Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<EmpresaDto> AddEmpresa(EmpresaDto model)
        {
            try
            {
                var empresa = _mapper.Map<Empresa>(model);

                _context.Empresas.Add(empresa);
                //_context.Add(servico); -> utilizado para salvar em lotes
                if (await _context.SaveChangesAsync() > 0)
                {
                    var retorno = await GetEmpresaByIdAsync(empresa.Id);
                    return retorno;
                }

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<EmpresaDto>> GetAllEmpresaAsync()
        {
            try
            {
                var empresas = await _context.Empresas.ToListAsync();

                if (empresas == null)
                    return null;

                return _mapper.Map<List<EmpresaDto>>(empresas);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<EmpresaDto> GetEmpresaByIdAsync(int id)
        {
            try
            {
                var empresa = await _context.Empresas.Where(x => x.Id == id).FirstOrDefaultAsync();

                if (empresa == null)
                    return null;

                return _mapper.Map<EmpresaDto>(empresa);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteEmpresaAsync(int id)
        {
            try
            {
                var recuperaEmpresa = await _context.Empresas.FirstOrDefaultAsync(x => x.Id == id);

                if (recuperaEmpresa == null)
                    throw new Exception("Servico para delete nao encontrado.");

                _context.Empresas.Remove(recuperaEmpresa);
                if (await _context.SaveChangesAsync() > 0)
                    return true;

                return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

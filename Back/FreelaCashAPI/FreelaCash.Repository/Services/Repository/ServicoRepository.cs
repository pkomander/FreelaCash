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
    public class ServicoRepository : IServicoService
    {
        private readonly Context _context;
        private readonly IMapper _mapper;

        public ServicoRepository(Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ServicoDto> AddServico(int userId, ServicoDto model)
        {
            try
            {
                var servico = _mapper.Map<Servico>(model);
                servico.UserId = userId;

                _context.Servicos.Add(servico);
                //_context.Add(servico); -> utilizado para salvar em lotes
                if(await _context.SaveChangesAsync() > 0)
                {
                    var retorno = await GetServicoById(servico.Id);
                    return retorno;
                }

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<ServicoDto>> GetAllServicos()
        {
            try
            {
                var servicos = await _context.Servicos.Include(x => x.Empresa).ToListAsync();
                var resultado = _mapper.Map<List<ServicoDto>>(servicos);

                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ServicoDto> GetServicoById(int id)
        {
            try
            {
                var servico = await _context.Servicos.Where(x => x.Id == id).FirstOrDefaultAsync();

                if (servico == null)
                    return null;

                return _mapper.Map<ServicoDto>(servico);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ServicoDto> UpdateServicoById(int id, ServicoDto model)
        {
            try
            {
                var recuperaServico = await _context.Servicos.FirstOrDefaultAsync(x => x.Id == id);
                var servico = _mapper.Map(model, recuperaServico);
                servico.Id = id;

                _context.Servicos.Update(servico);

                if(await _context.SaveChangesAsync() > 0)
                {
                    var retorno = await GetServicoById(servico.Id);
                    return retorno;
                }

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteServicoById(int id)
        {
            try
            {
                var recuperaServico = await _context.Servicos.FirstOrDefaultAsync(x => x.Id == id);

                if(recuperaServico == null)
                    throw new Exception("Servico para delete nao encontrado.");

                _context.Servicos.Remove(recuperaServico);
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

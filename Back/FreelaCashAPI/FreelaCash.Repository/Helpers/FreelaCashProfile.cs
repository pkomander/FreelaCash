using AutoMapper;
using FreelaCash.Dominio;
using FreelaCash.Dominio.Identity;
using FreelaCash.Repository.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreelaCash.Repository.Helpers
{
    public class FreelaCashProfile : Profile
    {
        public FreelaCashProfile()
        {
            CreateMap<Servico, ServicoDto>().ReverseMap();
            CreateMap<Empresa, EmpresaDto>().ReverseMap();

            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<User, UserLoginDto>().ReverseMap();
            CreateMap<User, UserUpdateDto>().ReverseMap();
        }
    }
}

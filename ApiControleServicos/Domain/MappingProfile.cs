using ApiControleServicos.Domain.Models;
using AutoMapper;

namespace ApiControleServicos.Domain
{
	public class MappingProfile : Profile
	{
		public MappingProfile() 
		{ 
			CreateMap<UsuarioDto, UsuarioModel>().ReverseMap();
			CreateMap<EmpresaDto, EmpresaModel>().ReverseMap();
			CreateMap<ServicoDto, ServicoModel>().ReverseMap();
		}
	}
}

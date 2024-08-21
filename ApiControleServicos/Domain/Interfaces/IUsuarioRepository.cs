using ApiControleServicos.Domain.Dto;
using ApiControleServicos.Domain.Models;

namespace ApiControleServicos.Domain
{
	public interface IUsuarioRepository
	{
		Task Create(UsuarioModel usuario);
		Task<UsuarioDto> GetByIdDto(int id);
		Task<UsuarioModel> GetById(int id);
		Task<UsuarioDto> GetByName(string name);
		Task<List<UsuarioDto>> GetAll();
		void Update(UsuarioModel usuario);
	}
}

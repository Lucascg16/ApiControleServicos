using ApiControleServicos.Domain.Dto;
using ApiControleServicos.Domain.Models;

namespace ApiControleServicos.Domain
{
	public interface IUsuarioRepository
	{
		Task Create(UsuarioModel usuario);
		Task<UsuarioDto> GetById(int id);
		Task<List<UsuarioDto>> GetAll();
		void Update(UsuarioModel usuario);
	}
}

using ApiControleServicos.Domain;
using ApiControleServicos.Domain.Dto;

namespace ApiControleServicos.Infra
{
	public interface IUsuarioServices
	{
		Task Create(CreateUsuarioModel usuario);
		Task<UsuarioDto> GetById(int id);
		Task<UsuarioDto> GetByName(string name);
		Task<List<UsuarioDto>> GetAll();
		Task Update(UpdateUsuarioModel usuario);
	}
}

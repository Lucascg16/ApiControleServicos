using ApiControleServicos.Domain;
using ApiControleServicos.Domain.Dto;

namespace ApiControleServicos.Infra
{
	public interface IUsuarioServices
	{
		Task Create(CreateUsuarioModel usuario);
		Task<UsuarioDto> GetById(int id);
		Task<UsuarioDto> GetByName(string name);
		Task<List<UsuarioDto>> GetAll(int empresaId, int page, int itensPerPage);
		Task Update(UpdateUsuarioModel usuario);
	}
}

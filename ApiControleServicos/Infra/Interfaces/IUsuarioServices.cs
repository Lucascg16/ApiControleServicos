using ApiControleServicos.Domain;
using ApiControleServicos.Domain.Models;

namespace ApiControleServicos.Infra
{
	public interface IUsuarioServices
	{
		Task Create(CreateUsuarioModel usuario);
		Task<UsuarioDto> GetById(int id);
		Task<UsuarioModel> GetByUserName(string username);
		Task<UsuarioDto> GetByName(string name);
		Task<List<UsuarioDto>> GetAll(int empresaId, int page, int itensPerPage);
		Task Update(UpdateUsuarioModel usuario);
		Task UpdateSenha(int id, string senha);
		Task UpdateRole(int id, string role);
	}
}

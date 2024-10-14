using ApiControleServicos.Domain.Models;

namespace ApiControleServicos.Domain
{
	public interface IUsuarioRepository
	{
		Task Create(UsuarioModel usuario);
		Task<UsuarioDto> GetByIdDto(int id);
		Task<UsuarioDto> GetByIdDto(Guid id);
        Task<UsuarioModel> GetById(int id);
        Task<UsuarioModel> GetByUserName(string userName);
		Task<UsuarioDto> GetByName(string name);
		Task<int> GetAllNumber(int empresaId);
        Task<List<UsuarioDto>> GetAll(int empresaId ,int page, int itensPerPage);
		Task<List<UsuarioModel>> GetAll(int empresaId);
        void Update(UsuarioModel usuario);
		void UpdateRange(List<UsuarioModel> usuarios);
    }
}

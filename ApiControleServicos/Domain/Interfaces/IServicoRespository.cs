using ApiControleServicos.Domain.Models;

namespace ApiControleServicos.Domain
{
	public interface IServicoRespository
	{
		Task Create(ServicoModel servico);
		Task<int> GetTotalNumber(int empresaId, string flag);

        Task<List<ServicoDto>> GetAll(int emrpesaId, int page, int itensPerPage, string flag, string? nome);
		Task<ServicoDto> GetByIdDto(int Id);
		Task<ServicoModel> GetById(int id);
		void Update(ServicoModel servico);
	}
}

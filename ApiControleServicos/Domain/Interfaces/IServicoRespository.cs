using ApiControleServicos.Domain.Models;

namespace ApiControleServicos.Domain
{
	public interface IServicoRespository
	{
		Task Create(ServicoModel servico);
		Task<int> GetTotalNumber(int empresaId, bool close);

        Task<List<ServicoDto>> GetAllOpen(int emrpesaId, int page, int itensPerPage);
		Task<List<ServicoDto>> GetAllClosed(int emrpesaId, int page, int itensPerPage);
		Task<ServicoDto> GetByIdDto(int Id);
		Task<ServicoModel> GetById(int id);
		void Update(ServicoModel servico);
	}
}

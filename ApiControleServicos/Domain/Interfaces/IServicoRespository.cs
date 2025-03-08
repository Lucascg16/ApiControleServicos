using ApiControleServicos.Domain.Models;

namespace ApiControleServicos.Domain
{
	public interface IServicoRespository
	{
		Task Create(ServicoModel servico);
		Task<int> GetTotalNumber(int empresaId, ServiceFlagEnum flag);

        Task<List<ServicoDto>> GetAll(int emrpesaId, int page, int itensPerPage, ServiceFlagEnum flag, string? nome);
		Task<ServicoDto> GetByIdDto(int id);
		Task<ServicoModel> GetById(int id);
		void Update(ServicoModel servico);
	}
}

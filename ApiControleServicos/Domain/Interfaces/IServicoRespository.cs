using ApiControleServicos.Domain.Models;

namespace ApiControleServicos.Domain
{
	public interface IServicoRespository
	{
		Task Create(ServicoModel servico);
		Task<List<ServicoDto>> GetAllOpen(int emrpesaId, int page, int itensPerPage);
		Task<List<ServicoDto>> GetAll(int emrpesaId, int page, int itensPerPage);
		Task<ServicoDto> GetById(int Id);
		void Update(ServicoModel servico);
	}
}

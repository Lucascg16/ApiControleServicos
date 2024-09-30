using ApiControleServicos.Domain;
namespace ApiControleServicos.Infra
{
	public interface IServicoServices
	{
		Task Create(CreateServicoModel novoServico);
		Task<List<ServicoDto>> GetAllClosed(int emrpesaId, int page, int itensPerPage);
		Task<List<ServicoDto>> GetAllOpen(int emrpesaId, int page, int itensPerPage);
		Task<ServicoDto> GetById(int id);
		Task Update(UpdateServicoModel servico);
		Task FinalizarServico(int id, double faturamento);
		Task CancelarServico(int id);
	}
}

using ApiControleServicos.Domain;
namespace ApiControleServicos.Infra
{
	public interface IServicoServices
	{
		Task Create(CreateServicoModel novoServico);
		Task<int> GetAllNumber(int empresaId, string flag);
		Task<List<ServicoDto>> GetAll(int emrpesaId, int page, int itensPerPage, string flag);
		Task<ServicoDto> GetById(int id);
		Task Update(UpdateServicoModel servico);
		Task FinalizarServico(int id, double faturamento);
		Task CancelarServico(int id);
	}
}

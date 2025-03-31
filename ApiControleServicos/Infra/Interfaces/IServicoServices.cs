using ApiControleServicos.Domain;
namespace ApiControleServicos.Infra
{
	public interface IServicoServices
	{
		Task Create(CreateServicoModel novoServico);
		Task<int> GetAllNumber(int empresaId, ServiceFlagEnum flag);
		Task<List<ServicoDto>> GetAll(int emrpesaId, int page, int itensPerPage, ServiceFlagEnum flag, string? nome, DateTime data);
		Task<ServicoDto> GetById(int id);
		Task Update(UpdateServicoModel servico);
		Task FinalizarServico(int id, double faturamento);
		Task CancelarServico(int id);
	}
}

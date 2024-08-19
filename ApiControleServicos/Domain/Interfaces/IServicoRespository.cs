using ApiControleServicos.Domain.Models;

namespace ApiControleServicos.Domain
{
	public interface IServicoRespository
	{
		Task Create(ServicoModel servico);
		Task<ServicoModel> GetById(int Id);
		Task<List<ServicoModel>> GetAll();
		void Update(ServicoModel servico);
	}
}

using ApiControleServicos.Domain;
using ApiControleServicos.Domain.Models;

namespace ApiControleServicos.Infra
{
	public class ServicoServices : IServicoServices
	{
		private readonly IServicoRespository _repository;
		public ServicoServices(IServicoRespository respository) 
		{
			_repository = respository;
		}

		public async Task Create(CreateServicoModel novoServico)
		{
			ServicoModel servico = new(novoServico.Nome, novoServico.Description, novoServico.Custos, novoServico.OrcamentoInicial,
									novoServico.UsuarioId, novoServico.EmpresaId);
			await _repository.Create(servico);
		}

		public Task<List<ServicoDto>> GetAll(int emrpesaId, int page, int itensPerPage)
		{
			return _repository.GetAll(emrpesaId, page, itensPerPage);
		}

		public Task<List<ServicoDto>> GetAllOpen(int emrpesaId, int page, int itensPerPage)
		{
			return _repository.GetAllOpen(emrpesaId, page, itensPerPage);
		}

		public Task<ServicoDto> GetById(int id)
		{
			return _repository.GetByIdDto(id);
		}

		public async Task Update(UpdateServicoModel novoServico)
		{
			var servico = await _repository.GetById(novoServico.Id);
			servico.UpdateServico(novoServico.Nome, novoServico.Descricao, novoServico.Custos);
			_repository.Update(servico);
		}

		public async Task FinalizarServico(int id, double faturamento)
		{
			var servico = await _repository.GetById(id);
			servico.FinalizarServico(faturamento);
			_repository.Update(servico);
		}

		public async Task CancelarServico(int id)
		{
			var servico = await _repository.GetById(id);
			servico.Deletar();//altera a tag excluido para true
			_repository.Update(servico);
		}
	}
}

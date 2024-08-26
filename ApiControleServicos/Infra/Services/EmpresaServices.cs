using ApiControleServicos.Domain;
using ApiControleServicos.Domain.Models;

namespace ApiControleServicos.Infra
{
    public class EmpresaServices : IEmpresaServices
	{
		private readonly IEmpresaRepository _empresaRepository;

		public EmpresaServices(IEmpresaRepository empresaRepository)
		{
			_empresaRepository = empresaRepository;
		}

		public async Task Create(CreateEmpresaModel novaEmpresa)
		{
			EmpresaModel empresa = new(novaEmpresa.Nome, novaEmpresa.Cnpj, novaEmpresa.Cpf);
			await _empresaRepository.Create(empresa);
		}

		public async Task<List<EmpresaModel>> GetAll()
		{
			return await _empresaRepository.GetAll();
		}

		public async Task<EmpresaDto> GetById(int id)
		{
			return await _empresaRepository.GetByIdDto(id);
		}

		public async Task Update(UpdateEmpresaModel empresaNova)
		{
			var empresa = await _empresaRepository.GetById(empresaNova.Id);
			if (empresa.Id == 0)
				return;

			empresa.UpdateEmpresa(empresaNova.Nome, empresaNova.Cnpj, empresaNova.Cpf);
			_empresaRepository.Update(empresa);
		}
	}
}

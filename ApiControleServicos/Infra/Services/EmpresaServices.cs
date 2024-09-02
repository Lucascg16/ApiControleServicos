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

		public async Task<int> Create(CreateEmpresaModel novaEmpresa)
		{
			string normalizedCNPJ = "", normalizedCPF = "";

			if (novaEmpresa.Cnpj is not null)
				normalizedCNPJ = novaEmpresa.Cnpj.Replace(".", "").Replace("-", "").Replace("/","");

			if (novaEmpresa.Cpf is not null)
				normalizedCPF = novaEmpresa.Cpf.Replace(".", "").Replace("-", "");

			EmpresaModel empresa = new(novaEmpresa.Nome, normalizedCNPJ, normalizedCPF);
			return await _empresaRepository.Create(empresa);
		}

		public async Task<List<EmpresaModel>> GetAll()
		{
			return await _empresaRepository.GetAll();
		}

		public async Task<EmpresaDto> GetById(int id)
		{
			return await _empresaRepository.GetByIdDto(id);
		}

		public async Task<EmpresaDto> GetByName(string name)
		{
			return await _empresaRepository.GetByName(name);
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

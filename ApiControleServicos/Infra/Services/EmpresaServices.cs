using ApiControleServicos.Domain;
using ApiControleServicos.Domain.Models;
using ApiControleServicos.Infra.Interfaces;

namespace ApiControleServicos.Infra.Services
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

		public async Task<EmpresaModel> GetById(int id)
		{
			return await _empresaRepository.GetById(id);
		}

		public async Task Update(UpdateEmpresaModel empresaNova)
		{
			var empresa = await _empresaRepository.GetById(empresaNova.Id);
			empresa.UpdateEmpresa(empresaNova.Nome, empresaNova.Cnpj, empresaNova.Cpf);

			_empresaRepository.Update(empresa);
		}
	}
}

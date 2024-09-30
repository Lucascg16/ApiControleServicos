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
			EmpresaModel empresa = new(novaEmpresa.Nome, Ultilitarios.NormalizeCnpj(novaEmpresa.Cnpj), Ultilitarios.NormalizeCpf(novaEmpresa.Cpf));
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

			empresa.UpdateEmpresa(empresaNova.Nome, Ultilitarios.NormalizeCnpj(empresaNova.Cnpj), Ultilitarios.NormalizeCpf(empresaNova.Cpf));

            _empresaRepository.Update(empresa);
		}


	}
}

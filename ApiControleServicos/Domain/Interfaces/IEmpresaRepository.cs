using ApiControleServicos.Domain.Models;

namespace ApiControleServicos.Domain
{
	public interface IEmpresaRepository
	{
		Task Create(EmpresaModel empresa);
		Task<List<EmpresaModel>> GetAll();
		Task<EmpresaModel> GetById(int id);
		Task<EmpresaDto> GetByIdDto(int id);
		Task<EmpresaDto> GetByName(string name);
		void Update(EmpresaModel empresa);
	}
}

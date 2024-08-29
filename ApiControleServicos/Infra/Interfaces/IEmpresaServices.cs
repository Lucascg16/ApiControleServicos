using ApiControleServicos.Domain;
using ApiControleServicos.Domain.Models;

namespace ApiControleServicos.Infra
{
    public interface IEmpresaServices
	{
		Task Create(CreateEmpresaModel empresa);
		Task<List<EmpresaModel>> GetAll();
		Task<EmpresaDto> GetById(int id);
		Task<EmpresaDto> GetByName(string name);
		Task Update(UpdateEmpresaModel empresa);
	}
}

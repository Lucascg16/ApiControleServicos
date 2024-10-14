using ApiControleServicos.Domain;
using ApiControleServicos.Domain.Models;

namespace ApiControleServicos.Infra
{
    public interface IEmpresaServices
	{
		Task<int> Create(CreateEmpresaModel empresa);
		Task<List<EmpresaModel>> GetAll();
		Task<EmpresaDto> GetById(int id);
		Task<EmpresaDto> GetByName(string name);
		Task Update(UpdateEmpresaModel empresa);
		Task DesableAll(int id);
    }
}

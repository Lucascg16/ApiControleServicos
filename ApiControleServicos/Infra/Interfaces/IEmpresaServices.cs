using ApiControleServicos.Domain;
using ApiControleServicos.Domain.Models;

namespace ApiControleServicos.Infra
{
    public interface IEmpresaServices
	{
		Task Create(CreateEmpresaModel empresa);
		Task<List<EmpresaModel>> GetAll();
		Task<EmpresaDto> GetById(int id);
		Task Update(UpdateEmpresaModel empresa);
	}
}

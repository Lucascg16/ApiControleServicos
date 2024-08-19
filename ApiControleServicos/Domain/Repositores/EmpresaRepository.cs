using ApiControleServicos.Domain.Models;
using ApiControleServicos.Infra;

namespace ApiControleServicos.Domain
{
	public class EmpresaRepository : IEmpresaRepository
	{
		private readonly ApiDbContext _context;

		public EmpresaRepository(ApiDbContext context)
		{
			_context = context;
		}

		public async Task Create(EmpresaModel empresa)
		{
			await _context.Empresa.AddAsync(empresa);
			await _context.SaveChangesAsync();
		}

		public async Task<EmpresaModel> GetById(int id)
		{
			return await _context.Empresa.FindAsync(id) ?? new EmpresaModel();
		}

		public void Update(EmpresaModel empresa)
		{
			_context.Empresa.Update(empresa);
			_context.SaveChangesAsync();
		}
	}
}

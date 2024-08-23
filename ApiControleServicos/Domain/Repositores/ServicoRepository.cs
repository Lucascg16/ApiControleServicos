using ApiControleServicos.Domain.Models;
using ApiControleServicos.Infra;
using Microsoft.EntityFrameworkCore;

namespace ApiControleServicos.Domain
{
	public class ServicoRepository : IServicoRespository
	{
		private readonly ApiDbContext _context;

		public ServicoRepository(ApiDbContext context)
		{
			_context = context;
		}

		public async Task Create(ServicoModel servico)
		{
			await _context.Servicos.AddAsync(servico);
			await _context.SaveChangesAsync();
		}

		public List<ServicoModel> GetAllOpen()
		{
			return new List<ServicoModel>();
		}
		
		public async Task<List<ServicoModel>> GetAll()
		{
			return await _context.Servicos.ToListAsync() ?? [];//se nulo gera uma nova lista vazia
		}

		public async Task<ServicoModel> GetById(int Id)
		{
			return await _context.Servicos.FindAsync(Id) ?? new ServicoModel();
		}

		public void Update(ServicoModel servico)
		{
			_context.Servicos.Update(servico);
			_context.SaveChanges();
		}
	}
}

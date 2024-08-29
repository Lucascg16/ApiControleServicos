using ApiControleServicos.Domain.Models;
using ApiControleServicos.Infra;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace ApiControleServicos.Domain
{
	public class EmpresaRepository : IEmpresaRepository
	{
		private readonly ApiDbContext _context;
		private readonly IMapper _mapper;

		public EmpresaRepository(ApiDbContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		public async Task Create(EmpresaModel empresa)
		{
			await _context.Empresa.AddAsync(empresa);
			await _context.SaveChangesAsync();
		}

		public async Task<List<EmpresaModel>> GetAll()
		{
			return await _context.Empresa.ToListAsync();
		}

		public async Task<EmpresaDto> GetByIdDto(int id)
		{
			var empresa = await _context.Empresa.Where(x => x.Id == id).FirstOrDefaultAsync() ?? new();
			return _mapper.Map<EmpresaDto>(empresa);
		}

		public async Task<EmpresaModel> GetById(int id)
		{
			return await _context.Empresa.FindAsync(id) ?? new EmpresaModel();
		}

		public async Task<EmpresaDto> GetByName(string name)
		{
			var empresa = await _context.Empresa.FindAsync(name) ?? new EmpresaModel();
			return _mapper.Map<EmpresaDto>(empresa);
		}

		public void Update(EmpresaModel empresa)
		{
			_context.Empresa.Update(empresa);
			_context.SaveChangesAsync();
		}
	}
}

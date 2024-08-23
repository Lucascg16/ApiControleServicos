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

		public async Task<EmpresaDto> GetByIdDto(int id)
		{
			var empresa = await _context.Empresa.Where(x => x.Id == id).FirstOrDefaultAsync();
			return _mapper.Map<EmpresaDto>(empresa) ?? new EmpresaDto();
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

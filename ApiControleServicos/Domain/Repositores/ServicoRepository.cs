using ApiControleServicos.Domain.Models;
using ApiControleServicos.Infra;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace ApiControleServicos.Domain
{
	public class ServicoRepository : IServicoRespository
	{
		private readonly ApiDbContext _context;
		private readonly IMapper _mapper;

		public ServicoRepository(ApiDbContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		public async Task Create(ServicoModel servico)
		{
			await _context.Servicos.AddAsync(servico);
			await _context.SaveChangesAsync();
		}

		public async Task<int> GetTotalNumber(int empresaId, string flag)
		{
            return await _context.Servicos.Where(x => x.EmpresaId == empresaId && x.Flag == flag).CountAsync();
        }

        public async Task<List<ServicoDto>> GetAll(int empresaId, int page, int itensPerPage, string flag, string? nome)
		{
			var servicoList = await _context.Servicos.Where(x => x.EmpresaId == empresaId && x.Flag == flag)
									.Skip((page - 1) * itensPerPage)
									.Take(itensPerPage)
									.OrderByDescending(x => x.DataCriacao).ToListAsync() ?? [];

			if (!string.IsNullOrEmpty(nome))
			{
				servicoList = servicoList.Where(x => x.Nome.Contains(nome, StringComparison.CurrentCultureIgnoreCase)).ToList();
			}
			
			return _mapper.Map<List<ServicoDto>>(servicoList);
		}

		public async Task<ServicoDto> GetByIdDto(int Id)
		{
			var servico = await _context.Servicos.FindAsync(Id);
			return _mapper.Map<ServicoDto>(servico);
		}

		public async Task<ServicoModel> GetById(int Id)
		{
			return await _context.Servicos.FindAsync(Id) ?? new();
		}

		public void Update(ServicoModel servico)
		{
			_context.Servicos.Update(servico);
			_context.SaveChanges();
		}
	}
}

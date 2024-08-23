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

		public async Task<List<ServicoDto>> GetAllOpen(int emrpesaId, int page, int itensPerPage)
		{
			var servicoList = await _context.Servicos.Where(x => x.DataFinalizado == null && x.EmpresaId == emrpesaId && !x.Excluido)
									.Skip((page - 1) * itensPerPage).Take(itensPerPage).ToListAsync();

			List<ServicoDto> dtoList = [];
			foreach (var servico in servicoList) 
			{
				dtoList.Add(_mapper.Map<ServicoDto>(servico));//automapper, se der certo eu replico no metodo de baixo
			}

			return dtoList;
		}
		
		public async Task<List<ServicoDto>> GetAll(int emrpesaId, int page, int itensPerPage)
		{
			var servicoList = await _context.Servicos.Where(x => !x.Excluido && x.EmpresaId == emrpesaId)
									.Skip((page - 1) * itensPerPage).Take(itensPerPage).ToListAsync();

			List<ServicoDto> dtoList = [];
            foreach (var servico in servicoList)
            {
				dtoList.Add(_mapper.Map<ServicoDto>(servico));
            }

			return dtoList;
        }

		public async Task<ServicoDto> GetById(int Id)
		{
			var servico = await _context.Servicos.FindAsync(Id);
			return _mapper.Map<ServicoDto>(servico);
		}

		public void Update(ServicoModel servico)
		{
			_context.Servicos.Update(servico);
			_context.SaveChanges();
		}
	}
}

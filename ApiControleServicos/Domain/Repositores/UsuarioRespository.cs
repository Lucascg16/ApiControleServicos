using ApiControleServicos.Domain.Dto;
using ApiControleServicos.Domain.Models;
using ApiControleServicos.Infra;
using Microsoft.EntityFrameworkCore;

namespace ApiControleServicos.Domain
{
	public class UsuarioRespository : IUsuarioRepository
	{
		private readonly ApiDbContext _context;

		public UsuarioRespository (ApiDbContext context)
		{
			_context = context;
		}

		public async Task Create(UsuarioModel usuario)
		{
			await _context.Usuario.AddAsync(usuario);
			await _context.SaveChangesAsync();
		}

		public async Task<List<UsuarioDto>> GetAll(int empresaId, int page, int itensPerPage)
		{
			return await _context.Usuario.Where(x => !x.Excluido && x.EmpresaId == empresaId)
			.Skip((page - 1) * itensPerPage)
			.Take(itensPerPage)
			.Select(x => new UsuarioDto
			{
				Id = x.Id,
				Nome = x.Nome,
				Email = x.Email,
				EmpresaId = x.EmpresaId,
			}).ToListAsync();
		}

		public async Task<UsuarioDto> GetByIdDto(int id)
		{
			var pessoa = await _context.Usuario
				.Where(x => x.Id == id)
				.Select(x => new UsuarioDto //Dto: retorna apenas informacao util
				{
					Id = x.Id,
					Nome = x.Nome,
					Email = x.Email,
					EmpresaId = x.EmpresaId
				}).FirstOrDefaultAsync();

			return pessoa ?? new UsuarioDto();// se nulo retorna um dto vazio
		}

		public async Task<UsuarioModel> GetById(int id)
		{
			return await _context.Usuario.FindAsync(id) ?? new UsuarioModel();
		}

		public async Task<UsuarioDto> GetByName(string name)
		{
			var pessoa = await _context.Usuario.Where(x => x.Nome == name)
				.Select(x => new UsuarioDto
				{
					Id= x.Id,
					Nome = x.Nome,
					Email = x.Email,
					EmpresaId= x.EmpresaId,
				}).FirstOrDefaultAsync();

			return pessoa ?? new UsuarioDto();
		}

		public void Update(UsuarioModel usuario)
		{
			_context.Usuario.Update(usuario);
			_context.SaveChanges();
		}
	}
}

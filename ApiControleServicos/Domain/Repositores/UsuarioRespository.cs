using ApiControleServicos.Domain.Models;
using ApiControleServicos.Infra;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace ApiControleServicos.Domain
{
	public class UsuarioRespository : IUsuarioRepository
	{
		private readonly ApiDbContext _context;
		private readonly IMapper _mapper;

		public UsuarioRespository (ApiDbContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		public async Task Create(UsuarioModel usuario)
		{
			await _context.Usuario.AddAsync(usuario);
			await _context.SaveChangesAsync();
		}

		public async Task<int> GetAllNumber(int empresaId)
		{
			return await _context.Usuario.Where(x => x.EmpresaId == empresaId).CountAsync();
		}

		public async Task<List<UsuarioDto>> GetAll(int empresaId, int page, int itensPerPage)
		{
			List<UsuarioDto> Usuarios = [];
			var usuarioList = await _context.Usuario.Where(x => !x.Excluido && x.EmpresaId == empresaId)
									.Skip((page - 1) * itensPerPage).Take(itensPerPage).ToListAsync();

			if (usuarioList.Count == 0)
				return [];

			foreach (var usuario in usuarioList) 
			{
				Usuarios.Add(_mapper.Map<UsuarioDto>(usuario));
			}

			return Usuarios;
		}

		public async Task<UsuarioDto> GetByIdDto(int id)
		{
			var usuario = await _context.Usuario.Where(x => x.Id == id).FirstOrDefaultAsync();
			return _mapper.Map<UsuarioDto>(usuario) ?? new();
		}

		public async Task<UsuarioModel> GetById(Guid id)
		{
			return await _context.Usuario.FindAsync(id) ?? new();
		}

		public async Task<UsuarioModel> GetByUserName(string userName)
		{
			return await _context.Usuario.Where(x => x.Email == userName).FirstOrDefaultAsync() ?? new();
		}

		public async Task<UsuarioDto> GetByName(string name)
		{
			var usuario = await _context.Usuario.Where(x => x.Nome == name).FirstOrDefaultAsync();
			return _mapper.Map<UsuarioDto>(usuario) ?? new();
		}

		public void Update(UsuarioModel usuario)
		{
			_context.Usuario.Update(usuario);
			_context.SaveChanges();
		}
	}
}

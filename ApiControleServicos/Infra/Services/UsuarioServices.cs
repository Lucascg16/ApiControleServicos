using ApiControleServicos.Domain;
using ApiControleServicos.Domain.Dto;
using ApiControleServicos.Domain.Models;

namespace ApiControleServicos.Infra
{
	public class UsuarioServices : IUsuarioServices
	{
		private readonly IUsuarioRepository _usuarioRepository;

		public UsuarioServices(IUsuarioRepository usuarioRepository)
		{
			_usuarioRepository = usuarioRepository;
		}

		public async Task Create(CreateUsuarioModel novoUsuario)
		{
			UsuarioModel usuario = new(novoUsuario.Nome, novoUsuario.Email, novoUsuario.EmpresaId);
			await _usuarioRepository.Create(usuario);
		}

		public Task<List<UsuarioDto>> GetAll(int empresaId ,int page, int itensPerPage)
		{
			return _usuarioRepository.GetAll(empresaId ,page, itensPerPage);
		}

		public Task<UsuarioDto> GetById(int id)
		{
			return _usuarioRepository.GetByIdDto(id);
		}

		public Task<UsuarioDto> GetByName(string name)
		{
			return _usuarioRepository.GetByName(name);
		}

		public async Task Update(UpdateUsuarioModel usuarioNovo)
		{
			var usuario = await _usuarioRepository.GetById(usuarioNovo.Id);
			usuario.UpdateUsuario(usuarioNovo.Nome, usuarioNovo.Email);

			_usuarioRepository.Update(usuario);
		}
	}
}

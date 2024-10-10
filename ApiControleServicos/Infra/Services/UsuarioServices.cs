using ApiControleServicos.Domain;
using ApiControleServicos.Domain.Models;

namespace ApiControleServicos.Infra
{
	public class UsuarioServices : IUsuarioServices
	{
		private readonly IUsuarioRepository _usuarioRepository;
		private readonly ICriptoServices _criptoServices;

		public UsuarioServices(IUsuarioRepository usuarioRepository, ICriptoServices criptoServices)
		{
			_usuarioRepository = usuarioRepository;
			_criptoServices = criptoServices;
		}

		public async Task Create(CreateUsuarioModel novoUsuario)
		{
			UsuarioModel usuario = new(novoUsuario.Nome, novoUsuario.Email, _criptoServices.Criptografa(novoUsuario.Password),
									novoUsuario.Role, novoUsuario.EmpresaId, Guid.NewGuid());
			await _usuarioRepository.Create(usuario);
		}

		public async Task<int> GetAllNumber(int empresaId)
		{
			return await _usuarioRepository.GetAllNumber(empresaId);
		}

		public Task<List<UsuarioDto>> GetAll(int empresaId, int page, int itensPerPage)
		{
			return _usuarioRepository.GetAll(empresaId, page, itensPerPage);
		}

		public Task<UsuarioDto> GetById(Guid id)
		{
			return _usuarioRepository.GetByIdDto(id);
		}

		public Task<UsuarioDto> GetByName(string name)
		{
			return _usuarioRepository.GetByName(name);
		}

		public Task<UsuarioModel> GetByUserName(string username)
		{
			return _usuarioRepository.GetByUserName(username);
		}

		public async Task Update(UpdateUsuarioModel usuarioNovo)
		{
			var usuario = await _usuarioRepository.GetById(usuarioNovo.Id);
			usuario.UpdateUsuario(usuarioNovo.Nome, usuarioNovo.Email);
            usuario.UpdateRole(usuarioNovo.Role);

            _usuarioRepository.Update(usuario);
		}

		public async Task UpdateSenha(int id, string senha)
		{
			var usuario = await _usuarioRepository.GetById(id);
			usuario.UpdateSenha(_criptoServices.Criptografa(senha));

			_usuarioRepository.Update(usuario);
		}

		public async Task Delete(int id)
		{
			var usuario = await _usuarioRepository.GetById(id);
			usuario.Delete();//delete logico

			_usuarioRepository.Update(usuario);//não apaga somente atualiza a flag
		}
	}
}

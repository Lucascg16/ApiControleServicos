using ApiControleServicos.Domain;
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
			UsuarioModel usuario = new(novoUsuario.Nome, novoUsuario.Email, CriptoServices.Criptografa(novoUsuario.Password),
									novoUsuario.Role, novoUsuario.EmpresaId, Guid.NewGuid(), novoUsuario.Dono);
			await _usuarioRepository.Create(usuario);
		}

		public async Task<int> GetAllNumber(int empresaId)
		{
			return await _usuarioRepository.GetAllNumber(empresaId);
		}

		public Task<List<UsuarioDto>> GetAll(int empresaId, int page, int itensPerPage, string nome)
		{
			return _usuarioRepository.GetAll(empresaId, page, itensPerPage, nome);
		}

		public Task<UsuarioDto> GetById(int id)
		{
			return _usuarioRepository.GetByIdDto(id);
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

		public async Task UpdateSenha(int id, string senha, string novaSenha)
		{
			var usuario = await _usuarioRepository.GetById(id);

			if (usuario.Id == 0)
				throw new("Usuário não encontrado");
			if (string.IsNullOrEmpty(senha))
				throw new("A senha atual deve ser preenchida");
            if (usuario.Password != CriptoServices.Criptografa(senha))
				throw new("A senha digitada não confere com a senha atual");

            usuario.UpdateSenha(CriptoServices.Criptografa(novaSenha));

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

using ApiControleServicos.Domain.Models;

namespace ApiControleServicos.Infra
{
	public interface ITokenServices
	{
		string GenerateToken(UsuarioModel usuario, int expires = 2);
	}
}

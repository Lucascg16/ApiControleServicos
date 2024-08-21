using System.ComponentModel.DataAnnotations;

namespace ApiControleServicos.Domain
{
	public class CreateUsuarioModel
	{
		[Required]
		public string Nome { get; set; } = string.Empty;
		[Required]
		[EmailAddress]
		public string Email { get; set; } = string.Empty;
		[Required]
		public int EmpresaId { get; set; }
	}
}

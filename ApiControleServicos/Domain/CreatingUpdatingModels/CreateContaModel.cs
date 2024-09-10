using System.ComponentModel.DataAnnotations;

namespace ApiControleServicos.Domain
{
	public class CreateContaModel
	{
		[Required]
		public CreateEmpresaModel Empresa { get; set; } = new();
		[Required]
		public CreateUsuarioModel Usuario { get; set; } = new();
	}
}

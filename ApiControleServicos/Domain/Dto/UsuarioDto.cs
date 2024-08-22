namespace ApiControleServicos.Domain
{
	public class UsuarioDto
	{
		public int Id { get; set; }
		public string? Nome { get; set; }
		public string? Email { get; set; }
		public int EmpresaId { get; set; }
	}
}

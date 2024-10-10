namespace ApiControleServicos.Domain
{
	public record UsuarioDto
	{
		public int Id { get; set; }
		public Guid VId { get; set; }
		public string? Nome { get; set; }
		public string? Email { get; set; }
		public string Role { get; set; } = "none";
		public int EmpresaId { get; set; }
	}
}

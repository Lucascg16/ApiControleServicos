namespace ApiControleServicos.Domain
{
	public record UsuarioDto
	{
		public int Id { get; set; }
		public Guid VId { get; set; }
		public string? Nome { get; set; }
		public string? Email { get; set; }
		public UserRoleEnum Role { get; set; } = UserRoleEnum.None;
		public int EmpresaId { get; set; }
		public bool Dono {  get; set; }
	}
}

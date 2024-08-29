﻿using System.ComponentModel.DataAnnotations;

namespace ApiControleServicos.Domain
{
	public record CreateUsuarioModel
	{
		[Required]
		public string Nome { get; set; } = string.Empty;
		[Required]
		[EmailAddress]
		public string Email { get; set; } = string.Empty;
		[Required]
		public string Password {  get; set; } = string.Empty;
		[Required]
		public string Role { get; set; } = "none";
		[Required]
		public int EmpresaId { get; set; }
	}
}

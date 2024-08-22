﻿using System.ComponentModel.DataAnnotations;

namespace ApiControleServicos.Domain
{
	public class UpdateUsuarioModel
	{
		[Required]
		public int Id { get; set; }
		[Required]
		public string Nome { get; set; } = string.Empty;
		[Required]
		[EmailAddress]
		public string Email { get; set; } = string.Empty;
		[Required]
		public int EmpresaId { get; set; }
	}
}
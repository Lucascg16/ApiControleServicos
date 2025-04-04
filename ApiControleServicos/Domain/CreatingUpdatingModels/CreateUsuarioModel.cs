﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

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
		[DefaultValue("none")]
		public UserRoleEnum Role { get; set; } =  UserRoleEnum.None;
		[DefaultValue(0)]
		public int EmpresaId { get; set; }
		[DefaultValue(false)]
		public bool Dono { get; set; }
	}
}

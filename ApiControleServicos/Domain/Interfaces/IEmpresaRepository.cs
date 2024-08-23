﻿using ApiControleServicos.Domain.Models;

namespace ApiControleServicos.Domain
{
	public interface IEmpresaRepository
	{
		Task Create(EmpresaModel empresa);
		Task<EmpresaModel> GetById(int id);
		Task<EmpresaDto> GetByIdDto(int id);
		void Update(EmpresaModel empresa);
	}
}

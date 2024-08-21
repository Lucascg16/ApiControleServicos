﻿using ApiControleServicos.Domain;
using ApiControleServicos.Domain.Models;

namespace ApiControleServicos.Infra.Interfaces
{
    public interface IEmpresaServices
	{
		Task Create(CreateEmpresaModel empresa);
		Task<EmpresaModel> GetById(int id);
		Task Update(UpdateEmpresaModel empresa);
	}
}

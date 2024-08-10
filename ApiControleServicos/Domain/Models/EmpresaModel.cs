using System.ComponentModel.DataAnnotations.Schema;

namespace ApiControleServicos.Domain.Models
{
    [Table("Empresa")]
    public class EmpresaModel : ModelBase
    {
        public string? Nome { get; set; }
        public string? Cnpj { get; set; }
        public string? Cpf { get; set; }

        public EmpresaModel() 
        {
            Nome = string.Empty;
            Cnpj = string.Empty;
            Cpf = string.Empty;
        }

        public EmpresaModel(string nome, string? cnpj, string? cpf) 
        {
            Nome = nome;
            Cnpj = cnpj;
            Cpf = cpf;
        }

        public static EmpresaModel Create(string nome, string? cnpj, string? cpf) =>
            new(nome: nome, cnpj:cnpj, cpf:cpf);

        public void Delete()
        {
            Excluir();
        }
    }
}

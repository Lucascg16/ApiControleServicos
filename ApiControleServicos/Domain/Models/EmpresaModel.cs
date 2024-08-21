namespace ApiControleServicos.Domain.Models
{
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

        public void UpdateEmpresa(string nome, string? cnpj, string? cpf)
        {
            Nome = nome;
            Cnpj = cnpj;
            Cpf = cpf;
            Atualizar();
        }

        public void Delete()
        {
            Excluir();
        }
    }
}

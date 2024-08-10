using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiControleServicos.Domain.Models
{
    [Table("Pessoa")]//TODO: remover isso quando criar o configuration
    public class PessoasModel : ModelBase
    {
        public string? Nome { get; set; }//TODO: Add mensagens de erro quando necessario
        public string? Sobrenome { get; set; }
        public string? Email { get; set; }
        public int EmpresaId { get; set; }

        public PessoasModel()
        {
            Nome = string.Empty;
            Sobrenome = string.Empty;
            Email = string.Empty;
        }

        private PessoasModel(string nome, string sobrenome, string email, int empresaId)
        {
            Nome = nome;
            Sobrenome = sobrenome;
            Email = email;
            EmpresaId = empresaId;
        }

        public static PessoasModel Create(string nome, string sobrenome, string email, int empresaId) => 
            new (nome: nome, sobrenome: sobrenome, email: email, empresaId:empresaId);

        public void Delete()
        {
            Excluir();
        }
    }
}

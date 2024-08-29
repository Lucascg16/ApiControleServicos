namespace ApiControleServicos.Domain.Models
{
    public class UsuarioModel : ModelBase
    {
        public string? Nome { get; set; }//TODO: Add mensagens de erro quando necessario
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? Role { get; set; }
        public int EmpresaId { get; set; }

        public UsuarioModel()
        {
            Nome = string.Empty;
            Email = string.Empty;
            Password = string.Empty;
            Role = "none";
        }

        public UsuarioModel(string nome, string email, string passWord, string role, int empresaId)
        {
            Nome = nome;
            Email = email;
            Password = passWord;
            Role = role;
            EmpresaId = empresaId;
        }

        public void UpdateUsuario(string nome, string email)
        {
            Nome = nome;
            Email = email;
            Atualizar();
        }

        public void UpdateSenha(string pass)
        {
            Password = pass;
            Atualizar();
        }

        public void UpdateRole(string role) 
        {
            Role = role;
        }

        public void Delete()
        {
            Excluir();
        }
    }
}

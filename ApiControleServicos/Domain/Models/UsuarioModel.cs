namespace ApiControleServicos.Domain.Models
{
    public class UsuarioModel : ModelBase
    {
        public string? Nome { get; set; }//TODO: Add mensagens de erro quando necessario
        public string? Email { get; set; }
        public string? Password { get; set; }
        public RoleEnum Role { get; set; }
        public int EmpresaId { get; set; }

        public UsuarioModel()
        {
            Nome = string.Empty;
            Email = string.Empty;
            Password = string.Empty;
            Role = RoleEnum.None;
        }

        public UsuarioModel(string nome, string email, string passWord, int empresaId)
        {
            Nome = nome;
            Email = email;
            Password = passWord;
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

        public void UpdateRole(RoleEnum role) 
        {
            Role = role;
        }

        public void Delete()
        {
            Excluir();
        }
    }
}

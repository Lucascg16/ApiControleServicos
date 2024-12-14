# Api RestFull desenvolvida para controle de serviços

## Configs necessárias
### A Api usa o token JWT e banco de dados Sql Server

As configurações podem ser encontradas no arquivo AppSettings.json, a versão normal dele (não a dev)
<br><br>Config de geração do Token:
  * Secret: Pode colocar qualquer coisa nele, mas é recomendável um codigo que seja forte e difícil de saber (como um hash sha256)
  * Issuer: Pode ser colocado qualquer coisa ali
  * Audience: Tambem pode ser colocado qualquer coisa ali

Para as configs de banco:
 * É necessário apenas a string de conexção para que o sistema possa acessar o banco de dados local ou remóto
 * Não é necessário pre criar o banco e as tabelas, pois o sistema roda um comando que cria o banco, as tabelas e roda as migrations caso esteja desatualizado

A Api usa Swagger para vizualizaçao podendo ser acessada na url indicada pelo sistema ao subir a api + /swagger/index.html.

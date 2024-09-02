using System.Security.Cryptography;
using System.Text;

namespace ApiControleServicos.Infra
{
	public class CriptoServices : ICriptoServices
	{
		public string Criptografa(string input)
		{
			SHA256 sHA256 = SHA256.Create();
			byte[] inputBytes = Encoding.ASCII.GetBytes(input);
			byte[] hash = sHA256.ComputeHash(inputBytes);

			StringBuilder hashString = new StringBuilder();

			foreach (byte b in hash)
			{
				hashString.Append(b.ToString("X2"));
			}
			return hashString.ToString();
		}
	}
}

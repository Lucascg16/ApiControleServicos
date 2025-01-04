using ApiControleServicos.Domain.Models;
using System.Security.Cryptography;
using System.Text;

namespace ApiControleServicos.Infra
{
	public static class CriptoServices
    {
        private static readonly string Key = ConfigurationHelperModel.Configuration?.GetSection("CriptoSettings")["Key"] ?? throw new("A Key deve ser preenchida, verifique o appsettings");
        private static readonly string Iv = ConfigurationHelperModel.Configuration?.GetSection("CriptoSettings")["IV"] ?? throw new("A IV deve ser preenchida, verifique o appsettings");

        public static string Criptografa(string input)
		{
            using Aes aes = Aes.Create();
            aes.Key = Encoding.UTF8.GetBytes(Key);
            aes.IV = Encoding.UTF8.GetBytes(Iv);

            using MemoryStream ms = new();
            using (CryptoStream cs = new(ms, aes.CreateEncryptor(), CryptoStreamMode.Write))
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(input);
                cs.Write(inputBytes, 0, inputBytes.Length);
                cs.FlushFinalBlock();
            }
            return Convert.ToBase64String(ms.ToArray());
        }

        public static string Descriptografa(string textoCriptografado)
        {
            try
            {
                using Aes aes = Aes.Create();
                aes.Key = Encoding.UTF8.GetBytes(Key);
                aes.IV = Encoding.UTF8.GetBytes(Iv);

                using MemoryStream ms = new();
                using (CryptoStream cs = new(ms, aes.CreateDecryptor(), CryptoStreamMode.Write))
                {
                    byte[] inputBytes = Convert.FromBase64String(textoCriptografado);
                    cs.Write(inputBytes, 0, inputBytes.Length);
                    cs.FlushFinalBlock();
                }
                return Encoding.UTF8.GetString(ms.ToArray());
            }
            catch
            {
                return textoCriptografado;
            }
        }
    }
}

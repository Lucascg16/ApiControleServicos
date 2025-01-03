using System.Security.Cryptography;
using System.Text;

namespace ApiControleServicos.Infra
{
	public static class CriptoServices
    {        
        public static string Criptografa(string input, IConfiguration config)
		{
            var key = config.GetSection("CriptoSettings")["Key"];
            var IV = config.GetSection("CriptoSettings")["IV"];

            using Aes aes = Aes.Create();
            aes.Key = Encoding.UTF8.GetBytes(string.IsNullOrEmpty(key) ? throw new Exception("A Key deve ser preenchida, verifique o appsettings") : key);
            aes.IV = Encoding.UTF8.GetBytes(string.IsNullOrEmpty(IV) ? throw new Exception("A IV deve ser preenchida, verifique o appsettings") : IV);

            using MemoryStream ms = new();
            using (CryptoStream cs = new(ms, aes.CreateEncryptor(), CryptoStreamMode.Write))
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(input);
                cs.Write(inputBytes, 0, inputBytes.Length);
                cs.FlushFinalBlock();
            }
            return Convert.ToBase64String(ms.ToArray());
        }

        public static string Descriptografar(string textoCriptografado, IConfiguration _config)
        {
            var key = _config.GetSection("CriptoSettings")["Key"];
            var IV = _config.GetSection("CriptoSettings")["IV"];

            try
            {
                using Aes aes = Aes.Create();
                aes.Key = Encoding.UTF8.GetBytes(string.IsNullOrEmpty(key) ? throw new Exception("A Key deve ser preenchida, verifique o appsettings") : key);
                aes.IV = Encoding.UTF8.GetBytes(string.IsNullOrEmpty(IV) ? throw new Exception("A IV deve ser preenchida, verifique o appsettings") : IV);

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

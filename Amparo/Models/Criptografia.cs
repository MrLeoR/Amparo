using System;
using System.Security.Cryptography;
using System.Text;

namespace Amparo.Aplicacao.Models
{
    public class Criptografia : IDisposable
    {
        private readonly SHA256 hasher;

        public Criptografia()
        {
            hasher = SHA256.Create();
        }

        public string GetHash(string value)
        {
            var inputBuffer = Encoding.Unicode.GetBytes(value);
            var hashBytes = hasher.ComputeHash(inputBuffer);

            return Convert.ToBase64String(hashBytes);
        }

        public void Dispose()
        {
            hasher.Dispose();
        }
    }
}

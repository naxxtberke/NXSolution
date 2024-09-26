using NX.Libs.EncryptionLib.Interfaces;
using System.Security.Cryptography;
using System.Text;

namespace NX.Libs.EncryptionLib.Services
{
    public class AesEncryptionService : IEncryptionService
    {
        private readonly string _key;
        private readonly string _iv;

        public AesEncryptionService(string key, string iv)
        {
            _key = key;
            _iv = iv;
        }

        public string Encrypt(string plainText)
        {
            using Aes aesAlg = Aes.Create();
            aesAlg.Key = Encoding.UTF8.GetBytes(_key);
            aesAlg.IV = Encoding.UTF8.GetBytes(_iv);

            ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);
            using MemoryStream msEncrypt = new();
            using CryptoStream csEncrypt = new(msEncrypt, encryptor, CryptoStreamMode.Write);
            using StreamWriter swEncrypt = new(csEncrypt);
            swEncrypt.Write(plainText);
            return Convert.ToBase64String(msEncrypt.ToArray());
        }

        public string Decrypt(string cipherText)
        {
            using Aes aesAlg = Aes.Create();
            aesAlg.Key = Encoding.UTF8.GetBytes(_key);
            aesAlg.IV = Encoding.UTF8.GetBytes(_iv);

            ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);
            using MemoryStream msDecrypt = new(Convert.FromBase64String(cipherText));
            using CryptoStream csDecrypt = new(msDecrypt, decryptor, CryptoStreamMode.Read);
            using StreamReader srDecrypt = new(csDecrypt);
            return srDecrypt.ReadToEnd();
        }
    }
}

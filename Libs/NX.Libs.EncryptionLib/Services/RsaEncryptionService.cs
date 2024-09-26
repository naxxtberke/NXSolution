using NX.Libs.EncryptionLib.Interfaces;
using System.Security.Cryptography;
using System.Text;

namespace NX.Libs.EncryptionLib.Services
{
    public class RsaEncryptionService : IEncryptionService
    {
        private readonly RSA _rsa;

        public RsaEncryptionService(string publicKey, string privateKey)
        {
            _rsa = RSA.Create();
            _rsa.FromXmlString(privateKey); // Özel anahtar ile yükleme yapabilirsiniz
        }

        public string Encrypt(string plainText)
        {
            byte[] data = Encoding.UTF8.GetBytes(plainText);
            byte[] encryptedData = _rsa.Encrypt(data, RSAEncryptionPadding.Pkcs1);
            return Convert.ToBase64String(encryptedData);
        }

        public string Decrypt(string cipherText)
        {
            byte[] data = Convert.FromBase64String(cipherText);
            byte[] decryptedData = _rsa.Decrypt(data, RSAEncryptionPadding.Pkcs1);
            return Encoding.UTF8.GetString(decryptedData);
        }
    }
}

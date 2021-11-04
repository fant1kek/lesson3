using System.Security.Cryptography;
using System.Text;
using converter;

namespace hMACGenerate
{
    class HMACGenerator
    {
        public byte[] KeyGenerate()
        {
            RNGCryptoServiceProvider random = new RNGCryptoServiceProvider();
            byte[] secretKey = new byte[16];
            random.GetBytes(secretKey);
            return secretKey;
        }
        public string GenerateHmacWithMove(string muve, byte[] secretKey)
        {
            Converter converter = new Converter();
            HMACSHA256 SHA256 = new HMACSHA256(Encoding.Default.GetBytes(converter.BytesToHex(secretKey)));
            return converter.BytesToHex(SHA256.ComputeHash(Encoding.Default.GetBytes(muve)));
        }
    }
}

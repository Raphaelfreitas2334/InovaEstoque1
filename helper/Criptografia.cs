using Org.BouncyCastle.Crypto.Digests;
using System.Text;

namespace WebApplication1.helper
{
    public static class Criptografia
    {
        public static string GerarHash(this string valor)
        {
            var hash = new Sha3Digest(256); // SHA-3 com 256 bits de tamanho de saída
            var encoding = new ASCIIEncoding();
            var array = encoding.GetBytes(valor);

            hash.BlockUpdate(array, 0, array.Length);

            var hashBytes = new byte[hash.GetDigestSize()];
            hash.DoFinal(hashBytes, 0);

            var strHexa = new StringBuilder();

            foreach (var item in hashBytes)
            {
                strHexa.Append(item.ToString("x2"));
            }

            return strHexa.ToString();
        }
    }
}

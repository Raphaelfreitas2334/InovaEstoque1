using System.Security.Cryptography;
using System.Text;

namespace WebApplication1.helper
{
    public static class Criptografia
    {
        public static string GerarHash(this string valor)
        {
            var hash = SHA1.Create();
            var enconding = new ASCIIEncoding();
            //aqui esta pegando os  bytes dos números da senha
            var array = enconding.GetBytes(valor);

            array = hash.ComputeHash(array);

            var strHexa = new StringBuilder();

            foreach (var item in array)
            {
                strHexa.Append(item.ToString("x2"));
            }

            return strHexa.ToString();
        }
    }
}

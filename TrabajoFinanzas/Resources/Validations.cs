using Microsoft.EntityFrameworkCore.Query.Internal;
using System.Security.Cryptography;
using System.Text;

namespace TrabajoFinanzas.Resources;

public class Validations
{
    public static string EncryptKey(string key)
    {
        StringBuilder sb = new StringBuilder();
        using (SHA256 hash = SHA256.Create())
        {
            Encoding enc = Encoding.UTF8;
            
            byte[] result = hash.ComputeHash(enc.GetBytes(key));
            
            foreach (byte b in result)
            {
                sb.Append(b.ToString("x2"));
            }
            
            return sb.ToString();
        }
    }
}
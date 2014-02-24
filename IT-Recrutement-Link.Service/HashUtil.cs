using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
namespace IT_Recrutement_Link.Service
{
    class HashUtil
    {
        public static string SHA1Hash(string input)
        {
            using (SHA1Managed hasher = new SHA1Managed())
            {

                byte[] textData = Encoding.UTF8.GetBytes(input);
                byte[] hash = hasher.ComputeHash(textData);
                return BitConverter.ToString(hash).Replace("-", String.Empty).ToLower();
            }
        }
    }
}

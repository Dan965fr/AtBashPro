using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace atbash
{
    internal class Program
    {
        static string AtbashDecrypt(string encryptedmassage)
        {
            encryptedmassage = encryptedmassage.Replace("\n", " \n ");
            string decrypted = "";
            foreach (char c in encryptedmassage)
            {
                if (char.IsLetter(c))
                {
                    if (char.IsUpper(c))
                    {
                        decrypted += (char)('A' + ('Z' - c));
                    }
                    else
                    {
                        decrypted += (char)('a' + ('z' - c));
                    }

                }
                else
                {
                    decrypted += c;
                }
            }
            return decrypted;
        }
        static void Main(string[] args)
        {


        }

    }
}


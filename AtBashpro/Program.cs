using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
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

        static string SuspiciousWords(string dmes)
        {
            string[] listMess = dmes.Split(' ');
            string[] dangerWords = { "bomb", "nukhba", "fighter", "rocket", "secret" };
            string dwords = "";
            foreach (string word in dangerWords)
            {
                if (listMess.Any(w => w.Trim().TrimEnd('s') == word))
                    dwords += word + " ";
            }

                ;
            return dwords;
        }

        static int CountSuspiciousWords(string dmes)
        {
            int point = 0;
            string[] listMess = dmes.Split(new[] { ' ', '\n', '\r', '\t' }, StringSplitOptions.RemoveEmptyEntries); string[] dangerWords = { "bomb", "nukhba", "fighter", "rocket", "secret" };
            foreach (string word in listMess)
            {
                string cleanWord = word.TrimEnd('s');
                if (dangerWords.Contains(cleanWord))
                    point += 1;
            }

            return point;
        }

        static void DecodeCipher(string message)
        {
            string lowmes = message.ToLower();
            string decryptMesseage = AtbashDecrypt(lowmes);
            int point = CountSuspiciousWords(decryptMesseage);
            string suspicionsWords = SuspiciousWords(decryptMesseage);
            if (point == 0)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("No sespicions words");
            }
            else if (point <= 5)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("WARNING");
                Console.ResetColor();

            }
            else if (point <= 10)
            {
                Console.WriteLine("DANGER");
                Console.ResetColor();

            }
            else if (point <= 15)
            {
                Console.WriteLine("ULTRA ALERT");
                Console.ResetColor();
            }

            Console.WriteLine($"Message : {decryptMesseage}");
            Console.WriteLine($"Points : {point}");
            Console.WriteLine($"Dangers words : {suspicionsWords}");

        }

        static void Main(string[] args)
        {
            string decryptesMesseage = "Lfi ulixvh ziv kivkzirmt uli z nzqli zggzxp lm gsv Arlmrhg vmvnb.\nGsv ilxpvg fmrgh ziv ivzwb zmw dzrgrmt uli gsv hrtmzo.\nYlnyh szev yvvm kozxvw mvzi pvb olxzgrlmh.\nMfpsyz urtsgvih ziv hgzmwrmt yb uli tilfmw rmurogizgrlm.\nGsv zggzxp droo yv hfwwvm zmw hgilmt -- gsvb dlm’g hvv rg xlnrmt.\nDv nfhg hgzb srwwvm zmw pvvk gsv kozm hvxivg fmgro gsv ozhg nlnvmg.\nErxglib rh mvzi. Hgzb ivzwb.";
            DecodeCipher(decryptesMesseage);

        }

    }

}


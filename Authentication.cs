using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOFA
{

    public class Authentication
    {

        public static void HoldMain()
        {
            /*
            Console.Write("Enter the username : ");
            string username = Console.ReadLine();
            Console.Write("Enter the Password: ");
            string password = Console.ReadLine();

            var result = HasContainDictionaryWord(username, password);
            if(result)
            {
                Console.WriteLine("password contains the dictionary words");
                return;
            }
            Console.WriteLine("password does not contains the dictionary words");
            */
            string str1 = "anith";
            string str2 = "anith";
            Console.WriteLine(str1.Contains(str2));
            Console.ReadLine();
        }
        public static bool HasContainDictionaryWord(string username, string password)
        {
            password =  password.ToLower();
            var dictionaryWords = new List<string> { "apple", "banana", "hello", "open", "123", "sunshine", username };
            foreach (var word in dictionaryWords)
            {
                if (password.Contains(word))
                {
                    return true;
                }
            }
            return false;
        }
    }
}

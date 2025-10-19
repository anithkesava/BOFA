using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOFA
{
    public class HPS
    {
        public static void Main()
        {
            string input = "anith";
            var output = ReverseString(input);
            Console.WriteLine(output);
            Console.ReadLine();
        }

        public static string ReverseString(string str)
        {
            string reverseString = "";
            for (int i = str.Length - 1; i >= 0; i--)
            {
                reverseString += str[i];
            }
            return reverseString;
        }
    }
}

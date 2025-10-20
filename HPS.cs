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
            /*
            string input = "anith";
            var output = ReverseString(input);
            Console.WriteLine(output);
            */
            Console.WriteLine(ReverseNumber(123));
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

        public static long ReverseNumber(long num)
        {
            /*
            while, Reverse a number remember this 
             - divided by 10 removes the last digit.
             - module by 10 get the last number. 

             */
            //assume the number, 123
            long reversed = 0;
            while(num!=0)
            {
                var rem = num % 10;
                reversed = (reversed * 10) + rem;
                num /= 10;
            }

            return reversed;
        }
    }
}

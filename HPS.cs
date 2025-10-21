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
            Console.WriteLine(ReverseNumber(123));
            Console.Write("Enter the String: ");
            var s = Console.ReadLine();
            Console.WriteLine(HasAllUniqueCharacters(s));

            
            string str1 = "abc";
            string str2 = "bbc";
            var result = IsPermutation(str1, str2);
            Console.WriteLine(result);

            string url = "Mr John Smith  ";
            Console.WriteLine(URLify(url));

            string cardno = "1234567891011121";
            Console.WriteLine(MaskCardNumber(cardno));
            */

            Console.WriteLine(TransactionID());
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
            long reversed = 0;
            while (num != 0)
            {
                var rem = num % 10;
                reversed = (reversed * 10) + rem;
                num /= 10;
            }
            return reversed;
        }
        public static bool HasAllUniqueCharacters(string str)
        {
            var set = new HashSet<char>();
            foreach (var s in str)
            {
                if (!set.Add(s))
                    return false;
            }
            return true;
        }
        public static bool IsPermutation(string str1, string str2)
        {
            if (str1.Length != str2.Length)
                return false;
            var dictionary1 = new Dictionary<char, int>();
            var dictionary2 = new Dictionary<char, int>();
            dictionary1 = str1.GroupBy(x => x).ToDictionary(g => g.Key, g => g.Count());
            dictionary2 = str2.GroupBy(x => x).ToDictionary(g => g.Key, g => g.Count());
            if (dictionary1.Count() != dictionary2.Count())
                return false;
            foreach (var d in dictionary1)
            {
                if (!dictionary2.ContainsKey(d.Key) || dictionary2[d.Key] != d.Value)
                    return false;
            }
            return true;
        }
        public static string URLify(string url)
        {
            return url.TrimEnd().Replace(" ", "%20");
        }
        public static string MaskCardNumber(string cardno)
        {
            if (cardno.Length != 16)
                throw new ArgumentException("invalid card number");
            string masked = new string('*', cardno.Length - 4) + cardno[^4..];
            return masked;
        }
        public static string TransactionID()
        {
            var alpha = Enumerable.Range('A', 26).Select(x => (char)x).ToList();
            var numeric = Enumerable.Range(1, 100).ToList();
            var seen = new HashSet<string>();
            var random = new Random();

            string generatedID = DateTime.Now.ToShortTimeString() + alpha[random.Next(alpha.Count)]
                + numeric[random.Next(numeric.Count)];

            while(seen.Contains(generatedID))
            {
                generatedID = DateTime.Now.ToShortTimeString() + alpha[random.Next(alpha.Count)]
                                + numeric[random.Next(numeric.Count)];
                seen.Add(generatedID);
            }
            
            return generatedID;
        }
    }
}

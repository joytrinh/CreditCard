using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditCard
{
    class Program
    {
        static void Main(string[] args)
        {
            string value;
            long number;
            Console.WriteLine("Please input your credit card number: ");
            value = Console.ReadLine();
            if (long.TryParse(value, out number))
            {
                List<int> num = new List<int>();
                for (int i = 0; i < value.Length; i++)
                {
                    num.Add(int.Parse(value[i].ToString()));
                }
                int[] arr = num.ToArray();
                int checksum = 0;
                for (int i = arr.Length - 2; i >= 0;)
                {
                    int n = arr[i]*2;
                    if (n < 10)
                        checksum += n;
                    else
                    {
                        string s = n.ToString();
                        checksum += int.Parse(s[0].ToString()) + int.Parse(s[1].ToString());
                    }
                    i -= 2;
                }
                for (int i = arr.Length - 1; i >= 0;)
                {
                    int m = int.Parse(arr[i].ToString());
                    checksum += m;
                    i -= 2;
                }
                string stringOfChecksum = checksum.ToString();
                if (stringOfChecksum[stringOfChecksum.Length - 1].ToString() == "0")
                {
                    if (value.Length == 15 && value[0].ToString() == "3" && (value[1].ToString() == "4" || value[1].ToString() == "7"))
                    {
                        Console.WriteLine("This is a valid Amex card.");
                    }
                    if (value.Length == 16 && value[0].ToString() == "5" && (value[1].ToString() == "1" || value[1].ToString() == "2" || value[1].ToString() == "3" || value[1].ToString() == "4" || value[1].ToString() == "5"))
                    {
                        Console.WriteLine("This is a valid MasterCard.");
                    }
                    if ((value.Length == 13 || value.Length == 16) && value[0].ToString() == "4")
                    {
                        Console.WriteLine("This is a valid Visa card.");
                    }                    
                }                    
                else
                    Console.WriteLine("The credit card is INVALID.");
            }                
            else
                Console.WriteLine("Unable to parse '{0}'", value);
            Console.ReadLine();
        }
    }
}

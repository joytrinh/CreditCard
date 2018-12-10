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
                char[] arr = value.ToArray();
                int checksum = 0;
                for (int i = 1; i <= arr.Length;)
                {
                    //I want to convert from char to int
                    int n = (int)arr[i];
                    if (n * 2 < 10)
                        checksum += n * 2;
                    else
                    {
                        char[] s = n.ToString().ToArray();
                        checksum += (int)s[0] + (int)s[1];
                    }
                    i += 2;
                }
                for (int i = 0; i < value.Length;)
                {
                    int n = (int)arr[i];
                    checksum += n;
                    i += 2;
                }
                char[] stringOfChecksum = checksum.ToString().ToArray();
                if (stringOfChecksum[1] == 0)
                    Console.WriteLine("The credit card is valid.");
                else
                    Console.WriteLine("The credit card is INVALID.");
            }                
            else
                Console.WriteLine("Unable to parse '{0}'", value);

            //Starting at second to last digit, multiply every other digit by 2
            
        }
    }
}

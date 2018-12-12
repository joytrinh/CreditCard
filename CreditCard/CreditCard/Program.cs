using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

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
                int checksum = 0;
                for (int l = value.Length, i = l - 2; i >= 0;)
                {
                    int n = int.Parse(value[i].ToString())*2;
                    if (n < 10)
                        checksum += n;
                    else //n >= 10 or n has more than 1 digit
                    {
                        string s = n.ToString();//We convert from int to string to get an array of chars
                        //so that we can get each element of that array
                        checksum += int.Parse(s[0].ToString()) + int.Parse(s[1].ToString());
                    }
                    i -= 2;
                }
                for (int l = value.Length, i = l - 1; i >= 0;)
                {
                    int m = int.Parse(value[i].ToString());
                    checksum += m;
                    i -= 2;
                }
                string stringOfChecksum = checksum.ToString();// We convert from int to string to get an array of chars
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

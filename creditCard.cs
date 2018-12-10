using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreedyAlgorithm
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
              Console.WriteLine(number);
          else
              Console.WriteLine("Unable to parse '{0}'",value);
        }
    }
}

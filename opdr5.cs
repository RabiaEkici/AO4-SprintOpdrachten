using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opdracht_5
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int year = 1900; year <= 2020; year++)
            {
                Console.WriteLine("{0} is een schrikkeljaar: {1}", year, DateTime.IsLeapYear(year));
            }
            {
                Console.ReadLine();
            }
        }
    }
}

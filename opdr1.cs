using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint_1
{
    class Program
    {
        static void Main(string[] args)
        {
            int weight;
            Console.WriteLine("Voer je gewicht in");
            weight = Convert.ToInt32(Console.ReadLine());
            double length;
            Console.WriteLine("Voer je lengte in");
            length = Convert.ToDouble(Console.ReadLine());
            double bmi;
            bmi = weight / (length * length) * 10000;
            Console.Write("Je bmi is: ");
            Console.Write(bmi);
            Console.ReadLine();
        }
    }
}

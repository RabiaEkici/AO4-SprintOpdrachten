using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opdracht_2
{
    class Program
    {
        static void Main(string[] args)
        {
            double prijs = 25000;
            double prijsverhoging = 1.05;
            Console.Write("De prijs is nu ");
            Console.Write(prijs);
            Console.WriteLine(" euro.");
            Console.WriteLine("Typ 1 om metallic lak toe te voegen. (5% prijsverhoging)");
            Console.WriteLine("Typ 2 om door te gaan");
            int keuze1 = Convert.ToInt32(Console.ReadLine());

            if (keuze1 == 1)
            {
                prijs = (prijs*prijsverhoging);
                Console.Write("De prijs is nu ");
                Console.Write(prijs);
                Console.WriteLine(" euro.");
            }
            else
            {
                Console.Write("De prijs is nu ");
                Console.Write(prijs);
                Console.WriteLine(" euro.");
            }
            Console.WriteLine("Typ 1 om leren bekleding toe te voegen. (5% prijsverhoging)");
            Console.WriteLine("Typ 2 om door te gaan");
            int keuze2 = Convert.ToInt32(Console.ReadLine());

            if (keuze2 == 1)
            {
                double prijsverhoging2 = 1.05;
                prijs = (prijs + (25000 * prijsverhoging2 - 25000));
                Console.Write("De prijs is nu ");
                Console.Write(prijs);
                Console.WriteLine(" euro.");
            }
            else
            {
                Console.Write("De prijs is nu ");
                Console.Write(prijs);
                Console.WriteLine(" euro.");
            }
            Console.WriteLine("Typ 1 om een automaat i.p.v. handmatige schakeling toe te voegen (1.000 euro verhoging)");
            Console.WriteLine("Typ 2 om door te gaan");
            int keuze3 = Convert.ToInt32(Console.ReadLine());

            if (keuze3 == 1)
            {
                double prijsverhoging3 = 1000;
                prijs = (prijs + prijsverhoging3);
                Console.Write("De prijs is nu ");
                Console.Write(prijs);
                Console.WriteLine(" euro.");
            }
            else
            {
                Console.Write("De prijs is nu ");
                Console.Write(prijs);
                Console.WriteLine(" euro.");
                Console.ReadLine();
            }
            double btwbelasting = 1.21;
            prijs = (prijs + (25000 * btwbelasting - 25000));
            Console.Write("De totaalprijs is ");
            Console.Write(prijs);
            Console.WriteLine(" euro.");
            Console.ReadLine();
        }
    }
}

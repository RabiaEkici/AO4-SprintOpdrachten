using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opdracht_3
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime now = DateTime.Now;
            Console.WriteLine("Choose a language");
            Console.WriteLine("1 = Nederlands");
            Console.WriteLine("2 = Deutsch");
            Console.WriteLine("3 = English");
            Console.WriteLine("4 = Français");
            Console.WriteLine("5 = Español");
            Console.WriteLine("6 = Türk");
            int language = Convert.ToInt32(Console.ReadLine());
            if (language == 1)
            {
                Console.Write("De huidige maand is ");
                Console.WriteLine(now.ToString("MMMM", new System.Globalization.CultureInfo("nl-NL")));
                Console.ReadLine();
            }
            else if (language == 2)
            {
                Console.Write("Der aktuelle Monat ist ");
                Console.WriteLine(now.ToString("MMMM", new System.Globalization.CultureInfo("de-DE")));
                Console.ReadLine();
            }
            else if (language == 3)
            {
                Console.Write("The current month is ");
                Console.WriteLine(now.ToString("MMMM", new System.Globalization.CultureInfo("en-US")));
                Console.ReadLine();
            }
            else if (language == 4)
            {
                Console.Write("Le mois en cours est ");
                Console.WriteLine(now.ToString("MMMM", new System.Globalization.CultureInfo("fr-FR")));
                Console.ReadLine();
            }
            else if (language == 5)
            {
                Console.Write("El mes actual es ");
                Console.WriteLine(now.ToString("MMMM", new System.Globalization.CultureInfo("es-ES")));
                Console.ReadLine();
            }
            else if (language == 6)
            {
                Console.Write("Geçerli ay ");
                Console.WriteLine(now.ToString("MMMM", new System.Globalization.CultureInfo("tr-TR")));
                Console.ReadLine();
            }

        }
    }
}

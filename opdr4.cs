using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opdracht_4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Voer het resultaat voor scheikunde in (1-100)");
            int scheikunde = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Voer het resultaat voor natuurkunde in (1-100)");
            int natuurkunde = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Voer het resultaat voor wiskunde in (1-100)");
            int wiskunde = Convert.ToInt32(Console.ReadLine());
            int totaalwaarde = wiskunde + natuurkunde + scheikunde;
            if ((scheikunde >= 40 && natuurkunde >= 40 && wiskunde >= 40) && ((scheikunde >= 60 || natuurkunde >= 60 && wiskunde >= 60) || (totaalwaarde >= 180)))
            {
                Console.WriteLine("De student is toegelaten");
            }
            else
            {
                Console.WriteLine("De student is niet toegelaten");
            }
            Console.ReadLine();
        }
    }
}

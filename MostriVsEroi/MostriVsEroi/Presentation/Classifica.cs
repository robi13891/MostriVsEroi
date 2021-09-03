using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation
{
    public class Classifica
    {
        public static void Stampa()
        {
            Console.WriteLine("CLASSIFICA GENERALE");
            EroeServices.Classifica();
            Console.WriteLine("Premi un tasto per continuare..");
            Console.ReadLine();
        }
    }
}

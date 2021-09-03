using BusinessLayer.Entities;
using DbProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class MostroServices
    {
        static MostroAdoRepository mar = new MostroAdoRepository();
        public static int Inserimento(Mostro mostro)
        {
            int result = mar.Inserimento(mostro);
            return result;
        }

        public static Mostro MostroRandom(Eroe eroe)
        {
            return mar.MostroRandom(eroe);
        }
    }
}

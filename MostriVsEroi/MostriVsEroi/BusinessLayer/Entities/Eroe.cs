using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Entities
{
    public class Eroe : Personaggio
    {

        public Utente Utente { get; set; }
        public int PuntiAccumulati { get; set; }

        
        public Eroe()
        {
            Livello = livello.Uno;
            PuntiAccumulati = 0;
        }

    }
}

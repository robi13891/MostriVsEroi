using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer;
using DbProject;

namespace Services
{
    public class UtenteServices
    {
        static UtenteAdoRepository uar = new UtenteAdoRepository();
        public static int Inserimento(Utente utente)
        {
            int result = uar.Inserimento(utente);
            return result;
        }

        public static int Login(Utente utente)
        {
            int result = uar.VerificaCredenziali(utente);
            return result;
        }

        public static void AggiornaAdmin(Utente utente)
        {
            uar.AggiornaAdmin(utente);
        }
    }
}

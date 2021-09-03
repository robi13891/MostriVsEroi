
using BusinessLayer;
using BusinessLayer.Entities;
using DbProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class EroeServices
    {
        static EroeAdoRepository ear = new EroeAdoRepository();
        public static int Inserimento(Eroe eroe)
        {
            int result = ear.Inserimento(eroe);
            return result;
        }

        static UtenteAdoRepository uar = new UtenteAdoRepository();
        public static bool ElencoEroi(Utente utente) 
        {
            return uar.ElencoEroi(utente);
        }

        public static Eroe GetEroe(int idEroeScelto, Utente utente)
        {
            Eroe eroeScelto = new Eroe();
            eroeScelto = uar.GetEroe(idEroeScelto, utente);
            return eroeScelto;
        }

        public static void AggiornamentoLivello(Utente utente, Eroe eroe)
        {
            ear.AggiornamentoLivello(utente, eroe);
        }

        public static int EliminaEroe(Utente utente, Eroe eroeDaEliminare)
        {
            int result = ear.EliminaEroe(utente, eroeDaEliminare);
            return result;
        }

        public static void Classifica()
        {
            ear.Classifica();
        }
    }
}

using BusinessLayer;
using BusinessLayer.Entities;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation
{
    class PartitaManager
    {
        public static void Gioca(Utente utente)
        {
            Eroe eroe = ScegliEroe(utente);
            Mostro mostro = new Mostro();
            if (eroe.PuntiAccumulati != -1) // se eroe.puntiaccumulati è 1 significa che non ci sono eroi nella lista
            {
                do
                {
                    mostro = MostroManager.MostroRandom(eroe);

                } while ((int)mostro.Livello <= (int)eroe.Livello);

                IniziaPartita(eroe, mostro, utente);

            }


        }

        private static void AggiornamentoDBEroe(Utente utente, Eroe eroe)
        {
            EroeServices.AggiornamentoLivello(utente, eroe);
        }

        private static void AggiornamentoDBUtente(Utente utente)
        {
            UtenteServices.AggiornaAdmin(utente);
        }

        public static void IniziaPartita(Eroe eroe, Mostro mostro, Utente utente)
        {
            Console.Clear();
            Console.WriteLine("** PARTITA INIZIATA! **");
            Console.WriteLine();
            Console.WriteLine($"{eroe.Nome} vs {mostro.Nome}");
            Console.WriteLine();
            int vitaMostro = 0;
            int vitaEroe = 0;

            #region puntiVita

            if (eroe.Livello == Personaggio.livello.Uno) vitaEroe = 20;
            else if (eroe.Livello == Personaggio.livello.Due) vitaEroe = 40;
            else if (eroe.Livello == Personaggio.livello.Tre) vitaEroe = 60;
            else if (eroe.Livello == Personaggio.livello.Quattro) vitaEroe = 80;
            else if (eroe.Livello == Personaggio.livello.Cinque) vitaEroe = 100;

            if (mostro.Livello == Personaggio.livello.Uno) vitaMostro = 20;
            else if (mostro.Livello == Personaggio.livello.Due) vitaMostro = 40;
            else if (mostro.Livello == Personaggio.livello.Tre) vitaMostro = 60;
            else if (mostro.Livello == Personaggio.livello.Quattro) vitaMostro = 80;
            else if (mostro.Livello == Personaggio.livello.Cinque) vitaMostro = 100;

            #endregion

            Random r = new Random();
            bool fuga = false;
            while (vitaMostro > 0 && vitaEroe > 0 && fuga == false)
            {
                Console.WriteLine();
                Console.WriteLine("Tuo turno! Vuoi attaccare o fuggire?");
                Console.WriteLine("[1] Attacco\n[2] Fuga");
                Console.Write(">> ");
                bool isOk = int.TryParse(Console.ReadLine(), out int mossa);
                while (!(isOk && mossa >= 1 && mossa <= 2))
                {
                    Console.WriteLine("Scelta non valida!");
                    Console.Write(">> ");
                }
                if (mossa == 1) //attacco
                {
                    Console.Clear();
                    vitaMostro = vitaMostro - eroe.Arma.PuntiDanno;
                    if (vitaMostro < 0) vitaMostro = 0;
                    Console.WriteLine("Bel Colpo!");
                    Console.WriteLine($"Punti vita mostro residui: {vitaMostro}");
                }
                else if (mossa == 2)//fuga
                {
                    //1 rimani nella partita 2 fuggi
                    if (r.Next(1, 3) == 1)
                    {
                        Console.WriteLine("Fuga non riuscita!");
                    }
                    else
                    {
                        fuga = true;
                        break;
                    }
                }
                Console.WriteLine();
                Console.WriteLine("Turno del Mostro!");
                vitaEroe = vitaEroe - mostro.Arma.PuntiDanno;
                if (vitaEroe < 0) vitaEroe = 0;
                Console.WriteLine("Il mostro ha attaccato!");
                Console.WriteLine($"Tuoi punti vita residui: {vitaEroe}");
            }

            if (vitaMostro <= 0)
            {
                Console.WriteLine("\nHai vinto!!");
                CalcoloPunteggioVittoria(utente, eroe, mostro);
                Console.WriteLine($"Punti accumulati da {eroe.Nome}: {eroe.PuntiAccumulati}");
                AggiornamentoDBUtente(utente);
                AggiornamentoDBEroe(utente, eroe);
            }
            else if (vitaEroe <= 0)
            {
                Console.WriteLine("\nHai Perso!!");

            }
            else if (fuga == true)
            {
                Console.WriteLine("Fuga riuscita!");
                CalcoloPunteggioFuga(utente, eroe, mostro);
                Console.WriteLine($"Punti accumulati da {eroe.Nome}: {eroe.PuntiAccumulati}");
                AggiornamentoDBUtente(utente);
                AggiornamentoDBEroe(utente, eroe);
            }


            Console.WriteLine("\nVuoi giocare ancora?\n1: si!\n2: no!");
            Console.Write(">> ");
            bool giocaAncora = int.TryParse(Console.ReadLine(), out int scelta);
            while (!(giocaAncora && scelta >= 1 && scelta <= 2))
            {
                Console.WriteLine("Scelta non valida!");
                Console.Write(">> ");
            }
            if (scelta == 1)
            {
                Console.WriteLine("\nVuoi continuare con lo stesso Eroe?\n1:si!\n2:no!");
                Console.Write(">> ");
                bool stessoEroe = int.TryParse(Console.ReadLine(), out int scelta2);
                while (!(stessoEroe && scelta2 >= 1 && scelta2 <= 2))
                {
                    Console.WriteLine("Scelta non valida!");
                    Console.Write(">> ");
                }
                if (scelta2 == 1)
                {
                    //Mostro mostro = MostroManager.ScegliMostro(eroe);
                    IniziaPartita(eroe, mostro, utente);

                }
                else
                {
                    Console.Clear();
                    Gioca(utente);
                }

            }
            else if (scelta == 2)
            {
                if (utente.Admin) Menu.GiocoAdmin(utente);
                else Menu.GiocoNonAdmin(utente);
            }

        }

        private static void CalcoloPunteggioFuga(Utente utente, Eroe eroe, Mostro mostro)
        {
            eroe.PuntiAccumulati = eroe.PuntiAccumulati - (int)mostro.Livello * 5;
            if (eroe.PuntiAccumulati < 0) eroe.PuntiAccumulati = 0;
            if (eroe.PuntiAccumulati >= 0 && eroe.PuntiAccumulati <= 29) eroe.Livello = Personaggio.livello.Uno;
            else if (eroe.PuntiAccumulati >= 30 && eroe.PuntiAccumulati <= 59) eroe.Livello = Personaggio.livello.Due;
            else if (eroe.PuntiAccumulati >= 60 && eroe.PuntiAccumulati <= 89) eroe.Livello = Personaggio.livello.Tre;
            else if (eroe.PuntiAccumulati >= 90 && eroe.PuntiAccumulati <= 119) eroe.Livello = Personaggio.livello.Quattro;
            else if (eroe.PuntiAccumulati >= 120) eroe.Livello = Personaggio.livello.Cinque;

            if ((int)eroe.Livello >= 3) utente.Admin = true;
        }

        private static void CalcoloPunteggioVittoria(Utente utente, Eroe eroe, Mostro mostro)
        {
            eroe.PuntiAccumulati = eroe.PuntiAccumulati + (int)mostro.Livello * 10;
            if (eroe.PuntiAccumulati >= 0 && eroe.PuntiAccumulati <= 29) eroe.Livello = Personaggio.livello.Uno;
            else if (eroe.PuntiAccumulati >= 30 && eroe.PuntiAccumulati <= 59) eroe.Livello = Personaggio.livello.Due;
            else if (eroe.PuntiAccumulati >= 60 && eroe.PuntiAccumulati <= 89) eroe.Livello = Personaggio.livello.Tre;
            else if (eroe.PuntiAccumulati >= 90 && eroe.PuntiAccumulati <= 119) eroe.Livello = Personaggio.livello.Quattro;
            else if (eroe.PuntiAccumulati >= 120) eroe.Livello = Personaggio.livello.Cinque;

            if ((int)eroe.Livello >= 3) utente.Admin = true;

        }

        public static Eroe ScegliEroe(Utente utente)
        {
            Eroe eroeScelto = new Eroe();
            if (EroeServices.ElencoEroi(utente))
            {
                Console.WriteLine("Non si può giocare senza Eroi!\nCrea un Eroe!");
                Console.WriteLine("Premi un tasto per continuare..");
                Console.ReadLine();
                eroeScelto.PuntiAccumulati = -1;
                return eroeScelto;
            }
            else
            {
                Console.WriteLine("Inserisci ID Eroe");
                Console.Write(">> ");
                bool isCorrect = int.TryParse(Console.ReadLine(), out int idEroeScelto);
                while (!isCorrect)
                {
                    Console.WriteLine("Inserimento non valito!");
                    Console.Write(">> ");
                    isCorrect = int.TryParse(Console.ReadLine(), out idEroeScelto);
                }
                eroeScelto = EroeServices.GetEroe(idEroeScelto, utente);
                return eroeScelto;
            }
        }
    }
}

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
    public class EroeManager
    {
        public static void NuovoEroe(Utente utente)
        {
            Eroe eroe = new Eroe();

            eroe.Utente = utente;
            Console.Write("Nome: ");
            eroe.Nome = Console.ReadLine();

            Console.WriteLine("[1] Guerriero [2] Mago");
            Console.Write(">> ");
            bool isCorrect = int.TryParse(Console.ReadLine(), out int index);
            while (!(isCorrect && index >= 1 && index <= 2))
            {
                Console.WriteLine("Inserimento non valido!");
                Console.Write(">> ");
            }
            if (index == 2)
            {

                eroe.Categoria = Personaggio.categoria.Mago;
                Arma arma = new Arma();
                Console.WriteLine("\nArmi Disponibili per Mago:");
                Console.WriteLine("1: Arco e Frecce");
                Console.WriteLine("2: Bacchetta");
                Console.WriteLine("3: Bastone Magico");
                Console.WriteLine("4: Onda d'Urto");
                Console.WriteLine("5: Pugnale");
                Console.Write(">> ");
                bool isInt = int.TryParse(Console.ReadLine(), out int choice);
                while (!(isInt && choice >= 1 && choice <= 5))
                {
                    Console.WriteLine("Inserimento non valido!");
                    Console.Write(">> ");
                }
                if (choice == 1)
                {
                    arma.Nome = Arma.nomeArma.ArcoFrecce;
                    arma.PuntiDanno = 6;
                }
                else if (choice == 2)
                {
                    arma.Nome = Arma.nomeArma.Bacchetta;
                    arma.PuntiDanno = 7;
                }
                else if (choice == 3)
                {
                    arma.Nome = Arma.nomeArma.BastoneMagico;
                    arma.PuntiDanno = 8;
                }
                else if (choice == 4)
                {
                    arma.Nome = Arma.nomeArma.OndaUrto;
                    arma.PuntiDanno = 9;
                }
                else
                {
                    arma.Nome = Arma.nomeArma.Pugnale;
                    arma.PuntiDanno = 10;
                }
                eroe.Arma = arma;

            }
            else
            {
                eroe.Categoria = Personaggio.categoria.Guerriero;
                Arma arma = new Arma();
                Console.WriteLine("\nArmi Disponibili per Mago:");
                Console.WriteLine("1: Alabarda");
                Console.WriteLine("2: Ascia");
                Console.WriteLine("3: Mazza");
                Console.WriteLine("4: Spada");
                Console.WriteLine("5: Spadone");
                Console.Write(">> ");
                bool isInt = int.TryParse(Console.ReadLine(), out int choice);
                while (!(isInt && choice >= 1 && choice <= 5))
                {
                    Console.WriteLine("Inserimento non valido!");
                    Console.Write(">> ");
                }
                if (choice == 1)
                {
                    arma.Nome = Arma.nomeArma.Alabarda;
                    arma.PuntiDanno = 15;
                }
                else if (choice == 2)
                {
                    arma.Nome = Arma.nomeArma.Ascia;
                    arma.PuntiDanno = 8;
                }
                else if (choice == 3)
                {
                    arma.Nome = Arma.nomeArma.Mazza;
                    arma.PuntiDanno = 5;
                }
                else if (choice == 4)
                {
                    arma.Nome = Arma.nomeArma.Spada;
                    arma.PuntiDanno = 10;
                }
                else
                {
                    arma.Nome = Arma.nomeArma.Spadone;
                    arma.PuntiDanno = 15;
                }
                eroe.Arma = arma;

            }

            

            int result = EroeServices.Inserimento(eroe);
            if (result == 1) Console.WriteLine("Eroe inserito!");
            else Console.WriteLine("Errore nell'inserimento dell'Eroe!");


            Console.WriteLine("Premi un tasto per continuare");
            Console.ReadLine();

        }

        public static void EliminaEroe(Utente utente)
        {
            Eroe eroeDaEliminare = PartitaManager.ScegliEroe(utente);
            int result = EroeServices.EliminaEroe(utente, eroeDaEliminare);
            if (result == 1) Console.WriteLine("\nEroe eliminato correttamente!");
            else Console.WriteLine("\nEroe non eliminato!");

        }

    }
}

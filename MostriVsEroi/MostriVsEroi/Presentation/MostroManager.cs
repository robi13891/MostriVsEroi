using BusinessLayer.Entities;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation
{
    public class MostroManager
    {
        public static void NuovoMostro()
        {
            Mostro mostro = new Mostro();

            Console.Write("Nome: ");
            mostro.Nome = Console.ReadLine();
            Console.Write("Livello (1-5):  ");
            bool isLev = int.TryParse(Console.ReadLine(), out int livello);
            while (!(isLev && livello >= 1 && livello <= 5))
            {
                Console.WriteLine("Scelta non valida!");
                Console.Write("Livello (1-5):  ");
                isLev = int.TryParse(Console.ReadLine(), out livello);
            }
            mostro.Livello = (Personaggio.livello)livello;
            Console.WriteLine("[1] Cultista [2] Orco [3] Signore Del Male");
            Console.Write(">> ");
            bool isCorrect = int.TryParse(Console.ReadLine(), out int index);
            while (!(isCorrect && index >= 1 && index <= 3))
            {
                Console.WriteLine("Inserimento non valido!");
                Console.Write(">> ");
            }

            if (index == 1)
            {

                mostro.Categoria = Personaggio.categoria.Cultista;
                Arma arma = new Arma();
                Console.WriteLine("Armi Disponibili per Cultista:");
                Console.WriteLine("1: Discorso Noioso");
                Console.WriteLine("2: Farneticazione");
                Console.WriteLine("3: Imprecazione");
                Console.WriteLine("4: Magia Nera");
                Console.Write(">> ");
                bool isInt = int.TryParse(Console.ReadLine(), out int choice);
                while (!(isInt && choice >= 1 && choice <= 4))
                {
                    Console.WriteLine("Inserimento non valido!");
                    Console.Write(">> ");
                }
                if (choice == 1)
                {
                    arma.Nome = Arma.nomeArma.DiscorsoNoioso;
                    arma.PuntiDanno = 4;
                }
                else if (choice == 2)
                {
                    arma.Nome = Arma.nomeArma.Farneticazione;
                    arma.PuntiDanno = 7;
                }
                else if (choice == 3)
                {
                    arma.Nome = Arma.nomeArma.Imprecazione;
                    arma.PuntiDanno = 5;
                }
                else if (choice == 4)
                {
                    arma.Nome = Arma.nomeArma.MagiaNera;
                    arma.PuntiDanno = 3;
                }
                
                mostro.Arma = arma;

            }
            else if (index == 2)
            {
                mostro.Categoria = Personaggio.categoria.Orco;
                Arma arma = new Arma();
                Console.WriteLine("Armi Disponibili per Orco:");
                Console.WriteLine("1: Arco");
                Console.WriteLine("2: Clava");
                Console.WriteLine("3: Spada Rotta");
                Console.WriteLine("4: Mazza Chiodata");                
                Console.Write(">> ");
                bool isInt = int.TryParse(Console.ReadLine(), out int choice);
                while (!(isInt && choice >= 1 && choice <= 4))
                {
                    Console.WriteLine("Inserimento non valido!");
                    Console.Write(">> ");
                }
                if (choice == 1)
                {
                    arma.Nome = Arma.nomeArma.Arco;
                    arma.PuntiDanno = 7;
                }
                else if (choice == 2)
                {
                    arma.Nome = Arma.nomeArma.Clava;
                    arma.PuntiDanno = 5;
                }
                else if (choice == 3)
                {
                    arma.Nome = Arma.nomeArma.SpadaRotta;
                    arma.PuntiDanno = 3;
                }
                else if (choice == 4)
                {
                    arma.Nome = Arma.nomeArma.MazzaChiodata;
                    arma.PuntiDanno = 10;
                }
                
                mostro.Arma = arma;

            }
            else 
            {
                mostro.Categoria = Personaggio.categoria.SignoreDelMale;
                Arma arma = new Arma();
                Console.WriteLine("Armi Disponibili per Signore Del Male:");
                Console.WriteLine("1: Alabarda del Drago");
                Console.WriteLine("2: Divinazione");
                Console.WriteLine("3: Fulmine");
                Console.WriteLine("4: Fulmine Celeste");
                Console.WriteLine("5: Tempesta");
                Console.WriteLine("6: Tempesta Oscura");
                Console.Write(">> ");
                bool isInt = int.TryParse(Console.ReadLine(), out int choice);
                while (!(isInt && choice >= 1 && choice <= 6))
                {
                    Console.WriteLine("Inserimento non valido!");
                    Console.Write(">> ");
                }
                if (choice == 1)
                {
                    arma.Nome = Arma.nomeArma.AlabardaDelDrago;
                    arma.PuntiDanno = 30;
                }
                else if (choice == 2)
                {
                    arma.Nome = Arma.nomeArma.Divinazione;
                    arma.PuntiDanno = 15;
                }
                else if (choice == 3)
                {
                    arma.Nome = Arma.nomeArma.Fulmine;
                    arma.PuntiDanno = 10;
                }
                else if (choice == 4)
                {
                    arma.Nome = Arma.nomeArma.FulmineCeleste;
                    arma.PuntiDanno = 15;
                }
                else if (choice == 5)
                {
                    arma.Nome = Arma.nomeArma.Tempesta;
                    arma.PuntiDanno = 8;
                }
                else
                {
                    arma.Nome = Arma.nomeArma.TempestaOscura;
                    arma.PuntiDanno = 15;
                }
                mostro.Arma = arma;
            }

            int result = MostroServices.Inserimento(mostro);
            if (result == 1) Console.WriteLine("Mostro inserito!");
            else Console.WriteLine("Errore nell'inserimento del Mostro!");


            Console.WriteLine("Premi un tasto per continuare");
            Console.ReadLine();


        }

        internal static Mostro MostroRandom(Eroe eroe)
        {
            return MostroServices.MostroRandom(eroe);
            
            
        }
    }
}

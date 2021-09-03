using BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation
{
    class Menu
    {
        public static void Principale()
        {
            bool isTrue = true;
            while (isTrue)
            {
                Console.Clear();
                Console.WriteLine("MENU PRINCIPALE\n");
                Console.WriteLine("[1] Accedi");
                Console.WriteLine("[2] Registrati");
                Console.WriteLine("[3] Esci");
                Console.Write("\n>> ");
                bool isInt = int.TryParse(Console.ReadLine(), out int index);
                while (!(isInt && index >= 1 && index <= 3))
                {
                    Console.Write(">> ");
                    isInt = int.TryParse(Console.ReadLine(), out index);
                }
                switch (index)
                {
                    case 1:
                        Console.Clear();
                        UtenteManager.Login();
                        break;
                    case 2:
                        Console.Clear();
                        UtenteManager.SignUp();
                        break;
                    case 3:
                        Console.Clear();
                        isTrue = false;                        
                        break;
                }
            }
        }

        public static void GiocoNonAdmin(Utente utente)
        {
            bool isTrue = true;
            while (isTrue)
            {
                Console.Clear();
                Console.WriteLine("MENU DI GIOCO UTENTI NON ADMIN\n");
                Console.WriteLine("[1] Gioca");
                Console.WriteLine("[2] Crea Nuovo Eroe");
                Console.WriteLine("[3] Elimina Eroe");
                Console.WriteLine("[4] Esci");
                Console.Write("\n>> ");
                bool isInt = int.TryParse(Console.ReadLine(), out int index);
                while (!(isInt && index >= 1 && index <= 4))
                {
                    Console.Write(">> ");
                    isInt = int.TryParse(Console.ReadLine(), out index);
                }
                switch (index)
                {
                    case 1:
                        Console.Clear();
                        PartitaManager.Gioca(utente);
                        break;
                    case 2:
                        Console.Clear();
                        EroeManager.NuovoEroe(utente);
                        break;
                    case 3:
                        Console.Clear();
                        EroeManager.EliminaEroe(utente);
                        break;
                    case 4:
                        Console.Clear();
                        isTrue = false;
                        
                        break;
                }
            }
        }

        public static void GiocoAdmin(Utente utente)
        {
            bool isTrue = true;
            while (isTrue)
            {
                Console.Clear();
                Console.WriteLine("MENU DI GIOCO UTENTI ADMIN\n");
                Console.WriteLine("[1] Gioca");
                Console.WriteLine("[2] Crea Nuovo Eroe");
                Console.WriteLine("[3] Elimina Eroe");
                Console.WriteLine("[4] Crea Nuovo Mostro");
                Console.WriteLine("[5] Mostra Classifica Globale");
                Console.WriteLine("[6] Esci");
                Console.Write("\n>> ");
                bool isInt = int.TryParse(Console.ReadLine(), out int index);
                while (!(isInt && index >= 1 && index <= 6))
                {
                    Console.Write(">> ");
                    isInt = int.TryParse(Console.ReadLine(), out index);
                }
                switch (index)
                {
                    case 1:
                        PartitaManager.Gioca(utente);
                        break;
                    case 2:
                        Console.Clear();
                        EroeManager.NuovoEroe(utente);
                        break;
                    case 3:
                        Console.Clear();
                        EroeManager.EliminaEroe(utente);
                        break;
                    case 4:
                        Console.Clear();
                        MostroManager.NuovoMostro();
                        break;
                    case 5:
                        Console.Clear();
                        Classifica.Stampa();
                        break;
                    case 6:
                        Console.Clear();
                        isTrue = false;                        
                        break;
                }
            }

        }        

    }


}

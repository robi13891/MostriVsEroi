using BusinessLayer;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation
{
    class UtenteManager
    {
        internal static void SignUp()
        {
            Utente utente = new Utente();
            string nickname = String.Empty;
            while (String.IsNullOrEmpty(nickname))
            {
                Console.WriteLine("Inserisci nickname");
                nickname = Console.ReadLine();
            }
            utente.Nickname = nickname;
            string password = String.Empty;
            while (String.IsNullOrEmpty(password))
            {
                Console.WriteLine("Inserisci la password");
                password = Console.ReadLine();
            }
            utente.Password = password;

            int result = UtenteServices.Inserimento(utente);
            if (result == 1)
            {
                Console.WriteLine("\nRegistrazione avvenuta con successo!");

                Menu.GiocoNonAdmin(utente);
            }

           
        }

        internal static void Login()
        {
            Utente utente = new Utente();

            string nickname = String.Empty;
            while (String.IsNullOrEmpty(nickname))
            {
                Console.WriteLine("Inserisci nickname");
                nickname = Console.ReadLine();
            }
            utente.Nickname = nickname;
            string password = String.Empty;
            while (String.IsNullOrEmpty(password))
            {
                Console.WriteLine("Inserisci la password");
                password = Console.ReadLine();
            }
            utente.Password = password;
            
            int result = UtenteServices.Login(utente);
            if (result == 1) Menu.GiocoNonAdmin(utente);
            else if (result == 2) Menu.GiocoAdmin(utente);
            else
            {
                Console.WriteLine("Nickname o Password errati!");
                Console.WriteLine("Premi un tasto per continuare");
                Console.ReadLine();
            }
        }



    }
}

using System;

namespace BusinessLayer
{
    public class Utente
    {
        public string Nickname { get; set; }
        public string Password { get; set; }
        public bool Admin { get; set; }

        public Utente()
        {
            Admin = false;
        }
    }
}

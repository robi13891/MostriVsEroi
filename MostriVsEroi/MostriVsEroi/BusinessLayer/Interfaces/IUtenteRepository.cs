using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interfaces
{
    public interface IUtenteRepository
    {
        public int Inserimento(Utente utente);
        public int VerificaCredenziali(Utente utente);
    }
}

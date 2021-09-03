using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Entities
{
    public class Mostro : Personaggio
    {
        public Mostro()
        {

        }
        public Mostro(string nome, Arma arma, livello livello, categoria categoria)
        {
            Nome = nome;
            Arma = arma;
            Livello = livello;
            Categoria = categoria;

        }
    }
}

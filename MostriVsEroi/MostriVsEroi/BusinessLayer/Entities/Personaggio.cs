using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Entities
{
    public abstract class Personaggio
    {
        public string Nome { get; set; }        
        public Arma Arma { get; set; }
        public livello Livello { get; set; }
        public categoria Categoria { get; set; }

        
        public enum categoria
        {
            Guerriero = 1,
            Mago,
            Cultista,
            Orco,
            SignoreDelMale
        }

        public enum livello
        {
            Uno = 1,
            Due,
            Tre,
            Quattro,
            Cinque
        }
    }
}

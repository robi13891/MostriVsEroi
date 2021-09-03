using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Entities
{
    public class Arma
    {
        public nomeArma Nome { get; set; }
        public int PuntiDanno { get; set; }

        public enum nomeArma
        {
            Alabarda = 1,
            Ascia,
            Mazza,
            Spada,
            Spadone,

            ArcoFrecce,
            Bacchetta,
            BastoneMagico,
            OndaUrto,
            Pugnale,

            DiscorsoNoioso,
            Farneticazione,
            Imprecazione,
            MagiaNera,

            Arco,
            Clava,
            SpadaRotta,
            MazzaChiodata,

            AlabardaDelDrago,
            Divinazione,
            Fulmine,
            FulmineCeleste,
            Tempesta,
            TempestaOscura
        }
    }
}

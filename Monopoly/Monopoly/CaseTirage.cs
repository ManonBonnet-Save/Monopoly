using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    class CaseTirage : Case
    {
        public Pioche PiocheCartes;

        public CaseTirage(string nom, Pioche p) : base(nom)
        {
            PiocheCartes = p;
        }

        public override bool action(Joueur j)
        {
            int Index = PiocheCartes.idx;
            Cartes CartePiochée = PiocheCartes.getCarte(Index);
            //if (CartePiochée.)

           // PiocheCartes.idx = ((PiocheCartes.idx + 1) % PiocheCartes.ListeCarte.Count);
            return true;
        }
    }
}

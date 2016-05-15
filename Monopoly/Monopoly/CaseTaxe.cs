using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    class CaseTaxe : Case
    {
        int _prix;

        public CaseTaxe(string nom, int prix) : base(nom)
        {
            _prix = prix;
        }

        public override bool action(Joueur j)
        {
            //Faire payer le joueur
            return j.Debiter(_prix);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    class CaseDeterminante: Case
    {
        private List<Immobilier> Terrains;
        private string Nom;

        public CaseDeterminante (string Nom)
        {
            Terrains = new List<Immobilier>();
        }

        public void Action()
        {

        }
    }
}

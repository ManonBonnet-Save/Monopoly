using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    class CasePolice : Case
    {
        public CasePolice(string nom) : base(nom){ }

        public override bool action(Joueur j)
        {
            j.Position = 10;
            j.CompteurPrison = 1;
            j.CompteurDouble = 0;
            return true;
        }
    }
}

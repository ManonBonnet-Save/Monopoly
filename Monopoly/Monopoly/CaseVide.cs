using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    class CaseVide : Case
    {
        public CaseVide(string nom) : base(nom){}

        public override bool action(Joueur j){ return true; }
    }
}

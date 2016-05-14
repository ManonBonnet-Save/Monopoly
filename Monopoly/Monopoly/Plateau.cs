using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    class Plateau
    {
        private List<int> Cases;

        public Plateau (int nbCase)
        {
            Cases = new List<int>();
            for (int i=0; i<nbCase; ++i)
            {
                Cases.Add(i);
            }
        }

        public int NbCases() { return Cases.Count; }

        public int getCase(int idx) { return Cases[idx]; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    //Création de la classe des cartes compagnies
    public class Compagnie : Immobilier
    {
        private List<int> _CasesCompagnies;
        private int _Loyer;
        private int _NbCompagnies;

        //*****Constructeurs*****
        public Compagnie(string nom, int pa, int loyer) : base(nom, pa, loyer)
        {
            _Loyer = 0;
        }

        //*****Accesseurs*****


        //*****Méthodes*****
    }
}

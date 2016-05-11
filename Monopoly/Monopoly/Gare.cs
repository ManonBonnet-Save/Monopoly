using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    //Création de la classe des cartes gares
    public class Gare : Immobilier
    {
        private List<int> _CasesGares;
        private int _Loyer;

        //*****Constructeurs*****
        public Gare(string nom, int pa, int loyer) : base(nom, pa, loyer)
        {
            _Loyer = 0;
        }

        //*****Accesseurs*****

        //*****Méthodes*****
    }
}

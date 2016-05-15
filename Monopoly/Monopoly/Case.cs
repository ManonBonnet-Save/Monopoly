using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    abstract class Case
    {
        //*****Attributs*****
        protected string _Nom;

        //*****Constructeurs*****
        public Case(string nom)
        {
            _Nom = nom;
        }

        //*****Accesseurs*****
        public string Nom
        {
            get { return _Nom; }
            set { _Nom = value; }
        }

        //*****Méthodes*****
        public abstract bool action(Joueur j);

    }
}

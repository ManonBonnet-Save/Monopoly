using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    public class Cartes
    {
        //*****Attribus*****
        protected string _Nom;

        //*****Constructeurs*****
        public Cartes(string nom)
        {
            _Nom = nom;
        }

        //*****Accesseurs*****
        public string Nom
        {
            get { return _Nom; }
            set { _Nom = value; }
        }
        //*****Methodes*****
    }
}


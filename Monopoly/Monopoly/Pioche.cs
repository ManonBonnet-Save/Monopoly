using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    abstract class Pioche
    {
        //*****Attributs*****
        protected string _Nom;
        public int idx = 0;
        protected List<Cartes> _ListeCarte;

        //*****Constructeurs*****
        public Pioche(string nom)
        {
            _Nom = nom;
        }

        //*****Accesseurs*****
        public string Nom
        {
            get { return _Nom; }
            set { _Nom = value; }
        }

        public List<Cartes> ListeCarte
        {
            get { return _ListeCarte; }
        }

        public int Index
        {
            get { return idx; }
            set { idx = value; }
        }

        abstract public Cartes getCarte(int idx);


    }
}

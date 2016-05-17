using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    public class Groupe
    {
        private static int groupeCpt = 0; //Nombre de groupes
        private int _index;
        private int _taille; //Nombre d'éléments à atteindre

        //*****Constructeur*****
        public Groupe(int taille)
        {
            _index = groupeCpt++;
            _taille = taille;
        }

        //*****Accesseurs*****
        public int index
        {
            get { return _index; }
        }
        public int taille
        {
            get { return _taille; }
        }
    }
}

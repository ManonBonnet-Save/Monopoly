using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    //Pioche des cartes chances
    public class CarteChance : Cartes
    {
        //*****Attributs******
        //Création d'une liste qui contiendra toutes les cartes chances
        private List<CarteChance> _PiocheCarteChance;

        //*****Constructeur*****
        public CarteChance(string nom) : base(nom)
        {
            _PiocheCarteChance = new List<CarteChance>();
        }
        //*****Accesseurs*****
        public List<CarteChance> PiocheCarteChance
        {
            get { return _PiocheCarteChance; }
            set { _PiocheCarteChance = value; }
        }
    }
}

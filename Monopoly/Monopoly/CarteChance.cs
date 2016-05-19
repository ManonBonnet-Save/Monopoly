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
        //private List<CarteChance> _PiocheCarteChance;
        private bool Avancer; //Détermine si on passe par la case départ ou pas.
        private bool EntréeArgent;
        private int Action; //Détermine le type d'action à réaliser 
                            //0 - Mouvement sur le plateau
                            //1 - Mouvement d'argent
                            //2 - Frais sur construction
                            //3 - Anniversaire
        private int DestinationPlateau;
        private int SommeArgent;
        private int PrixMaison;
        private int PrixHotel;

        //*****Constructeur*****
        public CarteChance(string nom, bool avancer, bool recevoir, int action, int destination, int somme, int prixMaison, int prixHotel ) : base(nom)
        {
            //_PiocheCarteChance = new List<CarteChance>();
            Avancer = avancer;
            EntréeArgent = recevoir;
            Action = action;
            DestinationPlateau = destination;
            SommeArgent = somme;
            PrixMaison = prixMaison;
            PrixHotel = prixHotel;
        }

        //*****Accesseurs*****
        public int action
        {
            get { return Action; }
        }

        public bool avancée
        {
            get { return Avancer; }
        }

        public bool entréeargent
        {
            get { return EntréeArgent; }
        }

        public int destination
        {
            get { return DestinationPlateau; }
        }
        public int sommeargent
        {
            get { return SommeArgent; }
        }
        public int prixparmaison
        {
            get { return PrixMaison; }
        }
        public int prixparhotel
        {
            get { return PrixHotel; }
        }
        //public List<CarteChance> PiocheCarteChance
        //{
        //    get { return _PiocheCarteChance; }
        //    set { _PiocheCarteChance = value; }
        //}

        //*****Méthodes*****

    }
}

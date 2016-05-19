using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    //Pioche des cartes de communauté
    public class CarteCommunaute : Cartes
    {
        //*****Attributs*****
        //Création d'ne liste qi contiendra toutes les cartes communautés
        //private List<CarteCommunaute> _PiocheCarteCommunaute;
        private bool Avancer; //Détermine si on passe par la case départ ou pas.
        private bool EntréeArgent;
        private int Action; //Détermine le type d'action à réaliser 
                            //0 - Mouvement sur le plateau
                            //1 - Mouvement d'argent
                            //2 - Frais sur construction
                            //3 - Anniversaire
        private int DestinationPlateau;
        private int SommeArgent;

        //*****Constructeur*****
        public CarteCommunaute(string nom, bool avancer, bool recevoir, int action, int destination, int somme) : base(nom)
        {
            //_PiocheCarteChance = new List<CarteChance>();
            Avancer = avancer;
            EntréeArgent = recevoir;
            Action = action;
            DestinationPlateau = destination;
            SommeArgent = somme;
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

        //public List<CarteCommunaute> PiocheCarteCommunaute
        //{
        //    get { return _PiocheCarteCommunaute; }
        //    set { _PiocheCarteCommunaute = value; }
        //}
    }
}

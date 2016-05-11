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
        private List<CarteCommunaute> _PiocheCarteCommunaute;

        //*****Constructeur*****
        public CarteCommunaute(string nom) : base(nom)
        {
            _PiocheCarteCommunaute = new List<CarteCommunaute>();
        }
        //*****Accesseurs*****
        public List<CarteCommunaute> PiocheCarteCommunaute
        {
            get { return _PiocheCarteCommunaute; }
            set { _PiocheCarteCommunaute = value; }
        }
    }
}

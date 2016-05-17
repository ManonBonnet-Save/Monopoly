using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    //Création des cartes immobilières
    public abstract class Immobilier : Cartes
    {
        protected Joueur _Proprietaire;
        private int _PrixAchat;

        //*****Constructeur*****
        public Immobilier(string nom, int prixAchat) : base(nom)
        {
            _Proprietaire = null;
            _PrixAchat = prixAchat;
        }
        //*****Accesseurs*****
        public Joueur Proprietaire
        {
            get { return _Proprietaire; }
            set { _Proprietaire = value; }
        }
        public int PrixAchat
        {
            get { return _PrixAchat; }
            set { _PrixAchat = value; }
        }

        //*****Méthodes***** //Virtual Override
        public abstract int Loyer();
    }
}

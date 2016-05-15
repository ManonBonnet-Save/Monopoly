using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    //Création des cartes immobilières
    public class Immobilier : Cartes
    {
        protected Joueur _Proprietaire;
        private int _PrixAchat;
        private int _Loyer;

        //*****Constructeur*****
        public Immobilier(string nom, int prixAchat, int loyer) : base(nom)
        {
            _Proprietaire = null;
            _PrixAchat = prixAchat;
            _Loyer = loyer;
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
        public int Loyer
        {
            get { return _Loyer; }
            set { _Loyer = modificationLoyer(); }
        }
        //public int NbMaison
        //{
            //get { return _NbMaison; }
            //set { _NbMaison = value; }
        //}
        //public int NbGares
        //{
        //    get { return _NbGares; }
        //    set { _NbGares = value; }
        //}
        //public int NbCompagnies
        //{
        //    get { return _NbCompagnies; }
        //    set { _NbCompagnies = value; }
        //}

        //*****Méthodes***** //Virtual Override
        public virtual int modificationLoyer()
        {
            return Loyer;
        }
    }
}

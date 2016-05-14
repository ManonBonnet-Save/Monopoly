using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    //Création de la class des cartes propriétés
    public class Propriete : Immobilier
    {
        private string _Groupe;
        private List<int> _CasesFamille;
        private int _Loyer1Maison;
        private int _Loyer2Maisons;
        private int _Loyer3Maisons;
        private int _Loyer4Maisons;
        private int _PrixAchatMaison;
        private int _LoyerHotel;
        private bool _Hotel;
        private int _PrixAchatHotel;
        private int _Hypotheque;

        //*****Constructeurs*****
        public Propriete(int prixAchatMaison, int prixAchatHotel, string nom, int pa, int loyer) : base(nom, pa, loyer)
        {
            _PrixAchatMaison = prixAchatMaison;
            _Hotel = false;
            _PrixAchatHotel = prixAchatHotel;
        }

        //*****Accesseurs*****
        public int PrixAchatMaison
        {
            get { return _PrixAchatMaison; }
            set { _PrixAchatMaison = value; }
        }
        public bool Hotel
        {
            get { return _Hotel; }
            set { _Hotel = value; }
        }
        public int PrixAchatHotel
        {
            get { return _PrixAchatHotel; }
            set { _PrixAchatHotel = value; }
        }
        public string Groupe
        {
            get { return _Groupe; }
            set { _Groupe = value; }
        }
        public int Loyer1Maison
        {
            get { return _Loyer1Maison; }
            set { _Loyer1Maison = value; }
        }
        public int Loyer2Maisons
        {
            get { return _Loyer2Maisons; }
            set { _Loyer2Maisons = value; }
        }
        public int Loyer3Maisons
        {
            get { return _Loyer3Maisons; }
            set { _Loyer3Maisons = value; }
        }
        public int Loyer4Maisons
        {
            get { return _Loyer4Maisons; }
            set { _Loyer4Maisons = value; }
        }
        public int LoyerHotel
        {
            get { return _LoyerHotel; }
            set { _LoyerHotel = value; }
        }
        public List<int> CasesFamille
        {
            get { return _CasesFamille; }
            set { _CasesFamille = value; }
        }

        //*****Méthodes*****
        public override int modificationLoyer()
        {
            if (Proprietaire != null)
            {
                foreach (Immobilier element in Proprietaire.Possessions)
                {
                    //On cherche à savoir si le propriétaire de la case possède tous les terrains du même groupe. 
                    //Si c'est le cas et qu'ils sont nus, alors le prix de chaque loyer est doublé.
                    //if (this.Groupe = Groupe)
                    //{

                    //}
                }
                //Calcul du loyer en fonction du nombre de maisons et hotel
                if (NbMaison == 1)
                {
                    Loyer = _Loyer1Maison;
                    return Loyer;
                }
                if (NbMaison == 2)
                {
                    Loyer = _Loyer2Maisons;
                    return Loyer;
                }
                if (NbMaison == 3)
                {
                    Loyer = _Loyer3Maisons;
                    return Loyer;
                }
                if (NbMaison == 4)
                {
                    Loyer = _Loyer4Maisons;
                    return Loyer;
                }
                if (Hotel)
                {
                    Loyer = _LoyerHotel;
                    return Loyer;
                }
                return Loyer;
            }
            return Loyer;
        }
    }
}

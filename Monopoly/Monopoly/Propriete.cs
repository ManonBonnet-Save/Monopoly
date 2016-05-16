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
        private int _NbCasesFamille;
        private int _PrixAchatMaison;
        private bool _Hotel;
        private int _PrixAchatHotel;
        private int _Hypotheque;
        private int[] _LoyersDuTerrain;
        private int _nbMaison;
        private int _Loyer;

        //*****Constructeurs*****
        public Propriete(string nom, int pa, int loyer, int prixAchatMaison, int Loyer1Maison, int Loyer2Maison, int Loyer3Maison,int Loyer4Maison, int prixAchatHotel, int LoyerHotel, int TailleFamille) : base(nom, pa, loyer)
        {
            _PrixAchatMaison = prixAchatMaison;
            _Hotel = false;
            _PrixAchatHotel = prixAchatHotel;
            _LoyersDuTerrain = new int[6];
            _LoyersDuTerrain[0] = loyer;
            _LoyersDuTerrain[1] = Loyer1Maison;
            _LoyersDuTerrain[2] = Loyer2Maison;
            _LoyersDuTerrain[3] = Loyer3Maison;
            _LoyersDuTerrain[4] = Loyer4Maison;
            _LoyersDuTerrain[5] = LoyerHotel;
            _NbCasesFamille = TailleFamille;
        }

        //*****Accesseurs*****
        public int PrixAchatMaison
        {
            get { return _PrixAchatMaison; }
            set { _PrixAchatMaison = value; }
        }
        public int NbMaison
        {
            get { return _nbMaison; }
            set { _nbMaison = value; }
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
        public new int Loyer
        {
            get { return _Loyer; }
            set { _Loyer = modificationLoyer(); }
        }
        public int NbCasesFamille
        {
            get { return _NbCasesFamille; }
            set { _NbCasesFamille = value; }
        }

        //*****Méthodes*****
        public override int modificationLoyer()
        {
            if (Proprietaire != null)
            {
                foreach (Propriete element in Proprietaire.Possessions)
                {
                    int NbCarteFamille = 0;
                    //On cherche à savoir si le propriétaire de la case possède tous les terrains du même groupe. 
                    //Si c'est le cas et qu'ils sont nus, alors le prix de chaque loyer est doublé.
                    if (this.Groupe == element.Groupe && element.NbMaison == 0)
                    {
                        NbCarteFamille++;
                    }
                    if (NbCarteFamille == NbCasesFamille)
                    {
                        Loyer = _LoyersDuTerrain[0] * 2;
                    }
                }
                //Calcul du loyer en fonction du nombre de maisons et hotel
                if (_nbMaison == 1)
                {
                    Loyer = _LoyersDuTerrain[1];
                    return Loyer;
                }
                if (_nbMaison == 2)
                {
                    Loyer = _LoyersDuTerrain[2];
                    return Loyer;
                }
                if (_nbMaison == 3)
                {
                    Loyer = _LoyersDuTerrain[3];
                    return Loyer;
                }
                if (_nbMaison == 4)
                {
                    Loyer = _LoyersDuTerrain[4];
                    return Loyer;
                }
                if (Hotel)
                {
                    Loyer = _LoyersDuTerrain[5];
                    return Loyer;
                }
                return Loyer;
            }
            return Loyer;
        }
    }
}

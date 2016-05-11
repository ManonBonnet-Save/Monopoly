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
        public int prixAchatMaison
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

        //*****Méthodes*****
    }
}

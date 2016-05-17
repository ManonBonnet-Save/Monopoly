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
        private int _PrixAchatMaison;
        private int _PrixAchatHotel;
        private int[] _LoyersDuTerrain;
        private int _nbMaison;
        private Groupe _Groupe;

        //*****Constructeurs*****
        public Propriete(string nom, int pa, Groupe groupe, int loyer, int prixAchatMaison, int Loyer1Maison, int Loyer2Maison, 
                         int Loyer3Maison,int Loyer4Maison, int prixAchatHotel, int LoyerHotel) : base(nom, pa)
        {
            _Groupe = groupe;
            _PrixAchatMaison = prixAchatMaison;
            _PrixAchatHotel = prixAchatHotel;
            _LoyersDuTerrain = new int[6];
            _LoyersDuTerrain[0] = loyer;
            _LoyersDuTerrain[1] = Loyer1Maison;
            _LoyersDuTerrain[2] = Loyer2Maison;
            _LoyersDuTerrain[3] = Loyer3Maison;
            _LoyersDuTerrain[4] = Loyer4Maison;
            _LoyersDuTerrain[5] = LoyerHotel;
            _nbMaison = 0;
        }

        //*****Accesseurs*****
        public Groupe Groupe
        {
            get { return _Groupe; }
        }
        public int PrixAchatMaison
        {
            get { return _PrixAchatMaison; }
        }
        public int NbMaison
        {
            get { return _nbMaison; }
            set { _nbMaison = value; }
        }
        public int PrixAchatHotel
        {
            get { return _PrixAchatHotel; }
        }

        //*****Méthodes*****
        public override int Loyer()
        {
            if (Proprietaire != null)
            {
                return _LoyersDuTerrain[_nbMaison];
            }
            return 0;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
	public class Banque
	{
		//Attributs de la classe Banque
		private int _Maisons;
		private int _Hotels;

		//Constructeur de la classe Banque
		public Banque ()
		{
			_Maisons = 32;
			_Hotels = 12;
		}

		//Accesseurs des instances
		public int Maisons
		{
			get { return _Maisons; }
		}
		public int Hotels
		{
			get { return _Hotels; }
		}

		//*****  Méthodes et fonctions  *****

		//Donne une maison
		public void VendreMaison(Propriete p)
		{
            int prix =  p.NbMaison < 4 ?  p.PrixAchatMaison : p.PrixAchatHotel;
            if (_Maisons < 5)
            {
                p.Proprietaire.Debiter(prix);
                p.NbMaison++;
                _Maisons--;
            }
		}
		//Récupère une maison
		public void RecupereMaison(Propriete P)
		{
            int prix = P.NbMaison < 4 ? P.PrixAchatMaison : P.PrixAchatHotel;
            if (_Maisons < 5)
            {
                P.Proprietaire.Crediter(prix);
                if (P.NbMaison == 5)
                {
                    P.NbMaison--;
                    _Hotels++;
                }
                else
                {
                    P.NbMaison--;
                    _Maisons++;
                }
            }
        }

        //Vérifications que le groupe est complet
        public bool GroupeComplet(Propriete p)
        {
            Joueur proprio = p.Proprietaire;
            int idx = p.Groupe.index;
            int cpt = 0;
            foreach(Immobilier i in proprio.Possessions)
            {
                if(i is Propriete)
                {
                    Propriete tmp = (Propriete) i;
                    if (tmp.Groupe.index == idx)
                        cpt++;
                }
            }
            if (cpt == p.Groupe.taille) return true;
            return false;
        }

	}
}


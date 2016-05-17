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
		public void upgrader(Propriete p)
		{
            int prix =  p.NbMaison < 4 ?  p.PrixAchatMaison : p.PrixAchatHotel;
            p.Proprietaire.Debiter(prix);
            if (_Maisons > 0)
            {
                p.NbMaison++;
                _Maisons--;
            }

		}
		//Récupère une maison
		public void RecupereMaison()
		{
			_Maisons = _Maisons + 1;
		}
		//Donne un hôtel
		public void DonneHotel(Joueur J)
		{
			_Hotels = _Hotels - 1;
		}
		//Récupère un Hotel
		public void RecupereHotel()
		{
			_Hotels = _Hotels + 1;
		}

        //Vérifications
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


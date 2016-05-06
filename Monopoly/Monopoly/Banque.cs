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
		private List<CartesChance> _CartesChance;
		private List<CartesCommunaute> _CartesCommunaute;
		private int _Maisons;
		private int _Hotels;

		//Constructeur de la classe Banque
		public Banque (List<CartesChance> CCh, List<CartesCommunaute> CCo)
		{
			_CartesChance = CCh;
			_CartesCommunaute = CCo;
			_Maisons = 32;
			_Hotels = 12;
		}

		//Accesseurs des instances
		public int Maisons
		{
			get { return _Maisons; }
			set { _Maisons = value; }
		}
		public int Hotels
		{
			get { return _Hotels; }
			set { _Hotels = value; }
		}

		//*****  Méthodes et fonctions  *****

		//Donne une maison
		public void DonneMaison(Joueur J)
		{
			_Maisons = _Maisons - 1;
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


	}
}


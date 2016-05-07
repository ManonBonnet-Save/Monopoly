using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    public abstract class Cartes //test hey!
    {
        //Attribus
		protected string _Nom;

        //Constructeurs
		public Cartes(string nom)
		{
			_Nom = nom;
		}

		//*****Accesseurs*****
		public string Nom{
			get { return _Nom; }
			set { _Nom = value; }
		}
        //Methodes

    }
	public class CarteChance : Cartes
	{
		private List<CarteChance> _PiocheCarteChance;
		public CarteChance (string nom):base(nom)
		{
			_PiocheCarteChance = new List<CarteChance> ();
		}
		public List<CarteChance> PiocheCarteChance
		{
			get { return _PiocheCarteChance;}
			set { _PiocheCarteChance = value; }
		}
	}
	public class CarteCommunaute : Cartes
	{
		private List<int> _Pioche;
		public CarteCommunaute (string nom) : base (nom)
		{
			_Pioche = new List<int> {2,3};
		}
		//méthode pioche carte communaute dans liste des cartes
	}

    public abstract class Immobilier : Cartes
    {
		protected Joueur _Proprietaire;
		protected int _PrixAchat;
		//*****Constructeur*****
		public Immobilier (string nom, int prixAchat):base(nom)
		{
			_Proprietaire = null;
			_PrixAchat = prixAchat;
		}
		//*****Accesseurs*****
		public Joueur Proprietaire
		{
			get { return _Proprietaire;}
			set { _Proprietaire = value; }
		}
		public int PrixAchat
		{
			get { return _PrixAchat;}
			set { _PrixAchat = value; }
		}
    }

    public class Propriete : Immobilier
    {
		private string _Groupe;
		private int _Loyer;
		private int _Loyer1Maison;
		private int _Loyer2Maisons;
		private int _Loyer3Maisons;
		private int _Loyer4Maisons;
		private int _NbMaison;
		private int _PrixAchatMaison;
		private bool _Hotel;
		private int _PrixAchatHotel; 
		private int _Hypotheque;

        //Constructeurs
		public Propriete(int loyer, int prixAchatMaison, int prixAchatHotel, string nom, int pa) : base(nom,pa)
        {
            _Loyer = loyer;
			_NbMaison = 0;
            _PrixAchatMaison = prixAchatMaison;
            _Hotel = false;
            _PrixAchatHotel = prixAchatHotel;
        }
		public Propriete(string nom, int pa):base(nom,pa)
		{
		}
		//*****Accesseurs*****
		public int Loyer
		{
			get { return _Loyer;}
			set { _Loyer = value; }
		}
		public int NbMaison {
			get { return _NbMaison; }
			set { _NbMaison = value; }
		}
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


        //Méthodes
        public void modificationLoyer()
        {

        }

    }

    public class Gare : Immobilier
    {
        //Constructeurs
		public Gare(string nom, int pa): base(nom, pa)
        {
		}
    }

    public class Compagnie : Immobilier
    {
        //Constructeurs
		public Compagnie(string nom, int pa): base(nom, pa)
        {
        }
    }
}

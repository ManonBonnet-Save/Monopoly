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
		private string _Nom;

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
		private Joueur _Proprietaire;
		private int _PrixAchat { get; set; }
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
        public int loyer { get; set; }
        public int nbmaison { get; protected set; }
        public int prixAchatMaison { get; protected set; }
        public int nbhotel { get; protected set; }
        public int prixAchatHotel { get; protected set; }

        //Constructeurs
		public Propriete(int montantAcheter, int montantLoyer, int prix1Maison, int prixHotel, string nom, int pa) : base(nom,pa)
        {
            loyer = montantLoyer;
            nbmaison = 0;
            prixAchatMaison = prix1Maison;
            nbhotel = 0;
            prixAchatHotel = prixHotel;
        }
		public Propriete(string nom, int pa):base(nom,pa)
		{
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

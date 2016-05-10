using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    public abstract class Cartes
    {
        //*****Attribus*****
		protected string _Nom;

        //*****Constructeurs*****
		public Cartes(string nom)
		{
			_Nom = nom;
		}

		//*****Accesseurs*****
		public string Nom
        {
			get { return _Nom; }
			set { _Nom = value; }
		}
        //*****Methodes*****

    }
	//Pioche des cartes chances
	public class CarteChance : Cartes
	{
		//*****Attributs******
		//Création d'une liste qui contiendra toutes les cartes chances
		private List<CarteChance> _PiocheCarteChance;

		//*****Constructeur*****
		public CarteChance (string nom):base(nom)
		{
			_PiocheCarteChance = new List<CarteChance> ();
		}
		//*****Accesseurs*****
		public List<CarteChance> PiocheCarteChance
		{
			get { return _PiocheCarteChance;}
			set { _PiocheCarteChance = value; }
		}
	}
	//Pioche des cartes de communauté
	public class CarteCommunaute : Cartes
	{
		//*****Attributs*****
		//Création d'ne liste qi contiendra toutes les cartes communautés
		private List<CarteCommunaute> _PiocheCarteCommunaute;

		//*****Constructeur*****
		public CarteCommunaute (string nom) : base (nom)
		{
			_PiocheCarteCommunaute = new List<CarteCommunaute> ();
		}
		//*****Accesseurs*****
		public List<CarteCommunaute> PiocheCarteCommunaute
		{
			get { return _PiocheCarteCommunaute;}
			set { _PiocheCarteCommunaute = value; }
		}	}

	//Création des cartes immobilières
    public abstract class Immobilier : Cartes
    {
		protected Joueur _Proprietaire;
		protected int _PrixAchat;
        private int _Loyer;

        //*****Constructeur*****
        public Immobilier (string nom, int prixAchat, int loyer):base(nom)
		{
			_Proprietaire = null;
			_PrixAchat = prixAchat;
            _Loyer = loyer;
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
        public int Loyer
        {
            get { return _Loyer; }
            set { _Loyer = value; }
        }
    }

	//Création de la class des cartes propriétés
    public class Propriete : Immobilier
    {
		private string _Groupe;
		private List<int> _CasesFamille;
		private int _Loyer1Maison;
		private int _Loyer2Maisons;
		private int _Loyer3Maisons;
		private int _Loyer4Maisons;
		private int _NbMaison;
		private int _PrixAchatMaison;
        private int _LoyerHotel;
		private bool _Hotel;
		private int _PrixAchatHotel; 
		private int _Hypotheque;

        //*****Constructeurs*****
		public Propriete(int prixAchatMaison, int prixAchatHotel, string nom, int pa, int loyer) : base(nom,pa,loyer)
        {
			_NbMaison = 0;
            _PrixAchatMaison = prixAchatMaison;
            _Hotel = false;
            _PrixAchatHotel = prixAchatHotel;
        }
        
		//*****Accesseurs*****
		
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


        //*****Méthodes*****
        public void modificationLoyer()
        {
            if (_NbMaison>1)
            {
                _Loyer1Maison = Loyer + (_NbMaison*100); //Vérifier si le loyer évolue de la même manière sur tous les terrains. 
                // Si c'est le cas, alors faire une méthode identique juste selon le nombre de maison. 
            }
        }

    }
	//Création de la classe des cartes gares
    public class Gare : Immobilier
    {
        private List<int> _CasesGares;
        private int _Loyer;
        private int _NbGares;

        //*****Constructeurs*****
        public Gare(string nom, int pa, int loyer): base(nom, pa, loyer)
        {
            _Loyer = 25;
		}

        //*****Accesseurs*****
        public int NbGares
        {
            get { return _NbGares; }
            set { _NbGares = value; }
        }

        //*****Méthodes*****
        public void modificationLoyer()
        {
            if (Proprietaire != null)
            {
                foreach (Immobilier element in Proprietaire.Possessions)
                {
                    if (element is Gare)
                    {
                        _NbGares += 1;
                    }
                }
                if (_NbGares > 1)
                {
                    Loyer = Loyer * 2 ^ (_NbGares - 1); //Le loyer dépend de la quantité de gare que possède la personne: 25,50,100,200
                }
            }
            else
            {
                Loyer = 0;
            }
        }
    }
	//Création de la classe des cartes compagnies
    public class Compagnie : Immobilier
    {
        //*****Constructeurs*****
		public Compagnie(string nom, int pa, int loyer): base(nom, pa, loyer)
        {
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
	public class Joueur
	{
		//*****Attributs de la classe*****
		// Chaque joueur se voit attribuer un numero
		private static int numero = 1; //Nbr de joueur
		private int _NumeroJoueur;
		private string _Nom;
		private int _Argent;
		private int _Position;
		private int _CompteurPrison;
		private int _CompteurDouble;
		private List<Cartes> _Cartes; //Cartes spéciales
		private List<Immobilier> _Possessions;
        private int _nbMaison;

        //*****Constructeur de la classe*****
        public Joueur(string nom)
		{
			_NumeroJoueur = numero++; //postfix incrémentation
			_Nom = nom;
			_Argent = 1500;
			_Position = 0;
			_CompteurPrison = 0;
			_CompteurDouble = 0;
			_Cartes = new List<Cartes> ();
			_Possessions = new List<Immobilier> ();
		}

		//Accesseurs des instances
		public string Nom
        {
			get { return _Nom; }
			set { _Nom = value; }
		}
		public int NumeroJoueur
		{
			get { return _NumeroJoueur; }
			set { _NumeroJoueur = value; }
		}
		public int Argent
		{
			get { return _Argent; }
			set { _Argent = value; } 
		}
		public int Position
		{
			get { return _Position; }
			set { _Position = value; }
		}
		public int CompteurPrison
        {
			get { return _CompteurPrison; }
			set { _CompteurPrison = value; }
		}
		public int CompteurDouble
        {
			get { return _CompteurDouble; }
			set { _CompteurDouble = value; }
		}
		public List<Immobilier> Possessions
        {
			get { return _Possessions; }
			set { _Possessions = value; }
		}
		public List<Cartes> Cartes
        {
			get { return _Cartes; }
			set { _Cartes = value; }
		}
        public int NbMaison
        {
            get { return _nbMaison; }
            set { _nbMaison = value; }
        }

        //*****Methodes et fonctions*****
        public bool EstEnPrison()
        {
            return CompteurPrison > 0;
        }

		public void VendreCarte(Cartes x, Joueur J, int PrixChoisi)
		{
			if (x is Immobilier)
            {
				Immobilier i = (Immobilier) x;

				if (i.Proprietaire == this)
                {
					//if (i is Propriete) {
					//	Propriete p = (Propriete)i;

					//	if ()
     //                   {
					//		foreach (Propriete f in p.CasesFamille)// si maisons sur une autre carte du groupe
					//	if (p.NbMaison == 0 && p.Hotel==false)
     //                   {
					//		Console.WriteLine ("Vous pouvez vendre ce bien");
					//		Argent = Argent + PrixChoisi;
					//		p.Proprietaire = J;
					//		J.Argent = Argent - PrixChoisi;
					//	}
     //                   else
     //                   {
					//		Console.WriteLine ("Il vous reste des maisons ou un hotel sur ce terrain");
					//		//rajouter fonction vendre maison ou hotel
					//		VendreConstruction(p);
					//	}	
					//    }
     //                   else
     //                   {
					//	Console.WriteLine ("Il vous reste des maisons ou des hotels sur des terrains de la même famille");
     //                   }

					//}
					if (i is Gare)
                    {
						//Argent = Argent + PrixChoisi;
						//i.Proprietaire = J;
						//J.Argent = Argent - PrixChoisi;
					}

					if (i is Compagnie)
                    {
						//Argent = Argent + PrixChoisi;
						//i.Proprietaire = J;
						//J.Argent = Argent - PrixChoisi;
					}

				}
                else
					Console.WriteLine ("Vous ne pouvez pas vendre ce bien. Il appartient au joueur {0}", i.Proprietaire.Nom);
			}// fin if (x is Immobilier)

			if (x is CarteChance || x is CarteCommunaute)
            {
				if (Cartes.Contains (x) == true)
					Cartes.Remove (x);
				J.Cartes.Add (x);
				//Argent = Argent + PrixChoisi;
				//J.Argent = Argent - PrixChoisi;
			} else
				Console.WriteLine ("Cette carte ne vous appartient pas. Vous ne pouvez pas la vendre");

		}//FIN DE VENDRECARTE

        public bool Debiter(int montant)
        {
            if(montant < _Argent)
            {
                _Argent -= montant;
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Crediter(int montant)
        {
            _Argent += montant;
        }

        public void VendreHotel(Propriete P, Banque B)
        {
            Argent += P.PrixAchatHotel;
            //P.Hotel = false;
            //B.Hotels ++;
        }

        public void VendreMaison(Propriete P, Banque B)
        {
            Argent = Argent + P.PrixAchatMaison;
            P.NbMaison --;
            //B.Maisons ++;
        }

        public int NbGare()
        {
            int cpt = 0;
            foreach(Immobilier p in Possessions)
            {
                if(p is Gare)
                {
                    cpt++;
                }
            }
            return cpt;
        }

        public int NbCompagnie()
        {
            int cpt = 0;
            foreach (Immobilier p in Possessions)
            {
                if (p is Compagnie)
                {
                    cpt++;
                }
            }
            return cpt;
        }

        //public void VendreConstruction(Propriete p)
        //{
        //	if (p.Hotel == true)
        //          {
        //		Argent = Argent + p.PrixAchatHotel;
        //		p.Hotel = false;
        //		Banque.RecupereHotel(); //On cherche à faire appel à la méthode qui se trouve dans la classe Banque
        //	}
        //	if (p.NbMaison > 0)
        //          {
        //		Argent = Argent + p.PrixAchatMaison;
        //		p.NbMaison = p.NbMaison - 1;
        //		Banque.RecupereMaison();
        //	}
        //}

        /*
		public static void Hypothequer(Immobilier x)
		{
			if (x.nbMaison == 0 && x.nbHotel == 0) 
			{
				
			}
		}
*/
    }
}

//Ce que fait le joueur une fois qu'il s'est déplacé
//public void Action(int position, Cartes[] Plateau)

//{
//        //Si la case est une carte chance
//        if (C is CarteChance)
//        {
//            Console.WriteLine("Vous tirez une carte chance");
//            //On caste la case comme une carte chance
//            CarteChance CCh = (CarteChance)C;
//            Console.WriteLine(CCh.PiocheCarteChance[0].Nom);
//            //On ajoute la première carte à la fin de la pioche
//            CCh.PiocheCarteChance.Add(CCh.PiocheCarteChance[0]);
//            //On supprime la première carte qui est maintenant à la fin de la pioche
//            CCh.PiocheCarteChance.RemoveAt(0);
//        }
//        if (C is CarteCommunaute)
//        {
//            Console.WriteLine("Vous tirez une carte de communauté");
//            CarteCommunaute CCo = (CarteCommunaute)C;
//        }
//}

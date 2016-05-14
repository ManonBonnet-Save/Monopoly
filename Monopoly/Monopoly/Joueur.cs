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
		private string _Pion;
		private int _Argent;
		private int _Position;
		private bool _Prison;
		private int _CompteurPrison;
		private int _CompteurDouble;
		private List<Cartes> _Cartes; //possessions
		private List<Immobilier> _Possessions;

		//*****Constructeur de la classe*****
		public Joueur(string couleur)
		{
			_NumeroJoueur = numero;
			numero = numero + 1;
			_Pion = couleur;
			_Argent = 1500;
			_Position = 0;
			_Prison = false;
			_CompteurPrison = 0;
			_CompteurDouble = 0;
			_Cartes = new List<Cartes> ();
			_Possessions = new List<Immobilier> ();
		}

	

		//Accesseurs des instances
		public string Pion
		{
			get { return _Pion; }
			set { _Pion = value; }
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
		public bool Prison {
			get { return _Prison; }
			set { _Prison = value; }
		}
		public int CompteurPrison {
			get { return _CompteurPrison; }
			set { _CompteurPrison = value; }
		}
		public int CompteurDouble {
			get { return _CompteurDouble; }
			set { _CompteurDouble = value; }
		
		}
		public List<Immobilier> Possessions{
			get { return _Possessions; }
			set { _Possessions = value; }

			}

		public List<Cartes> Cartes{
			get { return _Cartes; }
			set { _Cartes = value; }

		}
		//*****Methodes et fonctions*****
		//Gère le déplacement du joueur
		public void Deplacer(Cartes[]Plateau)
		{
			if (CompteurDouble == 3 && Prison == true)
				CompteurDouble = 0;
			//Si le joueur a passé 3 tours en prison
			if (CompteurPrison == 3) {
				//le compteur prison repasse à 0
				CompteurPrison = 0;
				//La condition prison devient fausse
				Prison = false;
				Console.WriteLine ("Vous sortez de prison");
			}
			Random random = new Random ();
			//Le joueur lance deux dés de 6 faces 
			int De1 = random.Next (1, 7);
			int De2 = random.Next (1, 7);
			//Affchage du résultat du tirage des deux dès
			Console.WriteLine ("Vous avez fait un {0} et un {1}.", De1, De2);
			//Calcul de la somme des deux dés
			int De = De1 + De2;
			if (Prison == false) {
				//On regarde la nouvelle position du joueur
				int NouvellePosition = Position + De;
				//Si la nouvelle position est supérieur à 40
				if (NouvellePosition >= 40) {
					//La position devient la nouvelle position moins 40 qui correspond au nombre de case
					Position = NouvellePosition - 40;
					//A ce moment là on passe par la case 0 donc on ajoute 200
					this.Argent = this.Argent + 200;
				}
				//Sinon la position du joueur est son ancienne position plus la sommes du lancé des dés
				else
						Position = Position + De;			
			}
			//Si les dés ne sont pas identiques et que le joueur est en prison 
			if (De1 != De2 && Prison == true) {
				//Le compteur de tour en prison est augmenté de 1
				CompteurPrison = CompteurPrison + 1;
				Console.WriteLine ("Vous restez en prison");
			}
			if (Position == 20 && Prison == false) {
				Prison = true;
				Console.WriteLine ("Vous allez en prison");
			}
			//Si les deux dés sont égaux
			if (De1 == De2) 
			{
				if (Prison == false) {
					//le compteur de double du joueur est incrémenté de 1
					CompteurDouble = CompteurDouble + 1;
					//Si le compteur de double est à 3
					if (CompteurDouble == 3) {
						//On passe la condition prison à vraie
						Prison = true;
						Console.WriteLine ("Vous avez fait un troisième double avec les dés {0}, vous allez en prison", De1);
						//La position du joueur devient celle de la case prison
						Position = 20;
					} 
					else {
						Console.WriteLine ("Vous avez fait un double {0}. Vous pouvez lancer les dés.", De1);
						//Le joueur fait une action
						Action(Position,Plateau);
						Console.WriteLine (Position);
						Console.ReadLine ();
						//Le joueur se déplace à nouveau
						Deplacer (Plateau);
					}
				}
				if (Prison == true && CompteurDouble < 3)
				{
						Console.WriteLine ("Vous sortez de prison et avancez de {0} cases.", De);
						int NouvellePosition = Position + De;
						//Si la nouvelle position est supérieur à 40
						if (NouvellePosition >= 40) {
							//La position devient la nouvelle position moins 40 qui correspond au nombre de case
							Position = NouvellePosition - 40;
							//A ce moment là on passe par la case 0 donc on ajoute 200
							Argent = Argent + 200;
						} else
							Position = Position + De;
						Prison = false;
				} 
			}

			//Le compteur de double devient à 0 à la fin du déplacement du joueur
			if (Prison == false)
				CompteurDouble = 0;
			if (Position == 0)
				Console.WriteLine ("Vous êtes sur la case départ.");
		}	
		//Ce que fait le joueur une fois qu'il s'est déplacé
		public void Action(int position, Cartes[] Plateau)

		{
			Cartes C = Plateau [Position];
			//Si le joueur n'est pas en prison ou sur la case de départ
			if (Position != 20 && Position != 0) {
				//Si la case est une gare ou une propriété
				if (C is Gare || C is Propriete) {
					//On caste la case comme un immobilier
					Immobilier I = (Immobilier)C;
					//On achète la case

					if (I.Proprietaire == null)
						Acheter (I);
					else if (I.Proprietaire != this)
						//Payer (I.proprietaire);
						Console.WriteLine ("Vous devez de l'argent à {0}", I.Proprietaire);
					
					else if (I.Proprietaire == this)
						Console.WriteLine ("Ce bien vous appartient");
				}
				//Si la case est une carte chance
				if (C is CarteChance) {
					Console.WriteLine ("Vous tirez une carte chance");
					//On caste la case comme une carte chance
					CarteChance CCh = (CarteChance)C;
					Console.WriteLine (CCh.PiocheCarteChance[0].Nom);
					//On ajoute la première carte à la fin de la pioche
					CCh.PiocheCarteChance.Add (CCh.PiocheCarteChance [0]);
					//On supprime la première carte qui est maintenant à la fin de la pioche
					CCh.PiocheCarteChance.RemoveAt (0);
				}
				if (C is CarteCommunaute) {
					Console.WriteLine ("Vous tirez une carte de communauté");
					CarteCommunaute CCo = (CarteCommunaute)C;
				}
				if (C == null) {
					Console.WriteLine ("Rajouter la carte ou la case");
				}

			}
		}
		public void Acheter(Immobilier x)
		{
			if (x.Proprietaire == null)
			{
				Console.WriteLine ("Vous pouvez acheter ce bien");
				if (Argent >= x.PrixAchat) 
				{
					x.Proprietaire = this;
					Argent = Argent - x.PrixAchat;
					Console.WriteLine ("Vous avez acheté {0}.", x.Nom);

				}
				else Console.WriteLine("Vous ne possédez pas l'argent nécessaire pour acheter ce bien.");
			}
			else Console.WriteLine("Vous ne pouvez pas acheter ce bien. Il appartient au joueur {0}", x.Proprietaire.Pion);
		}

		public void VendreCarte(Cartes x, Joueur J, int PrixChoisi)
		{
			if (x is Immobilier) {
				Immobilier i = (Immobilier)x;

				if (i.Proprietaire == this) {
					if (i is Propriete) {
						Propriete p = (Propriete)i;

						/*foreach (Propriete f in p.CaseFamille) { // si maisons sur une autre carte du groupe
							if (f.NbMaison == 0 && f.Hotel == 0) {
								Console.WriteLine ("Vous pouvez vendre ce bien");
								Argent = Argent + PrixChoisi;
								p.Proprietaire = J;
								J.Argent = Argent - PrixChoisi;
							} else
								Console.WriteLine ("Il vous reste des maisons ou des hotels sur des terrains de la même famille");
						}*/
						if (p.NbMaison == 0 && p.Hotel == 0) {
							Console.WriteLine ("Vous pouvez vendre ce bien");
							Argent = Argent + PrixChoisi;
							p.Proprietaire = J;
							J.Argent = Argent - PrixChoisi;
						} else {
							Console.WriteLine ("Il vous reste des maisons ou un hotel sur ce terrain");
							//rajouter fonction vendre maison ou hotel
							VendreConstruction (p);
						}
							
					}
				}
				if (i is Gare) {
					Argent = Argent + PrixChoisi;
					i.Proprietaire = J;
					J.Argent = Argent - PrixChoisi;
				}

				if (i is Compagnie) {
					Argent = Argent + PrixChoisi;
					i.Proprietaire = J;
					J.Argent = Argent - PrixChoisi;
				}

			} else {
				Console.WriteLine ("Vous ne pouvez pas vendre ce bien. Il appartient au joueur {0}", i.Proprietaire.Pion);
			}
			}// fin if (x is Immobilier)

			/*if (x is CarteChance || x is CarteCommunaute) {
				if (Cartes.Contains (x) == true)
					Cartes.Remove (x);
				J.Cartes.Add (x);
				Argent = Argent + PrixChoisi;
				J.Argent = Argent - PrixChoisi;
			} else
				Console.WriteLine ("Cette carte ne vous appartient pas. Vous ne pouvez pas la vendre");
*/
		}//FIN DE VENDRECARTE

		public void VendreConstruction(Propriete p)
		{
			if (p.Hotel == true) {
				Argent = Argent + p.PrixAchatHotel;
				p.Hotel = false;
				Banque.RecupereHotel ();
			}
			if (p.NbMaison > 0) {
				Argent = Argent + p.prixAchatMaison;
				p.NbMaison = p.NbMaison - 1;
				Banque.RecupereMaison();
			}

		}

		public void Payer(Joueur J,Cartes[] Plateau)// mettre le plateau en accessible pour l'enlever après
		{
			Cartes C = Plateau [Position];
			Immobilier I = (Immobilier)C;
			Argent = Argent - I.Loyer;
			J.Argent = J.Argent + I.Loyer;		
		}
		/*
		public static void Hypothequer(Immobilier x)
		{
			if (x.nbMaison == 0 && x.nbHotel == 0) 
			{
				
			}
		}
*/


		public static void Constuire()
		{
		}

		public static void Abandonner()
		{
			// effacer toutce qui concerne ce joueur dans la partie. La banque récupère ses propriétés et son argent.
		}

		public static void ConsulterRegles()
		{
			// ouvrir un fichier texte contenant les règles du jeu.
		}
	}
}


﻿using System;
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
		private static int numero = 1;
		private int _NumeroJoueur;
		private string _Pion;
		private int _Argent;
		private int _Position;
		private bool _Prison;
		private int _CompteurPrison;
		private int _CompteurDouble;
		//private List<Cartes> _Cartes;

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
			//_Cartes = new List<Cartes> ();
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


		//*****Methodes et fonctions*****
		//Gère le déplacement du joueur
		public void Deplacer()
		{
			//Si le compteur de double est à 3
			if (CompteurDouble == 3) {
				//On passe la condition prison à vraie
				Prison = true;
				Console.WriteLine ("Vous allez en prison");
				//La position du joueur devient celle de la case prison
				Position = 20;
			}
			//Si le joueur a passé 3 tours en prison
			if (CompteurPrison == 3) {
				//le compteur prison repasse à 0
				CompteurPrison = 0;
				//La condition prison devient fausse
				Prison = false;
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
				//Si les deux dés sont égaux
			}
			if (Position == 20)
				Prison = true;
			if (De1 == De2) 
			{
				if (Prison == false) {
					//le compteur de double du joueur est incrémenté de 1
					CompteurDouble = CompteurDouble + 1;
					Console.WriteLine ("Vous avez fait un double {0}. Vous pouvez lancer les dés.", De1);
					//Le joueur se déplace à nouveau
					Deplacer ();
				}
				else {
					Console.WriteLine ("Vous sortez de prison et avancez de {0} cases.", De);
					int NouvellePosition = Position + De;
					//Si la nouvelle position est supérieur à 40
					if (NouvellePosition >= 40) {
						//La position devient la nouvelle position moins 40 qui correspond au nombre de case
						Position = NouvellePosition - 40;
						//A ce moment là on passe par la case 0 donc on ajoute 200
						Argent = Argent + 200;
					}
					else
						Position = Position + De;
					Prison = false;
				} 
			}
			//Si les dés ne sont pas identiques et que le joueur est en prison 
			if (De1 != De2 && Prison == true) {
				//Le compteur de tour en prison est augmenté de 1
				CompteurPrison = CompteurPrison + 1;
			}
			//Le compteur de double devient à 0 à la fin du déplacement du joueur
			CompteurDouble = 0;
		}	
		//Ce que fait le joueur une fois qu'il s'est déplacé
		public void Action()
		{
			int EmplacementJoueur = Position;

		}
		/*
		public static void Acheter(Immobilier x)
		{
			
			if (x.proprietaire == "")
			{
				if (Argent > x.prixAchat) 
				{
				
					x.proprietaire = Joueur.Pion;
					Console.WriteLine ("Vous avez acheté {0}.", x.nom);
				}
				else Console.WriteLine("Vous ne possédez pas l'argent nécessaire pour acheter ce bien.");
			}
			else Console.WriteLine("Vous ne pouvez pas acheter ce bien. Il appartient au joueur {0}", x.nom);
		}
		*/
		public static void Vendre()
		{
			
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


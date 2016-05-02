using System;

namespace Monopoly
{
	public class Joueur
	{
		public string Pion { get; protected set;}
		public int Argent{ get; set;}
		public int Position;
		public bool Prison{ get; protected set;}
		public int CompteurPrison{ get; protected set;}

		public Joueur(string couleur)

		{
			Pion = couleur;
			Argent = 1500;
			Position = 0;
			Prison = false;
			CompteurPrison = 0;
		}

		public static void Acheter(Immobilier x)
		{
			if (x.proprietaire != "")
			{
				if (Argent > x.prixAchat) 
				{
				
					x.proprietaire = Joueur.Pion;
					Console.WriteLine ("Vous avez acheté {0}.", x.nom);
				}
			}
			else Console.WriteLine("Vous ne possédez pas l'argent nécessaire pour acheter ce bien.");
		}

		public static void Vendre()
		{
			
		}

		public static void Hypothéquer()
		{
		}

		public static int Lancer()
		{
			Random random = new Random();

			int De1 = random.Next(1, 7);
			int De2 = random.Next(1,7);

			int De = De1 + De2;

			if (De1 == De2) 
			{
				Console.WriteLine ("Vous avez fait un double {0}. Vous pouvez relancer les dés une fois vos opérations terminées.",De1);
				Position = Position + De;
				// Le joueur peut faire ce qu'il veut
				Joueur.Lancer ();
			}
			Position = Position + De;

			return Position;
		}

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


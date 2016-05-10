using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			//Création de la pioche des cartes communautés
			CarteCommunaute _CCo = new CarteCommunaute ("Cartes Communautés");
			//Création de la pioche des cartes chances
			CarteChance _CCh = new CarteChance ("Cartes Chances");
			_CCh.PiocheCarteChance.Add(new CarteChance("prison"));
			_CCh.PiocheCarteChance.Add(new CarteChance("prison2"));
			//Création du tableau de jeu
			Cartes[] _Plateau = new Cartes[40];
			_Plateau [0] = null; // à créer
			_Plateau [1] = new Propriete ("B",100);
			_Plateau [2] = _CCo;
			_Plateau [3] = new Propriete ("B",100);
			_Plateau [4] = null;
			_Plateau [5] = new Gare("Gare Montparnasse",100);
			_Plateau [6] = new Propriete ("B",100);
			_Plateau [7] = _CCh;
			_Plateau [8] = new Propriete ("B",100);
			_Plateau [9] = new Propriete ("B",100);
			_Plateau [10] = null;
			_Plateau [11] = new Propriete ("B",100);
			_Plateau [12] = _CCo;
			_Plateau [13] = new Propriete(100,10,10,"A",100);
			_Plateau [14] = new Propriete ("B",100);
			_Plateau [15] = new Gare ("Gare de Lyon",100);
			_Plateau [16] = new Propriete  ("B",100);
			_Plateau [17] = _CCo;
			_Plateau [18] = new Propriete  ("B",100);
			_Plateau [19] = new Propriete  ("B",100);
			_Plateau [20] = null;
			_Plateau [21] = new Propriete ("B",100);
			_Plateau [22] = _CCh;
			_Plateau [23] = new Propriete  ("B",100);
			_Plateau [24] = new Propriete ("B",100);
			_Plateau [25] = new Gare ("Gare du Nord",100);
			_Plateau [26] = new Propriete  ("B",100);
			_Plateau [27] = new Propriete  ("B",100);
			_Plateau [28] = null;
			_Plateau [29] = new Propriete  ("B",100);
			_Plateau [30] = null;
			_Plateau [31] = new Propriete ("B",100);
			_Plateau [32] = new Propriete ("B",100);
			_Plateau [33] = _CCo;
			_Plateau [34] = new Propriete ("B",100);
			_Plateau [35] = new Gare ("Gare Saint-Lazare",100);
			_Plateau [36] = _CCh;
			_Plateau [37] = new Propriete  ("B",100);
			_Plateau [38] = null;
			_Plateau [39] = new Propriete  ("B",100);



			Joueur J = new Joueur ("red");
			for (int i = 0; i < 60; i++) {

				J.Deplacer (_Plateau);
				J.Action (J.Position,_Plateau);
				Console.WriteLine (J.Position);
				Console.ReadLine ();
				}
			}
		}
	}

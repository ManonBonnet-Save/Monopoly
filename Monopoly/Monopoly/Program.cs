﻿using System;
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
			List<CarteCommunaute> _CartesCommunaute = new List<CarteCommunaute> ();
			List<CarteChance> _CartesChance = new List<CarteChance> ();
			Cartes[] _Plateau = new Cartes[40];
			_Plateau [0] = null;
			_Plateau [1] = new Propriete ();
			_Plateau [2] = _CartesCommunaute;
			_Plateau [3] = new Propriete  ();
			_Plateau [4] = null;
			_Plateau [5] = new Gare ("Gare Montparnasse");
			_Plateau [6] = new Propriete  ();
			_Plateau [7] = _CartesChance;
			_Plateau [8] = new Propriete  ();
			_Plateau [9] = new Propriete  ();
			_Plateau [10] = null;
			_Plateau [11] = new Propriete ();
			_Plateau [12] = _CartesCommunaute;
			_Plateau [13] = new Propriete ();
			_Plateau [14] = new Propriete ();
			_Plateau [15] = new Gare ("Gare de Lyon");
			_Plateau [16] = new Propriete  ();
			_Plateau [17] = _CartesCommunaute;
			_Plateau [18] = new Propriete  ();
			_Plateau [19] = new Propriete  ();
			_Plateau [20] = null;
			_Plateau [21] = new Propriete ();
			_Plateau [22] = _CartesChance;
			_Plateau [23] = new Propriete  ();
			_Plateau [24] = new Propriete ();
			_Plateau [25] = new Gare ("Gare du Nord");
			_Plateau [26] = new Propriete  ();
			_Plateau [27] = new Propriete  ();
			_Plateau [28] = null;
			_Plateau [29] = new Propriete  ();
			_Plateau [30] = null;
			_Plateau [31] = new Propriete ();
			_Plateau [32] = new Propriete ();
			_Plateau [33] = _CartesCommunaute;
			_Plateau [34] = new Propriete ();
			_Plateau [35] = new Gare ("Gare Saint-Lazare");
			_Plateau [36] = _CartesChance;
			_Plateau [37] = new Propriete  ();
			_Plateau [38] = null;
			_Plateau [39] = new Propriete  ();


			Console.WriteLine ("Hello World!");
			Joueur J = new Joueur ("red");
			for (int i = 0; i < 10; i++) {

				J.Deplacer ();
				Console.ReadLine();
			}
			Console.ReadLine ();
		}
	}
}

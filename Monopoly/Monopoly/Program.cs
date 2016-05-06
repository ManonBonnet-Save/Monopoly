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
			Console.WriteLine ("Hello World!");
			Joueur J = new Joueur ("red");
			Banque B = new Banque ();
			Console.ReadLine ();
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    //Création de la classe des cartes compagnies
    public class Compagnie : Immobilier
    {
        //*****Constructeurs*****
        public Compagnie(string nom, int pa) : base(nom, pa){}

        //*****Méthodes*****
        public override int Loyer()
        {
            if (Proprietaire != null)
            {
                //Le joueur lance deux dés de 6 faces
                Random random = new Random();
                int De = random.Next(1, 7) + random.Next(1, 7);

                Console.WriteLine("Compagnie loyer : {0} au lancer et {1} compagnie(s)", De, _Proprietaire.NbCompagnie());

                if (_Proprietaire.NbCompagnie() == 1) return De * 4;
                if (_Proprietaire.NbCompagnie() == 2) return De * 10;                

                else
                {
                    Console.WriteLine("Il y a un problème, avec la comptabilisation des compagnies");
                    return 0;
                }
            }
            return 0;
        }
    }
}

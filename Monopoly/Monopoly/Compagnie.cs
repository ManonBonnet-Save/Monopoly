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
        private List<int> _CasesCompagnies;
        private int _Loyer;
        private int _NbCompagnies;

        //*****Constructeurs*****
        public Compagnie(string nom, int pa, int loyer) : base(nom, pa, loyer)
        {
            _Loyer = 0;
        }

        //*****Accesseurs*****


        //*****Méthodes*****
        public override int modificationLoyer()
        {
            if (Proprietaire != null)
            {
                foreach (Immobilier element in Proprietaire.Possessions)
                {
                    if (element is Compagnie)
                    {
                        _NbCompagnies += 1;
                    }
                }
                // On ne teste pas pour 0, puisque dans ce cas le propriétaire est null.

                if (_NbCompagnies == 1) //Pour une seule compagnie le Loyer= 4*(somme des dés)
                {
                    //Le joueur lance deux dés de 6 faces
                    Random random = new Random();
                    int De1 = random.Next(1, 7);
                    int De2 = random.Next(1, 7);
                    int De = De1 + De2;
                    Loyer = 4 * De;
                    return Loyer;
                }

                if (_NbCompagnies == 2) //Pour une deux compagnies le Loyer= 10*(somme des dés)
                {
                    //Le joueur lance deux dés de 6 faces
                    Random random = new Random();
                    int De1 = random.Next(1, 7);
                    int De2 = random.Next(1, 7);
                    int De = De1 + De2;
                    Loyer = 10 * De;
                    return Loyer;
                }
                else
                {
                    Console.WriteLine("Il y a un problème, avec la comptabilisation des compagnies");
                    return Loyer = 0;
                }
            }
            else
            {
                Loyer = 0;
                return Loyer;
            }
        }
    }
}

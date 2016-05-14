using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    //Création de la classe des cartes gares
    public class Gare : Immobilier
    {
        private List<int> _CasesGares;
        private int _Loyer;

        //*****Constructeurs*****
        public Gare(string nom, int pa, int loyer) : base(nom, pa, loyer)
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
                        if (element is Gare)
                        {
                            NbGares += 1;
                        }
                    }
                    Loyer = 25 * 2 ^ (NbGares - 1); //Le loyer dépend de la quantité de gare que possède la personne: 25,50,100,200
                    return Loyer;
                }
                else
                {
                    Loyer = 0;
                    return Loyer;
                }
        }
    }
}

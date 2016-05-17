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
        //*****Constructeurs*****
        public Gare(string nom, int pa) : base(nom, pa) {}

        //*****Méthodes*****
        public override int Loyer()
        {
            if (Proprietaire != null)
            {
                return 25 * (int) Math.Pow(2,_Proprietaire.NbGare() - 1); //Le loyer dépend de la quantité de gare que possède la personne: 25,50,100,200
            }
            return 0;
        }
    }
}

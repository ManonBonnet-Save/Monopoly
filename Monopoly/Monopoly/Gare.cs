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
        private int _Loyer;
        private int _NbGares;

        //*****Constructeurs*****
        public Gare(string nom, int pa, int loyer) : base(nom, pa, loyer)
        {
            _Loyer = 0;
        }

        //*****Accesseurs*****
        public new int Loyer
        {
            get { return _Loyer; }
            set { _Loyer = modificationLoyer(); }
        }
        //*****Méthodes*****
        public override int modificationLoyer()
        {
                if (Proprietaire != null)
                {
                    foreach (Immobilier element in Proprietaire.Possessions)
                    {
                        if (element is Gare)
                        {
                            _NbGares += 1;
                        }
                    }
                    Loyer = 25 * 2 ^ (_NbGares - 1); //Le loyer dépend de la quantité de gare que possède la personne: 25,50,100,200
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

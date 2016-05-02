using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    abstract class Cartes
    {
        //Attribus
        public abstract string nom { get; protected set; }

        //Constructeurs

        //Methodes

    }

    abstract class Immobilier : Cartes
    {
        public override abstract string nom { get; protected set; }

    }

    class Propriete : Immobilier
    {
        public override string nom { get; protected set; }
        public int prixAchat { get; protected set; }
        public int loyer { get; protected set; }
        public int nbmaison { get; protected set; }
        public int prixAchatMaison { get; protected set; }
        public int nbhotel { get; protected set; }
        public int prixAchatHotel { get; protected set; }
        public string proprietaire { get; protected set; }

        //Constructeurs
        public Propriete(string nomDeLaRue, int montantAcheter, int montantLoyer, int prix1Maison, int prixHotel)
        {
            nom = nomDeLaRue;
            prixAchat = montantAcheter;
            loyer = montantLoyer;
            nbmaison = 0;
            prixAchatMaison = prix1Maison;
            nbhotel = 0;
            prixAchatHotel = prixHotel;
            proprietaire = "";

        }

        //Méthodes
        public void modificationLoyer()
        {

        }

    }

    class Gares : Immobilier
    {
        public override string nom { get; protected set; }

        //Constructeurs
        public Gares(string nomDeLaGare)
        {
            nom = nomDeLaGare;
        }
    }

    class Compagnie : Immobilier
    {
        public override string nom { get; protected set; }

        //Constructeurs
        public Compagnie(string nomDeLaCompagnie)
        {
            nom = nomDeLaCompagnie;
        }
    }

    class Chance : Cartes
    {
        public override string nom { get; protected set; }
    }

    class CaisseCommunaute : Cartes
    {
        public override string nom { get; protected set; }
    }
}

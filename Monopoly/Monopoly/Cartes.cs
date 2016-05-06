using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    public abstract class Cartes //test hey!
    {
        //Attribus
        public abstract string nom { get; protected set; }

        //Constructeurs

        //Methodes

    }
	public class CartesChance : Cartes
	{
		public CartesChance ()
		{
		}
		public override string nom { get; protected set; }

	}
	public class CartesCommunaute : Cartes
	{
		public CartesCommunaute ()
		{
		}
		public override string nom { get; protected set; }

	}

    public abstract class Immobilier : Cartes
    {
        public override abstract string nom { get; protected set; }

    }

    public class Propriete : Immobilier
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

    public class Gares : Immobilier
    {
        public override string nom { get; protected set; }

        //Constructeurs
        public Gares(string nomDeLaGare)
        {
            nom = nomDeLaGare;
        }
    }

    public class Compagnie : Immobilier
    {
        public override string nom { get; protected set; }

        //Constructeurs
        public Compagnie(string nomDeLaCompagnie)
        {
            nom = nomDeLaCompagnie;
        }
    }
	/*
	//ça ne marche pas, j'ai crée une nouvelle classe
    public class CartesCommunaute : Cartes
    {
        public override string nom { get; protected set; }
    }

		*/

	}

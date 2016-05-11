using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    //Création des cartes immobilières
    public class Immobilier : Cartes
    {
        protected Joueur _Proprietaire;
        protected int _PrixAchat;
        private int _Loyer;
        private int _NbMaison;
        private int _NbGares;
        private int _NbCompagnies;

        //*****Constructeur*****
        public Immobilier(string nom, int prixAchat, int loyer) : base(nom)
        {
            _Proprietaire = null;
            _PrixAchat = prixAchat;
            _Loyer = loyer;
            _NbMaison = 0;
            _NbGares = 0;
        }
        //*****Accesseurs*****
        public Joueur Proprietaire
        {
            get { return _Proprietaire; }
            set { _Proprietaire = value; }
        }
        public int PrixAchat
        {
            get { return _PrixAchat; }
            set { _PrixAchat = value; }
        }
        public int Loyer
        {
            get { return _Loyer; }
            set { _Loyer = modificationLoyer(); }
        }
        public int NbMaison
        {
            get { return _NbMaison; }
            set { _NbMaison = value; }
        }
        public int NbGares
        {
            get { return _NbGares; }
            set { _NbGares = value; }
        }
        public int NbCompagnies
        {
            get { return _NbCompagnies; }
            set { _NbCompagnies = value; }
        }

        //*****Méthodes***** //Virtual Override
        public int modificationLoyer()
        {
            if (this is Propriete)
            {
                if (NbMaison > 0)
                {
                    Loyer = Loyer + (NbMaison * 100); //Vérifier si le loyer évolue de la même manière sur tous les terrains. 
                                                      // Si c'est le cas, alors faire une méthode identique juste selon le nombre de maison. 
                    return Loyer;
                }
                //return Loyer;
            }
            if (this is Gare)
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
            else
            {
                if (Proprietaire != null)
                {
                    foreach (Immobilier element in Proprietaire.Possessions)
                    {
                        if (element is Compagnie)
                        {
                            NbCompagnies += 1;
                        }
                    }
                    // On ne teste pas pour 0, puisque dans ce cas le propriétaire est null.

                    if (NbCompagnies == 1) //Pour une seule compagnie le Loyer= 4*(somme des dés)
                    {
                        //Le joueur lance deux dés de 6 faces
                        Random random = new Random();
                        int De1 = random.Next(1, 7);
                        int De2 = random.Next(1, 7);
                        int De = De1 + De2;
                        Loyer = 4 * De;
                        return Loyer;
                    }

                    if (NbCompagnies == 2) //Pour une deux compagnies le Loyer= 10*(somme des dés)
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
}

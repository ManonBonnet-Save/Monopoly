using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    class Partie
    {
        public List<Joueur> ListeJoueurs;
        public Plateau plateau; 

        public Partie ()
        {
            ListeJoueurs = new List<Joueur>();
            plateau = new Plateau(40);
        }

        public void Demarrer()
        {
            Initialisation();
            BouclePrincipale();
            Fin();
        }

        public void Initialisation()
        {
            Console.WriteLine("Combien de joueurs vont participer à la partie ?");
            int NbJoueurs = int.Parse(Console.ReadLine());
            for (int CptJ = 0; CptJ < NbJoueurs; ++CptJ)
            {
                Console.WriteLine("Quelle est la couleur du joueur {0} ?", CptJ+1);
                string CouleurDuJoueur = Console.ReadLine();
                ListeJoueurs.Add(new Joueur(CouleurDuJoueur));
            }

        }
        public void BouclePrincipale()
        {
            int joueurActuel = 0;
            ListeJoueurs[joueurActuel].CompteurDouble = 0;
            while (ListeJoueurs.Count > 1)
            {
                //Si le joueur vient de passer 3 tours en prison. Il sort. 
                if (ListeJoueurs[joueurActuel].CompteurPrison == 4)
                {
                    Console.WriteLine("Vous sortez de prison!");
                    ListeJoueurs[joueurActuel].CompteurPrison = 0;
                }

                //Lancé de dés.
                Random random = new Random();
                int De1 = 6;//random.Next(1, 7);
                int De2 = 6;//random.Next(1, 7);
                Console.WriteLine("Le joueur {2} joue et fait un {0} et un {1}.", De1, De2, ListeJoueurs[joueurActuel].NumeroJoueur);
                int De = De1 + De2;

                if (De1 == De2)
                {
                    if (ListeJoueurs[joueurActuel].CompteurPrison > 0)
                    {
                        Console.WriteLine("Vous sortez de prison et avancez de {0} cases.", De);
                        ListeJoueurs[joueurActuel].CompteurPrison = 0;
                    }
                    if (ListeJoueurs[joueurActuel].CompteurDouble == 2)
                    {
                        Console.WriteLine("Vous avez fait un troisième double, de {0}, vous allez en prison sans passer par la case départ!", De1);
                        ListeJoueurs[joueurActuel].CompteurDouble = 0;
                        ListeJoueurs[joueurActuel].CompteurPrison = 1;
                        ListeJoueurs[joueurActuel].Position = 11; //Déplacement du joueur sur la case prison.
                        continue;
                    }
                    else { ListeJoueurs[joueurActuel].CompteurDouble++; }
                    Console.WriteLine("Le compteur prison est {0} ", ListeJoueurs[joueurActuel].CompteurPrison);

                    if (De1 != De2) //On remet le compteur de double à 0 après un lancé de dés différents.
                    {
                        ListeJoueurs[joueurActuel].CompteurDouble = 0;
                    }
                    //Si on ne fait pas un double.
                    if (ListeJoueurs[joueurActuel].CompteurPrison > 0)
                    {
                        ListeJoueurs[joueurActuel].CompteurPrison++;
                        continue;
                    }


                    //Avancée sur le plateau
                    ListeJoueurs[joueurActuel].Position = (ListeJoueurs[joueurActuel].Position + De) % plateau.NbCases(); //Retourne au début du plateau s'il arrive à la fin.
                                                                                                                          //On passe par la case départ, on reçoit 200 euros.
                    if (ListeJoueurs[joueurActuel].Position < De)
                    {
                        ListeJoueurs[joueurActuel].Argent += 200;
                        Console.WriteLine("Vous êtes passé par la case départ, recevez 200 euros !");
                    }
                    Console.WriteLine("Le joueur {0} est à la case {1}", ListeJoueurs[joueurActuel].NumeroJoueur, plateau.getCase(ListeJoueurs[joueurActuel].Position));




                    if (De1 == De2 && ListeJoueurs[joueurActuel].CompteurPrison < 1)
                    {
                        joueurActuel = (joueurActuel) % ListeJoueurs.Count();
                    }
                    else { joueurActuel = (joueurActuel + 1) % ListeJoueurs.Count(); } //Avec le modulo, une fois au dernier joueur on recommence avec le premier.
                    Console.ReadLine();
                }
            }
        }
        public void Fin()
        {
            Console.WriteLine("Le joueur {0} a gagné la partie!", ListeJoueurs[0].NumeroJoueur);
            Console.ReadLine();
        }

    }
}

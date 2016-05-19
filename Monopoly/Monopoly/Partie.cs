using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    class Partie
    {
        private List<Joueur> ListeJoueurs;
        private Plateau plateau; 
        private Banque _banque;
        

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
                Console.WriteLine("Quelle est le nom du joueur {0} ?", CptJ+1);
                string NomduJoueur = Console.ReadLine();
                ListeJoueurs.Add(new Joueur(NomduJoueur));
            }

            _banque = new Banque();
        }
        public void BouclePrincipale()
        {
            int joueurActuel = 0;
            ListeJoueurs[joueurActuel].CompteurDouble = 0;
            while (ListeJoueurs.Count > 1)
            {
                Joueur j = ListeJoueurs[joueurActuel];
                //Si le joueur vient de passer 3 tours en prison. Il sort. 
                if (j.CompteurPrison == 4)
                {
                    Console.WriteLine("Vous sortez de prison!");
                    j.CompteurPrison = 0;
                }

                //Lancé de dés.
                Random random = new Random();
                int De1 = random.Next(1, 7);
                int De2 = random.Next(1, 7);
                Console.WriteLine("Le joueur {2} joue et fait un {0} et un {1}.", De1, De2, j.Nom);
                int De = De1 + De2;

                if (De1 == De2)
                {
                    if (j.EstEnPrison())
                    {
                        Console.WriteLine("Vous sortez de prison et avancez de {0} cases.", De);
                        j.CompteurPrison = 0;
                    }
                    if (j.CompteurDouble == 2)
                    {
                        Console.WriteLine("Vous avez fait un troisième double, de {0}, vous allez en prison sans passer par la case départ!", De1);
                        j.CompteurDouble = 0;
                        j.CompteurPrison = 1;
                        j.Position = 10; //Déplacement du joueur sur la case prison.
                    }
                    else { j.CompteurDouble++; }
                }
                else
                {
                    //On remet le compteur de double à 0 après un lancé de dés différents.
                    j.CompteurDouble = 0;

                    //On s'ennuie en prison
                    if (j.EstEnPrison())
                    {
                        j.CompteurPrison++;
                    }
                }

                if (!j.EstEnPrison())
                {
                    //Avancée sur le plateau
                    j.Position = (j.Position + De) % plateau.NbCases(); //Retourne au début du plateau s'il arrive à la fin.

                    if (j.Position < De)//On passe par la case départ, on reçoit 200 euros.
                    {
                        j.Crediter(200);
                        Console.WriteLine("Vous êtes passé par la case départ, recevez 200 euros !");
                    }
                    Console.WriteLine("Le joueur {0} est à la case : {1}", j.Nom, plateau.getCase(j.Position).Nom);
                    bool ok = plateau.getCase(j.Position).action(j);
                    if (!ok)
                    {
                        while (!ok && j.NbMaison>0)
                        {
                            Console.WriteLine("Vous n'avez pas assez d'argent pour payer vos dettes.");
                            //Vendre des maison
                            Console.WriteLine("Voulez-vous vendre des maisons/hôtels? [o/N]");
                            ConsoleKeyInfo ckj = Console.ReadKey();
                            if (ckj.KeyChar == 'o' || ckj.KeyChar == 'O')
                            {
                                //Sortir une liste des terrains sur lesquel j peut placer des maisons: famille complète.
                                Console.WriteLine("Veuillez séléctionner le terrain sur lequel vous voulez vendre des maisons.");
                                Console.WriteLine("0 - Aucun");
                                List<Propriete> terrains_avec_maison = new List<Propriete>();
                                int Cpt = 0;
                                foreach (Immobilier p in j.Possessions)
                                {
                                    if (p is Propriete && ((Propriete)p).NbMaison > 0)
                                    {
                                        terrains_avec_maison.Add((Propriete)p);
                                        Console.WriteLine("{0} - {1}", Cpt + 1, terrains_avec_maison[Cpt++].Nom);
                                    }
                                }

                                int indiceTerrain = Int32.Parse(Console.ReadLine());
                                if (indiceTerrain > 0 && indiceTerrain < Cpt)
                                {
                                    Console.WriteLine("Vous avez choisi {0} - {1}", indiceTerrain, terrains_avec_maison[indiceTerrain - 1].Nom);
                                    _banque.RecupereMaison((Propriete)terrains_avec_maison[indiceTerrain - 1]);
                                    Console.WriteLine("Le terrain possède maintenant {0} maisons", terrains_avec_maison[indiceTerrain - 1].NbMaison);
                                }
                            }
                            ok = plateau.getCase(j.Position).action(j);
                        }
                        
                        bool ok2 = plateau.getCase(j.Position).action(j);
                        if (!ok2)
                        {
                            //Suppression des possessions du joueur qui as perdu
                            foreach (Immobilier I in j.Possessions)
                            {
                                foreach (Propriete P in j.Possessions)
                                {
                                    while (P.NbMaison > 0)
                                    {
                                        _banque.RecupereMaison(P);
                                    }
                                }
                                I.Proprietaire = null;
                                j.Possessions.Remove(I);
                            }
                            Console.WriteLine("Le joueur {0} à perdu", j.Nom);
                            ListeJoueurs.RemoveAt(joueurActuel);
                            joueurActuel = joueurActuel % ListeJoueurs.Count();
                            continue;
                        }
                    }
                }

                //Acheter des maison
                //Sortir une liste des terrains sur lesquel j peut placer des maisons: famille complète.
                
                List<Propriete> terrains_constructible = new List<Propriete>();
                int cpt = 0;
                foreach (Immobilier p in j.Possessions)
                {
                    if (p is Propriete && _banque.GroupeComplet((Propriete)p) && ((Propriete)p).NbMaison < 5)
                    {
                        terrains_constructible.Add((Propriete)p);
                    }
                }

                if (terrains_constructible.Count > 1)
                {
                    Console.WriteLine("Voulez-vous acheter des maisons/hôtels? [o/N]");
                    ConsoleKeyInfo cki = Console.ReadKey();
                    if (cki.KeyChar == 'o' || cki.KeyChar == 'O')
                    {
                        Console.WriteLine("Veuillez séléctionner le terrain sur lequel vous voulez construire");
                        Console.WriteLine("0 - Aucun");
                        foreach (Propriete p in terrains_constructible)
                        {
                            Console.WriteLine("{0} - {1}", cpt + 1, terrains_constructible[cpt++].Nom);
                        }
                        int indiceTerrain = Int32.Parse(Console.ReadLine());
                        if (indiceTerrain > 0 && indiceTerrain <= cpt)
                        {
                            Console.WriteLine("Vous avez choisi {0} - {1}", indiceTerrain, terrains_constructible[indiceTerrain - 1].Nom);
                            _banque.VendreMaison((Propriete)terrains_constructible[indiceTerrain - 1]);
                            Console.WriteLine("Le terrain possède maintenant {0} maisons", terrains_constructible[indiceTerrain - 1].NbMaison);
                        }
                    }
                }

                Console.WriteLine("Le joueur {0} possède {1} euros.", j.Nom, j.Argent);


                if ((De1 != De2) || j.EstEnPrison())
                {
                    //Avec le modulo, une fois au dernier joueur on recommence avec le premier.
                    joueurActuel = (joueurActuel + 1) % ListeJoueurs.Count();
                }

                Console.ReadLine();
            }
        }
        public void Fin()
        {
            Console.WriteLine("Le joueur {0} a gagné la partie!", ListeJoueurs[0].j.Nom);
            Console.ReadLine();
        }

    }
}

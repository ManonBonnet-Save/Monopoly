using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    class CasePropriété: Case
    {
        private Immobilier _carte;

        public CasePropriété(Immobilier c) : base(c.Nom)
        {
            _carte = c;
        }

        public override bool action(Joueur j)
        {
            if(_carte.Proprietaire != null)
            {
                if (_carte.Proprietaire.NumeroJoueur == j.NumeroJoueur) //Le joueur tombe sur un terrain lui appartenant.
                {
                    Console.WriteLine("Le joueur {0} est chez lui", j.NumeroJoueur);
                    if (_carte is Propriete)
                    {
                        foreach (Propriete element in j.Possessions)
                        {
                            int NbCarteFamille = 1;
                            //On cherche à savoir si le propriétaire de la case possède tous les terrains du même groupe. 
                            if (_carte.Groupe == element.Groupe && element.NbMaison == 0)
                            {
                                NbCarteFamille++;
                            }
                            //Il faut maintenant ressortir une liste des terrains surlesquels j peut mettre des maisons. 
                        }
                    }
                    return true;
                }

                if (!j.Debiter(_carte.Loyer)) //Le joueur n'a pas assez d'argent pour payer le loyer, il donne ce qu'il lui reste et perd. 
                {
                    _carte.Proprietaire.Crediter(j.Argent);
                    Console.WriteLine("Le joueur {0} a donné ses {1} restant au joueur {2}", j.NumeroJoueur, j.Argent, _carte.Proprietaire.NumeroJoueur);
                    return false;
                }
                else
                {
                    _carte.Proprietaire.Crediter(_carte.Loyer);
                    Console.WriteLine("Le joueur {0} a payé {1} euros au joueur {2}", j.NumeroJoueur, _carte.Loyer, _carte.Proprietaire.NumeroJoueur);
                    return true;
                }
            }
            else
            {
                Console.WriteLine("Voulez-vous acheter le terrain ? ({0} euros) [o/N]", _carte.PrixAchat);
                ConsoleKeyInfo cki = Console.ReadKey();
                if ( (cki.KeyChar == 'o' || cki.KeyChar == 'O') && j.Debiter(_carte.PrixAchat))
                {
                    _carte.Proprietaire = j;
                    j.Possessions.Add(_carte);
                    Console.WriteLine("Le joueur {0} a acheté {1} pour {2} euros", j.NumeroJoueur, _carte.Nom , _carte.PrixAchat);
                }
                //if ((cki.KeyChar == 'o' || cki.KeyChar == 'O') && !j.Debiter(_carte.PrixAchat))
                //{
                //    Console.WriteLine("Vous n'avez pas assez d'argent pour acquérir ce terrain.");
                //}
            }
            return true;
        }
    }
}

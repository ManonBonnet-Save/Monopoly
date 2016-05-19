using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    class PiocheCommunaute : Pioche
    {
        private new List<CarteCommunaute> ListeCarte;
        public new int idx = 0;

        public PiocheCommunaute(string nomPioche, int nbCartes) : base(nomPioche)
        {
            ListeCarte = new List<CarteCommunaute>();
            for (int i = 0; i < nbCartes; ++i)
            {
                ListeCarte.Add(null);
            }
            init();
            Nom = nomPioche;
        }

        public void init()
        { 
            ListeCarte.Add(new CarteCommunaute("Vous gagnez le prix de Beauté. Recevez 10 euros.", false, true, 1, 0, 10));
            ListeCarte.Add(new CarteCommunaute("Vous payez votre police d'assurance 50 euros.", false, true, 1, 0, 50));
            ListeCarte.Add(new CarteCommunaute("Vous allez en prison sans passer par la case départ.", false, false, 0, 10, 0));
            ListeCarte.Add(new CarteCommunaute("Les contributions vous remboursent la somme de 20 euros.", false, true, 1, 0, 20));
            ListeCarte.Add(new CarteCommunaute("La vente de votre stock vous rapporte 50 euros.", false, true, 1, 0, 50));
            ListeCarte.Add(new CarteCommunaute("Vous héritez de 100 euros.", false, true, 1, 0, 100));
            ListeCarte.Add(new CarteCommunaute("Reculez jusqu'à Belleville .", false, false, 0, 1, 0));
            ListeCarte.Add(new CarteCommunaute("Erreur de la banque en votre faveur. Recevez 200 euros.", false, true, 1, 0, 100));
            ListeCarte.Add(new CarteCommunaute("Recevez votre intérêt sur l'emprunt à 7% : 25 euros.", false, true, 1, 0, 25));
            ListeCarte.Add(new CarteCommunaute("Vous payez l'Hôpital: 100 euros.", false, true, 1, 0, 100));
            ListeCarte.Add(new CarteCommunaute("Placez vous sur la case Départ", true, false, 0, 0, 0));
            ListeCarte.Add(new CarteCommunaute("Recevez votre revenu annuel: 100 euros.", false, true, 1, 0, 100));
        }

        public override Cartes getCarte(int idx) { return ListeCarte[idx]; }

    }
}

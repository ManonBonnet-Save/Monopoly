using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    class PiocheChance : Pioche
    {
        private new List<CarteChance> ListeCarte;
        public new int idx = 0;

        public PiocheChance(string nomPioche, int nbCartes) : base(nomPioche)
        {
            ListeCarte = new List<CarteChance>();
            for (int i = 0; i < nbCartes; ++i)
            {
                ListeCarte.Add(null);
            }
            init();
            Nom = nomPioche;
        }

        public void init()
        { 
            ListeCarte.Add(new CarteChance("Vous êtes imposé pour les réparations de voirie à raison de : 40 euros par maison et 115 euros par hôtel.", false, true, 2, 0, 0, 40, 115));
            ListeCarte.Add(new CarteChance("Allez directement en prison sans passer par la case Départ", false, false, 0, 10, 0, 0, 0));
            ListeCarte.Add(new CarteChance("Vous avez gagné le prix des mots croisés. Recevez 100 euros", false, false, 1, 0, 100, 0, 0));
            ListeCarte.Add(new CarteChance("Rendez vous rue de la Paix", true, false, 0, 39, 0, 0, 0));
            ListeCarte.Add(new CarteChance("Votre immeuble et votre prêt rapporte. Vous devez toucher 150 euros", false, false, 1, 0, 150, 0, 0));
            ListeCarte.Add(new CarteChance("Rendez vous Avenue Henri-Martin", true, false, 0, 24, 0, 0, 0));
            ListeCarte.Add(new CarteChance("La banque vous verse un dividende de 50 euros", false, false, 1, 0, 50, 0, 0));
            ListeCarte.Add(new CarteChance("Avancez jusqu'à la case Départ", true, false, 0, 0, 0, 0, 0));
            ListeCarte.Add(new CarteChance("Faitez des réparations dans toutesvos maisons. 25 euros par maison et 100 euros par hôtel.", false, true, 2, 0, 0, 25, 100));
            ListeCarte.Add(new CarteChance("Payez des frais de scolarité : 150 euros", false, false, 1, 0, -150, 0, 0));
            ListeCarte.Add(new CarteChance("Allez à la gare de Lyon", true, false, 0, 15, 0, 0, 0));
            ListeCarte.Add(new CarteChance("Amende pour ivresse : 200 euros", false, false, 1, 0, -200, 0, 0));
            ListeCarte.Add(new CarteChance("Avancez jusqu'au boulevard de la Villette", true, false, 0, 11, 0, 0, 0));
            ListeCarte.Add(new CarteChance("Amende pour excès de vitesse : 150 euros", false, false, 1, 0, -150, 0, 0));
        }

        public override Cartes getCarte(int idx) { return ListeCarte[idx]; }


    }
}

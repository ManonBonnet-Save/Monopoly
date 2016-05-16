using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    class Plateau
    {
        private List<Case> Cases;

        public Plateau (int nbCase)
        {
            Cases = new List<Case>();
            for(int i=0; i<nbCase; ++i)
            {
                Cases.Add(null);
            }
            init();
        }

        private void init()
        {
            Case chance = new CaseTirage("Chance");
            Case caisse = new CaseTirage("Caisse de Communauté");
            Cases[0] = new CaseVide("Départ");
            Cases[1] = new CasePropriété(new Propriete("Boulevard de Belleville", 60, 2, 50, 10, 30, 90, 160, 50, 250, 2));
            Cases[2] = caisse;
            Cases[3] = new CasePropriété(new Propriete("Rue Lecourbe", 60, 4, 50, 20, 60, 180, 320, 50, 450, 2));
            Cases[4] = new CaseTaxe("Impôts sur le revenu", 200);
            Cases[5] = new CasePropriété(new Gare("Gare Montparnasse", 200, 25));
            Cases[6] = new CasePropriété(new Propriete("Rue de Vaugirard", 100, 6, 50, 30, 90, 270, 400, 50, 550, 3));
            Cases[7] = chance;
            Cases[8] = new CasePropriété(new Propriete("Rue de Courcelle", 100, 6, 50, 30, 90, 270, 400, 50, 550, 3));
            Cases[9] = new CasePropriété(new Propriete("Avenue de la République", 120, 8, 50, 40, 100, 300, 450, 50, 600, 3));
            Cases[10] = new CaseVide("Simple visite");
            Cases[11] = new CasePropriété(new Propriete("Boulevard de la Villette", 140, 10, 100, 50, 150, 450, 625, 100, 750, 3));
            Cases[12] = new CasePropriété(new Compagnie("Compagnie de distribution d'électricité", 150, 0));
            Cases[13] = new CasePropriété(new Propriete("Avenue de Neuilly", 140, 10, 100, 50, 150, 450, 625, 100, 750, 3));
            Cases[14] = new CasePropriété(new Propriete("Rue de Paradis", 160, 12, 100, 60, 180, 500, 700, 100, 900, 3));
            Cases[15] = new CasePropriété(new Gare("Gare Lyon", 200, 25));
            Cases[16] = new CasePropriété(new Propriete("Avenue Mozart", 180, 14, 100, 70, 200, 550, 75, 100, 950, 3));
            Cases[17] = caisse;
            Cases[18] = new CasePropriété(new Propriete("Boulevard Saint-Michel", 180, 14, 100, 70, 200, 550, 750, 100, 950, 3));
            Cases[19] = new CasePropriété(new Propriete("Place Pigalle", 200, 16, 100, 80, 220, 60, 80, 100, 1000, 3));
            Cases[20] = new CaseVide("Parking gratuit");
            Cases[21] = new CasePropriété(new Propriete("Avenue Matignon", 220, 18, 150, 90, 250, 700, 875, 150, 1050, 3));
            Cases[22] = chance;
            Cases[23] = new CasePropriété(new Propriete("Boulevard malesherbes", 220, 18, 150, 90, 250, 700, 875, 150, 1050, 3));
            Cases[24] = new CasePropriété(new Propriete("Avenue Henri-Martin", 240, 20, 150, 100, 300, 750, 925, 150, 1100, 3));
            Cases[25] = new CasePropriété(new Gare("Gare du Nord", 200, 25));
            Cases[26] = new CasePropriété(new Propriete("Faubourg Saint-Honoré", 260, 22, 150, 110, 330, 800, 975, 150, 1150, 3));
            Cases[27] = new CasePropriété(new Propriete("Place de la Bourse", 260, 22, 150, 110, 330, 800, 975, 150, 1150, 3));
            Cases[28] = new CasePropriété(new Compagnie("Compagnie de distribution des eaux", 150, 0));
            Cases[29] = new CasePropriété(new Propriete("Rue la Fayette", 280, 24, 150, 120, 360, 850, 1025, 150, 1200, 3));
            Cases[30] = new CasePolice("Allez en prison");
            Cases[31] = new CasePropriété(new Propriete("Avenue de Breteuil", 300, 26, 200, 130, 390, 900, 1100, 200, 1275, 3));
            Cases[32] = new CasePropriété(new Propriete("Avenue Foch", 300, 26, 200, 130, 390, 900, 1100, 200, 1275, 3));
            Cases[33] = caisse;
            Cases[34] = new CasePropriété(new Propriete("Boulevard des Capucines", 320, 28, 200, 150, 450, 1000, 1200, 200, 1400, 3));
            Cases[35] = new CasePropriété(new Gare("Gare Saint-Lazare", 200, 25));
            Cases[36] = chance;
            Cases[37] = new CasePropriété(new Propriete("Avenue des champs-Elysées", 350, 35, 200, 175, 500, 1100, 1300, 200, 1500, 2));
            Cases[38] = new CaseTaxe("Taxe de luxe", 100);
            Cases[39] = new CasePropriété(new Propriete("Rue de la Paix", 400, 50, 200, 200, 600, 1400, 1700, 200, 2000, 2));
        }

        public int NbCases() { return Cases.Count; }

        public Case getCase(int idx) { return Cases[idx]; }
    }
}


////Création de toutes les cartes propriétés
//Propriete Boulevard_de_Belleville = new Propriete("Boulevard de Belleville", 60, 2, 50, 10, 30, 90, 160, 50, 250);
//Propriete Rue_Lecourbe = new Propriete("Rue Lecourbe", 60, 4, 50, 20, 60, 180, 320, 50, 450);
//Propriete Rue_de_Vaugirard = new Propriete("Rue de Vaugirard", 100, 6, 50, 30, 90, 270, 400, 50, 550);
//Propriete Rue_de_Courcelle = new Propriete("Rue de Courcelle", 100, 6, 50, 30, 90, 270, 400, 50, 550);
//Propriete Avenue_de_la_Republique = new Propriete("Avenue de la République", 120, 8, 50, 40, 100, 300, 450, 50, 600);
//Propriete Boulevard_de_la_Villette = new Propriete("Boulevard de la Villette", 140, 10, 100, 50, 150, 450, 625, 100, 750);
//Propriete Avenue_de_Neuilly = new Propriete("Avenue de Neuilly", 140, 10, 100, 50, 150, 450, 625, 100, 750);
//Propriete Rue_de_Paradis = new Propriete("Rue de Paradis", 160, 12, 100, 60, 180, 500, 700, 100, 900);
//Propriete Avenue_Mozart = new Propriete("Avenue Mozart", 180, 14, 100, 70, 200, 550, 75, 100, 950);
//Propriete Boulevard_Saint_Michel = new Propriete("Boulevard Saint-Michel", 180, 14, 100, 70, 200, 550, 750, 100, 950);
//Propriete Place_Pigalle = new Propriete("Place Pigalle", 200, 16, 100, 80, 220, 60, 80, 100, 1000);
//Propriete Avenue_Matignon = new Propriete("Avenue Matignon", 220, 18, 150, 90, 250, 700, 875, 150, 1050);
//Propriete Boulevard_Malesherbes = new Propriete("Boulevard malesherbes", 220, 18, 150, 90, 250, 700, 875, 150, 1050);
//Propriete Avenue_Henri_Martin = new Propriete("Avenue Henri-Martin", 240, 20, 150, 100, 300, 750, 925, 150, 1100);
//Propriete Faubourg_Saint_Honore = new Propriete("Faubourg Saint-Honoré", 260, 22, 150, 110, 330, 800, 975, 150, 1150);
//Propriete Place_de_la_Bourse = new Propriete("Place de la Bourse", 260, 22, 150, 110, 330, 800, 975, 150, 1150);
//Propriete Rue_la_Fayette = new Propriete("Rue la Fayette", 280, 24, 150, 120, 360, 850, 1025, 150, 1200);
//Propriete Avenue_de_Breteuil = new Propriete("Avenue de Breteuil", 300, 26, 200, 130, 390, 900, 1100, 200, 1275);
//Propriete Avenue_Foch = new Propriete("Avenue Foch", 300, 26, 200, 130, 390, 900, 1100, 200, 1275);
//Propriete Boulevard_de_Capucines = new Propriete("Boulevard des Capucines", 320, 28, 200, 150, 450, 1000, 1200, 200, 1400);
//Propriete Avenue_des_champs_Elysees = new Propriete("Avenue des champs-Elysées", 350, 35, 200, 175, 500, 1100, 1300, 200, 1500);
//Propriete Rue_de_la_Paix = new Propriete("Rue de la Paix", 400, 50, 200, 200, 600, 1400, 1700, 200, 2000);

////Création des toutes les cartes gare
//Gare Montparnasse = new Gare("Gare Montparnasse", 200, 25);
//Gare Lyon = new Gare("Gare Lyon", 200, 25);
//Gare Nord = new Gare("Gare du Nord", 200, 25);
//Gare Saint_Lazare = new Gare("Gare Saint-Lazare", 200, 25);

////Création des toutes les compagnies
//Compagnie Electricite = new Compagnie("Compagnie de distribution d'électricité", 150, 0);
//Compagnie Eaux = new Compagnie("Compagnie de distribution des eaux", 150, 0);
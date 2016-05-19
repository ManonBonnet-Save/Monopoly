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
            //Création de la pioche Chance
            PiocheChance PiocheCh = new PiocheChance("PiocheCarteChance", 14);
            PiocheCommunaute PiocheCco = new PiocheCommunaute("PiocheCarteCommunaute", 12);


            //Creation des groupe de maison
            Groupe violet     = new Groupe(2);
            Groupe bleu_clair = new Groupe(3);
            Groupe rose       = new Groupe(3);
            Groupe orange     = new Groupe(3);
            Groupe rouge      = new Groupe(3);
            Groupe jaune      = new Groupe(3);
            Groupe vert       = new Groupe(3);
            Groupe bleu_fonce = new Groupe(2);

            //Création des cases
            Case chance = new CaseTirage("Chance", PiocheCh);
            Case caisse = new CaseTirage("Caisse de Communauté", PiocheCco);
            Cases[0] = new CaseVide("Départ");
            Cases[1] = new CasePropriété(new Propriete("Boulevard de Belleville", 60, violet, 2, 50, 10, 30, 90, 160, 50, 250));
            Cases[2] = caisse;
            Cases[3] = new CasePropriété(new Propriete("Rue Lecourbe", 60, violet, 4, 50, 20, 60, 180, 320, 50, 450));
            Cases[4] = new CaseTaxe("Impôts sur le revenu", 200);
            Cases[5] = new CasePropriété(new Gare("Gare Montparnasse", 200));
            Cases[6] = new CasePropriété(new Propriete("Rue de Vaugirard", 100, bleu_clair, 6, 50, 30, 90, 270, 400, 50, 550));
            Cases[7] = chance;
            Cases[8] = new CasePropriété(new Propriete("Rue de Courcelle", 100, bleu_clair, 6, 50, 30, 90, 270, 400, 50, 550));
            Cases[9] = new CasePropriété(new Propriete("Avenue de la République", 120, bleu_clair, 8, 50, 40, 100, 300, 450, 50, 600));
            Cases[10] = new CaseVide("Simple visite");
            Cases[11] = new CasePropriété(new Propriete("Boulevard de la Villette", 140, rose, 10, 100, 50, 150, 450, 625, 100, 750));
            Cases[12] = new CasePropriété(new Compagnie("Compagnie de distribution d'électricité", 150));
            Cases[13] = new CasePropriété(new Propriete("Avenue de Neuilly", 140, rose, 10, 100, 50, 150, 450, 625, 100, 750));
            Cases[14] = new CasePropriété(new Propriete("Rue de Paradis", 160, rose, 12, 100, 60, 180, 500, 700, 100, 900));
            Cases[15] = new CasePropriété(new Gare("Gare Lyon", 200));
            Cases[16] = new CasePropriété(new Propriete("Avenue Mozart", 180, orange, 14, 100, 70, 200, 550, 75, 100, 950));
            Cases[17] = caisse;
            Cases[18] = new CasePropriété(new Propriete("Boulevard Saint-Michel", 180, orange, 14, 100, 70, 200, 550, 750, 100, 950));
            Cases[19] = new CasePropriété(new Propriete("Place Pigalle", 200, orange, 16, 100, 80, 220, 60, 80, 100, 1000));
            Cases[20] = new CaseVide("Parking gratuit");
            Cases[21] = new CasePropriété(new Propriete("Avenue Matignon", 220, rouge, 18, 150, 90, 250, 700, 875, 150, 1050));
            Cases[22] = chance;
            Cases[23] = new CasePropriété(new Propriete("Boulevard malesherbes", 220, rouge, 18, 150, 90, 250, 700, 875, 150, 1050));
            Cases[24] = new CasePropriété(new Propriete("Avenue Henri-Martin", 240, rouge, 20, 150, 100, 300, 750, 925, 150, 1100));
            Cases[25] = new CasePropriété(new Gare("Gare du Nord", 200));
            Cases[26] = new CasePropriété(new Propriete("Faubourg Saint-Honoré", 260, jaune, 22, 150, 110, 330, 800, 975, 150, 1150));
            Cases[27] = new CasePropriété(new Propriete("Place de la Bourse", 260, jaune, 22, 150, 110, 330, 800, 975, 150, 1150));
            Cases[28] = new CasePropriété(new Compagnie("Compagnie de distribution des eaux", 150));
            Cases[29] = new CasePropriété(new Propriete("Rue la Fayette", 280, jaune, 24, 150, 120, 360, 850, 1025, 150, 1200));
            Cases[30] = new CasePolice("Allez en prison");
            Cases[31] = new CasePropriété(new Propriete("Avenue de Breteuil", 300, vert, 26, 200, 130, 390, 900, 1100, 200, 1275));
            Cases[32] = new CasePropriété(new Propriete("Avenue Foch", 300, vert, 26, 200, 130, 390, 900, 1100, 200, 1275));
            Cases[33] = caisse;
            Cases[34] = new CasePropriété(new Propriete("Boulevard des Capucines", 320, vert, 28, 200, 150, 450, 1000, 1200, 200, 1400));
            Cases[35] = new CasePropriété(new Gare("Gare Saint-Lazare", 200));
            Cases[36] = chance;
            Cases[37] = new CasePropriété(new Propriete("Avenue des champs-Elysées", 350, bleu_fonce, 35, 200, 175, 500, 1100, 1300, 200, 1500));
            Cases[38] = new CaseTaxe("Taxe de luxe", 100);
            Cases[39] = new CasePropriété(new Propriete("Rue de la Paix", 400, bleu_fonce, 50, 200, 200, 600, 1400, 1700, 200, 2000));
        }

        public int NbCases() { return Cases.Count; }

        public Case getCase(int idx) { return Cases[idx]; }
    }
}
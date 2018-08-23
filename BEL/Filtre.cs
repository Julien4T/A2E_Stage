using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BEL
{
    
    

    public class Signe
    {
        public string caractere { get; set; }
        public int valeur { get; set; }


        public Signe(string c, int v)
        {
            this.caractere = c;
            this.valeur = v;
        }
        public override string ToString()
        {
            return this.caractere;
        }
    }

    public class CritereRecherche
    {
        public CritereGenerique crit { get; set; }
        public Signe signe { get; set; }
        public float valeur { get; set; }

        public static int valeurParDefisNull = 9999;

        public CritereRecherche()
        {
            CritereGenerique cg = new CritereGenerique();
            Signe s = new Signe("", CritereRecherche.valeurParDefisNull);
            cg.idCritere = CritereRecherche.valeurParDefisNull;
            this.valeur = CritereRecherche.valeurParDefisNull;
        }

        public CritereRecherche(CritereGenerique c, Signe s, float v)
        {
            this.crit = c;
            this.signe = s;
            this.valeur = v;
        }
        public override string ToString()
        {
            string chaineSortie = "";

            chaineSortie += (this.valeur != CritereRecherche.valeurParDefisNull) ? this.crit.designation + " " + this.signe.caractere + " " + this.valeur + " " + this.crit.unite : "";

            return chaineSortie;
        }
    }

    public class Filtre
    {
        public FonctionGenerique fonction { get; set; }
        public int validation { get; set; }
        public float tensionInMin { get; set; }
        public float tensionInMax { get; set; }
        public float intensiteInMin { get; set; }
        public float intensiteInMax { get; set; }
        public float tensionOutMin { get; set; }
        public float tensionOutMax { get; set; }
        public float intensiteOutMin { get; set; }
        public float intensiteOutMax { get; set; }
        public CritereRecherche[] crit { get; set; }
        private int tailleTabbCrit = 6;



        public Filtre()
        {
            this.crit = new CritereRecherche[this.tailleTabbCrit];
            for (int i = 0; i < this.crit.Length; i++)
            {
                this.crit[i] = new CritereRecherche();
            }
        }

        public void setCritere(List<CritereRecherche> listCrit)
        {
            for (int i = 0; i < this.crit.Length; i++)
            {

                if (i < listCrit.Count)
                {
                    this.crit[i] = (listCrit[i] != null) ? listCrit[i] : new CritereRecherche();
                }
                else
                {
                    this.crit[i] = new CritereRecherche();

                }
            }
        }


        public override string ToString()
        {
            String chaineSortie = "Vous recherhez la fonction " + this.fonction.designation + "\n";
            switch (this.validation)
            {
                case -1:
                    chaineSortie += "Les fonctions validées et non validées " + "\n";
                    break;
                case 0:
                    chaineSortie += "Uniquement les fonctions non validées " + "\n";
                    break;
                case 1:
                    chaineSortie += "Uniquement les fonctions validées " + "\n";
                    break;
            }
            chaineSortie += (this.tensionInMin != CritereRecherche.valeurParDefisNull) ? "Tension en entrée min ≤ " + this.tensionInMin + "\n" : "";
            chaineSortie += (this.tensionInMax != CritereRecherche.valeurParDefisNull) ? "Tension en entrée max ≥ " + this.tensionInMax + "\n" : "";
            chaineSortie += (this.intensiteInMin != CritereRecherche.valeurParDefisNull) ? "Intensité en entrée min ≤ " + this.intensiteInMin + "\n" : "";
            chaineSortie += (this.intensiteInMax != CritereRecherche.valeurParDefisNull) ? "Intensité en entrée max ≥ " + this.intensiteInMax + "\n" : "";

            chaineSortie += (this.tensionOutMin != CritereRecherche.valeurParDefisNull) ? "Tension en sortie min ≤ " + this.tensionOutMin + "\n" : "";
            chaineSortie += (this.tensionOutMax != CritereRecherche.valeurParDefisNull) ? "Tension en sortie max ≥ " + this.tensionOutMax + "\n" : "";
            chaineSortie += (this.intensiteOutMin != CritereRecherche.valeurParDefisNull) ? "Intensité en sortie min ≤ " + this.intensiteOutMin + "\n" : "";
            chaineSortie += (this.intensiteOutMax != CritereRecherche.valeurParDefisNull) ? "Intensité en sortie max ≥ " + this.intensiteOutMax + "\n" : "";


            foreach (CritereRecherche cr in this.crit)
            {
                if (cr != null)
                {
                    chaineSortie += (cr.valeur != CritereRecherche.valeurParDefisNull) ? cr.ToString() + "\n" : "";
                }
            }

            return chaineSortie;
        }
    }
}

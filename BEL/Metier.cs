using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;

namespace BEL
{
    public class Personnel
    {
        public int      idPersonnel     { get; set; }
        public string   nom             { get; set; }
        public string   prenom          { get; set; }
        public string   mail            { get; set; }
        public string getCredit()
        {
            return this.prenom.Substring(0, 1) + ". " + this.nom ;
        }

        public override string ToString()
        {
            return this.nom + " " + this.prenom;
        }
    }
    public class Projet
    {
        public string   idProjet        { get; set; }
        public DateTime dateProjet      { get; set; }
        public string   lienSnvProjet   { get; set; }
        public Personnel personnel     { get; set; }
        public string formatDateSql() 
        {
            return this.dateProjet.Year + "-" + this.dateProjet.Month + "-" + this.dateProjet.Day;
        }
        public string getDate() 
        {
             CultureInfo ci = new CultureInfo("fr-Fr");
            string date;
            date = (ci.DateTimeFormat.GetMonthName(this.dateProjet.Month).Length > 7) ?
                ci.DateTimeFormat.GetMonthName(this.dateProjet.Month).Substring(0, 3) : ci.DateTimeFormat.GetMonthName(this.dateProjet.Month);

            return date + " " + this.dateProjet.Year;
        }

        public override string ToString()
        {
            return this.dateProjet.ToShortDateString() + " - " + this.idProjet;
        }

    }
    public class IoPhysiqueGenerique
    {
        public int      idIophysique    { get; set; }
        public string   designation     { get; set; }
        public string   description     { get; set; }
        public override string ToString()
        {
            return this.designation;
        }
    }
    public class CritereGenerique
    { 
        public int      idCritere 	    { get; set; }
        public string   designation     { get; set; }	
        public string   unite 	        { get; set; }
        public Boolean  donneeChiffree  { get; set; }
        public Boolean  modifiable      { get; set; }
        public string   description     { get; set; }
        public override string ToString()
        {
            return this.designation;
        }
    }
    public class FonctionGenerique
    {
        public int      idFonction      { get; set; }
        public string   rubrique        { get; set; } 
        public string   designation     { get; set; }       
        public string   description     { get; set; } 
        public override string ToString()
        {
            return this.designation ;
        }
    }
    public class IoPhysiqueAssociee : IEquatable<IoPhysiqueAssociee>
    {
        public IoPhysiqueGenerique  ioPhysique  { get; set; }       
        public int                  quantite    { get; set; }

        public bool Equals(IoPhysiqueAssociee other)
        {
            if (other == null) return false;
            return (this.ioPhysique.idIophysique.Equals(other.ioPhysique.idIophysique));
        }
        public override string ToString()
        {
            return this.ioPhysique.designation + " : " + this.quantite;
        }
    }

    public class CritereAssociee : IEquatable<CritereAssociee>
    {
        public CritereGenerique     critere  { get; set; }      
        public string               valeurNbr   { get; set; }
        public string               valeurTexte { get; set; }

       
        public bool Equals(CritereAssociee other)
        {
            if (other == null) return false;
            return (this.critere.idCritere.Equals(other.critere.idCritere));
        }
        public override string ToString()
        {
            return this.critere.designation + " " + this.valeurTexte + " : " + this.valeurNbr + " " + this.critere.unite;
        }
    }
    
    public class FonctionElectronique 
    {
        public Projet                   projet          { get; set; }
        public FonctionGenerique        fonction        { get; set; }
        public string                   description     { get; set; }
        public string                   schema          { get; set; }
        public float                    tensionInputMin     { get; set; }
        public float                    tensionInputMax     { get; set; }
        public float                    intensiteInputMin   { get; set; }
        public float                    intensiteInputMax   { get; set; }
        public float                    tensionOutputMin    { get; set; }
        public float                    tensionOutputMax    { get; set; }
        public float                    intensiteOutputMin  { get; set; }
        public float                    intensiteOutputMax  { get; set; }
        public float                    cout            { get; set; }
        public Boolean                  validation      { get; set; }
        public string                   lienSVNTest     { get; set; }
        public List<IoPhysiqueAssociee> listIO          { get; set; }
        public List<CritereAssociee>    listCritere     { get; set; }
        public Boolean                  enAttente       { get; set; }
        public float                    taux            { get; set; }

        public FonctionElectronique() {
            this.listIO = new List<IoPhysiqueAssociee>();
            this.listCritere = new List<CritereAssociee>();
        }
      
        public void ajouterCritere(CritereAssociee crit) 
        {
            if (!this.listCritere.Contains(crit)) 
            {
                this.listCritere.Add(crit);
            }        
        }
        public void modifierCritere(CritereAssociee crit) 
        {
            foreach (CritereAssociee c in this.listCritere)
            {
                if (c.critere.idCritere == crit.critere.idCritere)
                    c.valeurNbr = crit.valeurNbr;
                    c.valeurTexte = crit.valeurTexte;               
            }
        
        }
        public void supprimerCritere(CritereAssociee crit)
        {
            if (this.listCritere.Contains(crit))
            {
                this.listCritere.Remove(crit);
            }   
        }

        public void ajouterIoPhys(IoPhysiqueAssociee ioPhys)
        {
            if (!this.listIO.Contains(ioPhys))
            {
                this.listIO.Add(ioPhys);
            }
        }
        public void modifierIoPhys(IoPhysiqueAssociee ioPhys)
        {
            foreach (IoPhysiqueAssociee io in this.listIO)
            {
                if (io.ioPhysique.idIophysique == ioPhys.ioPhysique.idIophysique)
                    io.quantite = ioPhys.quantite;             
            }
        }
        public void supprimerIoPhys(IoPhysiqueAssociee ioPhys)
        {
            if (this.listIO.Contains(ioPhys))
            {
                this.listIO.Remove(ioPhys);
            }
        }

        public string getPlageTensionInput() 
        {
            return "Tension :  " + this.tensionInputMin + " à " + this.tensionInputMax  + " Volts"; 
        }
        public string getPlageIntensiteInput()
        {
            return "Intensité :  " + this.intensiteInputMin + " à " + this.intensiteInputMax + " Ampères";
        }
        public string getPlageTensionOutput()
        {
            return "Tension :  " + this.tensionOutputMin + " à " + this.tensionOutputMax + " Volts";
        }
        public string getPlageIntensiteOutput()
        {
            return "Intensité :  " + this.intensiteOutputMin + " à " + this.intensiteOutputMax + " Ampères";
        }


        public override string ToString()
        {
            return this.projet.idProjet + " - " + this.fonction.designation;
        }


    }

  


}

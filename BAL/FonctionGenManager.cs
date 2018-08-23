using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using BEL;
using System.Data.Common;
using System.Data;


namespace BAL
{
    /*
    //Création des méthodes CRUD pour la classe FonctionGenerique
    */
    /// <summary>
    /// <c>FonctionGenManager </c> class.
    /// Contient les méthodes logiques applicatives CRUD de la classe FonctionGenerique
    /// </summary>
    /// <remarks>
    /// <para>Cette classe peut ajouter, modifier et supprimer un objet FonctionGenerique</para>
    /// <para>Cette classe permet d'obtenir la liste entière des FonctionGenerique</para>
    /// </remarks> 
  
    public class FonctionGenManager
    {
        private FonctionGenData fgd = new FonctionGenData();

        /// <summary>
        /// Ajouter un <paramref name="fctGen"/> dans la table Fonction_Générique de la base de données.
        /// </summary>
        /// <returns>
        /// Nombre de lignes affectées
        /// </returns>
        /// <param name="fctGen">un objet FonctionGenerique</param>     
        public int ajouterFonctionGen(FonctionGenerique fctGen)
        {
            if (fctGen.designation.Trim() == "")
            {
                return 0;
            }
            else 
            {
                fctGen.rubrique = fctGen.rubrique[0].ToString().ToUpper() + fctGen.rubrique.Substring(1).ToLower();
                fctGen.designation = fctGen.designation[0].ToString().ToUpper() + fctGen.designation.Substring(1).ToLower();
                return fgd.ajouterFonctionGen(this.echappementFctGen(fctGen));
            }
           
        }

        /// <summary>
        /// Obtenir un objet FonctionGenerique par son <paramref name="designation"/>
        /// </summary>
        /// <returns>
        /// Un objet FonctionGenerique
        /// </returns>
        /// <param name="designation">désignation de la fonction</param>
        public FonctionGenerique getFonctGenByDesignation(string designation)
        {
            return fgd.getFonctGenByDesignation(designation.Replace("'", "''").Replace(@"\", "\\"));
        }

        /// <summary>
        /// Obtenir un objet FonctionGenerique par son <paramref name="idFonction"/>
        /// </summary>
        /// <returns>
        /// Un objet FonctionGenerique
        /// </returns>
        /// <param name="idFonction">Identifiant de la fonction</param>
        public FonctionGenerique getFonctionGenById(int idFonction)
        {
             return fgd.getFonctionGenById(idFonction);

        }

        /// <summary>
        /// Obtenir une liste d'objet FonctionGenerique
        /// </summary>
        /// <returns>
        /// Liste d'objet FonctionGenerique
        /// </returns>    
        public List<FonctionGenerique> getListFonctionGen()
        {
             return fgd.getListFonctionGen(); 
        } 

        /// <summary>
        /// Modifier un <paramref name="fctGen"/> dans la table Fonction_Générique de la base de données.
        /// </summary>
        /// <returns>
        /// Nombre de lignes affectées
        /// </returns>
        /// <param name="fctGen">un objet FonctionGenerique</param>   
        public int modifierFctGen(FonctionGenerique fctGen)
        {
            if (fctGen.designation.Trim() == "")
            {
                return 0;
            }
            else
            {
                fctGen.rubrique = fctGen.rubrique[0].ToString().ToUpper() + fctGen.rubrique.Substring(1).ToLower();
                fctGen.designation = fctGen.designation[0].ToString().ToUpper() + fctGen.designation.Substring(1).ToLower();
                return fgd.modifierFctGen(this.echappementFctGen(fctGen));
            }
           
        }

        /// <summary>
        /// Supprimer un <paramref name="fctGen"/> dans la table Fonction_Générique de la base de données.
        /// </summary>
        /// <returns>
        /// Nombre de lignes affectées
        /// </returns>
        /// <param name="fctGen">un objet FonctionGenerique</param>   
        public int supprimerFctGen(FonctionGenerique fctGen)
        {         
            return fgd.supprimerFctGen(this.echappementFctGen(fctGen));
        }


        //controler les caractères d'échappement pour l'insertion SQL  
        private FonctionGenerique echappementFctGen(FonctionGenerique fctGen)
        {
            FonctionGenerique f = new FonctionGenerique();
            f.idFonction = fctGen.idFonction;
            
            f.designation = fctGen.designation.Replace("'", "''").Replace(@"\", "\\");
            f.rubrique =    fctGen.rubrique.Replace("'", "''").Replace(@"\", "\\");
            f.description = fctGen.description.Replace("'", "''").Replace(@"\", "\\");

            return f;
        }

    }
}

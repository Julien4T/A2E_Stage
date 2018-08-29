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
   //Création des méthodes CRUD pour la classe CritereGenerique
   */
    /// <summary>
    /// <c>CritereGenManager</c> class.
    /// Contient les méthodes logiques applicatives CRUD de la classe CritereGenerique
    /// </summary>
    /// <remarks>
    /// <para>Cette classe peut ajouter, modifier et supprimer un objet CritereGenerique</para>
    /// <para>Cette classe permet d'obtenir la liste entière des FonctionGenerique</para>
    /// </remarks>    
    public class CritereGenManager
    {
        private CritereGenData cgd = new CritereGenData();

        /// <summary>
        /// Ajouter un <paramref name="critGen"/> dans la table Critère_Générique de la base de données.
        /// </summary>
        /// <returns>
        /// Nombre de lignes affectées
        /// </returns>
        /// <param name="critGen">un objet CritereGenerique</param>   
        public int ajouterCritGen(CritereGenerique critGen)
        {
            if (critGen.designation.Trim() == "" || critGen.unite.Trim() =="")
            {
                return 0;
            }
            else
            {    
                //critGen.designation = critGen.designation[0].ToString().ToUpper() + critGen.designation.Substring(1).ToLower();
                return cgd.ajouterCriGen(this.echappementCritGen(critGen));
            }        
        }

        /// <summary>
        /// Obtenir un objet CritereGenerique par son <paramref name="idCrit"/>
        /// </summary>
        /// <returns>
        /// Un objet FonctionGenerique
        /// </returns>
        /// <param name="idCrit">identifiant du critère générique</param>
        public  CritereGenerique getCritGenById(int idCrit)
        {
            return cgd.getCritGenById(idCrit);
        }

        /// <summary>
        /// Obtenir une liste d'objet CritereGenerique
        /// </summary>
        /// <returns>
        /// Une liste d'objet CritereGenerique
        /// </returns> 
        public List<CritereGenerique> getListCriGen()
        {
            return cgd.getListCriGen();

        }

        /// <summary>
        /// Modifier un <paramref name="critGen"/> dans la table Critère_Générique de la base de données.
        /// </summary>
        /// <returns>
        /// Nombre de lignes affectées
        /// </returns>
        /// <param name="critGen">un objet CritereGenerique</param>   
        public int modifierCritGen(CritereGenerique critGen)
        {
            if (critGen.designation.Trim() == "" || critGen.unite.Trim() == "")
            {
                return 0;
            }
            else
            {
                //critGen.designation = critGen.designation[0].ToString().ToUpper() + critGen.designation.Substring(1).ToLower();
                return cgd.modifierCritGen(this.echappementCritGen(critGen));
            }        
        }

        /// <summary>
        /// Supprimer un <paramref name="critGen"/> dans la table Critère_Générique de la base de données.
        /// </summary>
        /// <returns>
        /// Nombre de lignes affectées
        /// </returns>
        /// <param name="critGen">un objet CritereGenerique</param>   
        public int supprimerCritGen(CritereGenerique critGen)
        {
            return cgd.supprimerCritGen(this.echappementCritGen(critGen));
        }


        //controler les caractères d'échappement pour l'insertion SQL  
        private CritereGenerique echappementCritGen(CritereGenerique critGen)
        {
            CritereGenerique c = new CritereGenerique();
            c.idCritere = critGen.idCritere;
            c.donneeChiffree = critGen.donneeChiffree;
            c.designation = critGen.designation.Replace("'", "''").Replace(@"\", "\\");
            c.unite = critGen.unite.Replace("'", "''").Replace(@"\", "\\");
            c.description = critGen.description.Replace("'", "''").Replace(@"\", "\\");
                      
            return c;
        }
    }


}

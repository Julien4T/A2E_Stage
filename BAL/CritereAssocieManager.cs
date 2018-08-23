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
      //Création des méthodes CRUD pour la classe CritereAssocie
   */
    /// <summary>
    /// <c>CritereAssocieData</c> class.
    /// Contient les méthodes CRUD de la classe CritereAssocie
    /// </summary>
    /// <remarks>
    /// <para>Cette classe peut ajouter, modifier et supprimer un objet CritereAssociee</para>
    /// <para>Cette classe permet d'obtenir la liste entière des CritereAssociee</para>
    /// </remarks> 
    public class CritereAssocieManager
    {
        private CritereAssocieData cad = new CritereAssocieData();

        /// <summary>
        /// Ajouter un <paramref name="critAss"/> dans la table Associer_Critère de la base de données pour une  <paramref name="FonctionElectronique"/>
        /// </summary>
        /// <returns>
        /// Nombre de lignes affectées
        /// </returns>
        /// <param name="critAss">un objet CritereAssociee</param>  
        /// <param name="critAss">un objet FonctionElectronique</param>  
        public int ajouterCritAssocieByFonction(FonctionElectronique fct, CritereAssociee critAss)
        {
            return cad.ajouterCritAssocieByFonction(this.echappementFonction(fct), this.echappementCritAss(critAss));
        }
        


        public List<CritereAssociee> getListCritAssocieeByFonction(FonctionElectronique fct)
        {
            return cad.getListCritAssocieeByFonction(this.echappementFonction(fct));
        }



        /// <summary>
        /// Modifier un <paramref name="critAss"/> dans la table Associer_Critère de la base de données pour <paramref name="FonctionElectronique"/>
        /// </summary>
        /// <returns>
        /// Nombre de lignes affectées
        /// </returns>
        /// <param name="critAss">un objet CritereAssociee</param>  
        /// <param name="critAss">un objet FonctionElectronique</param>  
        public int modifierCritAssocieByFonction(FonctionElectronique fct, CritereAssociee critAss)
        {

            return cad.modifierCritAssocieByFonction(this.echappementFonction(fct), this.echappementCritAss(critAss));
        }



        /// <summary>
        /// Supprimer toutes le critères dans la table Associer_Critère de la base de données pour <paramref name="fct"/>
        /// </summary>
        /// <returns>
        /// Nombre de lignes affectées
        /// </returns>
        /// <param name="fct">un objet FonctionElectronique</param> 
        public int supprimerCritAssocieByFonction(FonctionElectronique fct)
        {
            return cad.supprimerCritAssocieByFonction(this.echappementFonction(fct)); ;
        }

        //controler les caractères d'échappement pour l'insertion SQL  
        private FonctionElectronique echappementFonction(FonctionElectronique fct)
        {
            FonctionElectronique f = new FonctionElectronique();
            f = fct;
            f.projet.idProjet = fct.projet.idProjet.Replace("'", "''").Replace(@"\", "\\");

            return f;
        }

        private CritereAssociee echappementCritAss(CritereAssociee critAss)
        {
            CritereAssociee c = new CritereAssociee();
            c = critAss;
            if (critAss.valeurTexte != null) 
            {
                c.valeurTexte = critAss.valeurTexte.Replace("'", "''").Replace(@"\", "\\");
            }
           
            return c;
        }
    }
}

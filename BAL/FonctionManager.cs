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
    //Création des méthodes CRUD pour la classe Personnel
     */
    /// <summary>
    /// <c>PersonnelData</c> class.
    /// Contient les méthodes CRUD de la classe personnel
    /// </summary>
    /// <remarks>
    /// <para>Cette classe peut ajouter, modifier et supprimer un objet personnel</para>
    /// <para>Cette classe permet d'obtenir la liste entière des personnel</para>
    /// </remarks>    
    public class FonctionManager
    {
        private FonctionData fctd = new FonctionData();

        /// <summary>
        /// Ajouter un <paramref name="fctElec"/> dans la table Fonction de la base de données.
        /// </summary>
        /// <returns>
        /// Nombre de lignes affectées
        /// </returns>
        /// <param name="fctElec">un objet FonctionElectronique</param>     
        public int ajouterFonction(FonctionElectronique fctElec)
        {
            return fctd.ajouterFonction(this.echappementFctElec(fctElec));
        }

        /// <summary>
        /// Obtenir un objet FonctionElectronique par son <paramref name="idFonction"/>
        /// </summary>
        /// <returns>
        /// Un objet FonctionElectronique
        /// </returns>
        /// <param name="idFonction">Identifiant de la fonction</param>
        public FonctionElectronique getFonctionGenById(int idFonction, string idprojet)
        {
            return fctd.getFonctionById(idFonction,idprojet.Replace("'", "''").Replace(@"\", "\\"));
        }

        /// <summary>
        /// Obtenir une liste d'objet FonctionElectronique
        /// </summary>
        /// <returns>
        /// Une liste d'objet FonctionElectronique
        /// </returns> 
        public List<FonctionElectronique> getListFonction() 
        {
            return fctd.getListFonction(); 
        }


        /// <summary>
        /// Obtenir une liste d'objet FonctionElectronique par son <paramref name="f"/>
        /// </summary>
        /// <returns>
        /// Une liste d'objet FonctionElectronique
        /// </returns> 
        /// <param name="f">Filtre</param>
        public List<FonctionElectronique> getListFonction(Filtre f)
        {
            return fctd.getListFonction(f);
        }

         /// <summary>
        /// Obtenir une liste d'objet FonctionElectronique avec une close where 
        /// </summary>
        /// <returns>
        /// Une liste d'objet FonctionElectronique
        /// </returns> 
        public List<FonctionElectronique> getListFonction(string closeWhere)
        {
            return fctd.getListFonction(closeWhere);
        }


        /// <summary>
        /// Modifier un <paramref name="fctElec"/> dans la table Fonction_Générique de la base de données.
        /// </summary>
        /// <returns>
        /// Nombre de lignes affectées
        /// </returns>
        /// <param name="fctElec">un objet FonctionGenerique</param>   
        public int modifierFonction(FonctionElectronique fctElec)
        {

            return fctd.modifierFonction(this.echappementFctElec(fctElec));
        }

        /// <summary>
        /// Supprimer un <paramref name="fctGen"/> dans la table Fonction_Générique de la base de données.
        /// </summary>
        /// <returns>
        /// Nombre de lignes affectées
        /// </returns>
        /// <param name="fctGen">un objet FonctionGenerique</param>   
        public int supprimerFonction(FonctionElectronique fctElec)
        {
            return fctd.supprimerFonction(this.echappementFctElec(fctElec));
        }



        //controler les caractères d'échappement pour l'insertion SQL  
        private FonctionElectronique echappementFctElec(FonctionElectronique fctElec)
        {
            FonctionElectronique f = new FonctionElectronique();
            f = fctElec;
            f.projet.idProjet =fctElec.projet.idProjet.Replace("'", "''").Replace(@"\", "");
            f.description = fctElec.description.Replace("'", "''").Replace(@"\", "");
            f.lienSVNTest = fctElec.lienSVNTest.Replace("'", "''").Replace(@"\", "");        
            return f;
        }




    }
}

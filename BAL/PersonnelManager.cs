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
    /// <c>PersonnelManager</c> class.
    /// Contient les méthodes CRUD de la classe personnel
    /// </summary>
    /// <remarks>
    /// <para>Cette classe peut ajouter, modifier et supprimer un objet personnel</para>
    /// <para>Cette classe permet d'obtenir la liste entière des personnel</para>
    /// </remarks>    
    public class PersonnelManager
    {

        private PersonnelData persData = new PersonnelData();

        /// <summary>
        /// Ajouter un <paramref name="pers"/> dans la table Personnel de la base de données.
        /// </summary>
        /// <returns>
        /// Nombre de lignes affectées
        /// </returns>
        /// <param name="pers">un objet personnel</param>     
        public int ajouterPersonne(Personnel pers) 
        {
            
            return persData.ajouterPersonne(this.echappementPersonnel(pers));       
        }

        
        /// <summary>
        /// Obtenir un personnel par son <paramref name="nom"/>
        /// </summary>
        /// <returns>
        /// Un objet personnel
        /// </returns>
        /// <param name="nom">nom de la personne</param>
        public Personnel getPersonneById(int id)
        {
            return persData.getPersonneById(id);       
        
        }

        /// <summary>
        /// Obtenir une liste de tout le personnel
        /// </summary>
        /// <returns>
        /// Une liste de personnel
        /// </returns>
        public List<Personnel> getListPersonnel() 
        {
            return persData.getListPersonnel(); 
        }

        /// <summary>
        /// Modifier un <paramref name="pers"/> dans la table Personnel de la base de données.
        /// </summary>
        /// <returns>
        /// Nombre de lignes affectées
        /// </returns>
        /// <param name="pers">un objet personnel</param>   
        public int modifierPersonne(Personnel pers)
        {
            return persData.modifierPersonne(this.echappementPersonnel(pers));
        }

        /// <summary>
        /// Supprimer un <paramref name="pers"/> dans la table Personnel de la base de données.
        /// </summary>
        /// <returns>
        /// Nombre de lignes affectées
        /// </returns>
        /// <param name="pers">un objet personnel</param>   
        public int supprimerPersonne(Personnel pers)
        {
            return persData.supprimerPersonne(this.echappementPersonnel(pers));
        }


        //controler les caractères d'échappement pour l'insertion SQL  
        private Personnel echappementPersonnel(Personnel pers)
        {
            Personnel p = new Personnel();
            p.idPersonnel = pers.idPersonnel;
            p.nom = pers.nom.Replace("'", "''").Replace(@"\", "\\");
            p.prenom = pers.prenom.Replace("'", "''").Replace(@"\", "\\");
            p.mail = pers.mail.Replace("'", "''").Replace(@"\", "\\");
            return p;
        }



    }
}

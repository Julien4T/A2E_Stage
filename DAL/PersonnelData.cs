using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BEL;
using System.Data.Common;
using System.Data;


namespace DAL
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
    public class PersonnelData
    {
        private DbConnexion db = new DbConnexion();

        /// <summary>
        /// Ajouter un <paramref name="pers"/> dans la table Personnel de la base de données.
        /// </summary>
        /// <returns>
        /// Nombre de lignes affectées
        /// </returns>
        /// <param name="pers">un objet personnel</param>     
        public int ajouterPersonne(Personnel pers)
        {
            DbCommand cmd = db.CreerCommande();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "INSERT INTO Personnel(nom  , prénom , adresse_mail ) " +
                                "VALUES ('" + pers.nom  + "', '"
                                + pers.prenom  + "', '"
                                + pers.mail  + "')";
            return db.ExecuterRequete(cmd);
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
            Personnel pers = new Personnel();
            DbCommand cmd = db.CreerCommande();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select * from Personnel where id_personnel=" + id + " ";
            DataTable table = db.CreerDatatable(cmd);
            if (table.Rows.Count >= 1)
            {
                pers.idPersonnel = (int)table.Rows[0][0];
                pers.nom = (string)table.Rows[0][1];
                pers.prenom = (string)table.Rows[0][2];
                pers.mail = (string)table.Rows[0][3];
            }
            return pers;

        }

        /// <summary>
        /// Obtenir une liste de tout le personnel
        /// </summary>
        /// <returns>
        /// Une liste de personnel
        /// </returns>
        public List<Personnel> getListPersonnel()
        {
            List<Personnel> listPers = new List<Personnel>();

            DbCommand cmd = db.CreerCommande();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select * from Personnel";
            DataTable table = db.CreerDatatable(cmd);

            foreach (DataRow row in table.Rows)
            {
                Personnel pers = new Personnel();
                pers.idPersonnel = (int)row[0];
                pers.nom = (string)row[1];
                pers.prenom = (string)row[2];
                pers.mail = (string)row[3];
                listPers.Add(pers);
            }
            return listPers;
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
            DbCommand cmd = db.CreerCommande();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "UPDATE Personnel " +
                                "SET nom = '" + pers.nom  + "',prénom = '"
                                + pers.prenom  + "', adresse_mail='"
                                + pers.mail  + "' " +
                                "WHERE id_personnel =" + pers.idPersonnel;
            return db.ExecuterRequete(cmd);
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
            DbCommand cmd = db.CreerCommande();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "DELETE FROM Personnel " +
                              "WHERE id_personnel =" + pers.idPersonnel;
            return db.ExecuterRequete(cmd);
        }


    }
}

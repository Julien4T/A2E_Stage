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
    //Création des méthodes CRUD pour la classe Projet
    */
    /// <summary>
    /// <c>ProjetData</c> class.
    /// Contient les méthodes CRUD de la classe Projet
    /// </summary>
    /// <remarks>
    /// <para>Cette classe peut ajouter, modifier et supprimer un objet Projet</para>
    /// <para>Cette classe permet d'obtenir la liste entière des Projet</para>
    /// </remarks>    
    public class ProjetData
    {
        private DbConnexion db = new DbConnexion();
        private PersonnelData persD = new PersonnelData();

        /// <summary>
        /// Ajouter un <paramref name="projet"/> dans la table Personnel de la base de données.
        /// </summary>
        /// <returns>
        /// Nombre de lignes affectées
        /// </returns>
        /// <param name="projet">un objet Projet</param>     
        public int ajouterProjet(Projet projet)
        {
            DbCommand cmd = db.CreerCommande();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "INSERT INTO Projet(id_projet  , date_projet , lien_SVN_projet, id_personnel) " +
                                "VALUES ('" + projet.idProjet  + "',  '" + projet.formatDateSql() + "', '" + projet.lienSnvProjet  + "', '" + projet.personnel.idPersonnel + "')";
          
            return db.ExecuterRequete(cmd);
        }

        /// <summary>
        /// Obtenir un Projet par son <paramref name="idProjet"/>
        /// </summary>
        /// <returns>
        /// Un objet Projet
        /// </returns>
        /// <param name="idProjet">nom du projet</param>
        public Projet getProjetById(string idProjet)
        {
            Projet projet = new Projet();
            DbCommand cmd = db.CreerCommande();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select * from Projet where id_projet='" + idProjet  + "'";
            DataTable table = db.CreerDatatable(cmd);
            if (table.Rows.Count >= 1)
            {
                projet.idProjet = (string)table.Rows[0][0];
                projet.dateProjet = (DateTime)table.Rows[0][1];
                projet.lienSnvProjet = (string)table.Rows[0][2];
                projet.personnel = persD.getPersonneById((int)table.Rows[0][3]);
            }
            return projet;
        }

        // <summary>
        /// Obtenir une liste de tout les projets
        /// </summary>
        /// <returns>
        /// Une liste de projet
        /// </returns>
        public List<Projet> getListProjet()
        {
            List<Projet> listProjet = new List<Projet>();

            DbCommand cmd = db.CreerCommande();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select * from Projet";
            DataTable table = db.CreerDatatable(cmd);

            foreach (DataRow row in table.Rows)
            {
                Projet projet = new Projet();
                projet.idProjet = (string)row[0];
                projet.dateProjet = (DateTime)row[1];
                projet.lienSnvProjet = (string)row[2];
                projet.personnel = persD.getPersonneById((int)row[3]);
                listProjet.Add(projet);
            }
            return listProjet;
        }

        /// <summary>
        /// Modifier un <paramref name="projet"/> dans la table Projet de la base de données.
        /// </summary>
        /// <returns>
        /// Nombre de lignes affectées
        /// </returns>
        /// <param name="projet">un objet projet</param>   
        public int modifierProjetByNom(Projet projet, string nom)
        {
            DbCommand cmd = db.CreerCommande();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "UPDATE Projet " +
                                "SET id_projet = '" + projet.idProjet  + "',date_projet = '" 
                                + projet.formatDateSql() + "', lien_SVN_projet='"
                                + projet.lienSnvProjet  + "' , id_personnel =" 
                                + projet.personnel.idPersonnel + " " +
                                "WHERE id_projet ='" + nom  + "'";
            return db.ExecuterRequete(cmd);
        }

        /// <summary>
        /// Supprimer un <paramref name="projet"/> dans la table Projet de la base de données.
        /// </summary>
        /// <returns>
        /// Nombre de lignes affectées
        /// </returns>
        /// <param name="pers">un objet Projet</param>   
        public int supprimerProjet(Projet projet)
        {
            DbCommand cmd = db.CreerCommande();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "DELETE FROM Projet " +
                              "WHERE id_projet ='" + projet.idProjet  + "'";
            return db.ExecuterRequete(cmd);
        }


       
    }
}

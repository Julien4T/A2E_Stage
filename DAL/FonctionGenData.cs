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
    //Création des méthodes CRUD pour la classe FonctionGenerique
    */
    /// <summary>
    /// <c>FonctionGenData</c> class.
    /// Contient les méthodes CRUD de la classe FonctionGenerique
    /// </summary>
    /// <remarks>
    /// <para>Cette classe peut ajouter, modifier et supprimer un objet FonctionGenerique</para>
    /// <para>Cette classe permet d'obtenir la liste entière des FonctionGenerique</para>
    /// </remarks>    
    public class FonctionGenData
    {
        private DbConnexion db = new DbConnexion();

        /// <summary>
        /// Ajouter un <paramref name="fctGen"/> dans la table Fonction_Générique de la base de données.
        /// </summary>
        /// <returns>
        /// Nombre de lignes affectées
        /// </returns>
        /// <param name="fctGen">un objet FonctionGenerique</param>     
        public int ajouterFonctionGen(FonctionGenerique fctGen)
        {
            DbCommand cmd = db.CreerCommande();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "INSERT INTO Fonction_Générique(id_fonction  , rubrique , désignation, description ) " +
                                "VALUES ('" + fctGen.idFonction + "', '"
                                + fctGen.rubrique  + "', '"
                                + fctGen.designation  + "', '"
                                + fctGen.description  + "')";
            return db.ExecuterRequete(cmd);
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
            FonctionGenerique fctGen = new FonctionGenerique();
            DbCommand cmd = db.CreerCommande();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select * from Fonction_Générique where désignation='" + designation  + "'";
            DataTable table = db.CreerDatatable(cmd);
            if (table.Rows.Count >= 1)
            {
                fctGen.idFonction = (int)table.Rows[0][0];
                fctGen.rubrique = (string)table.Rows[0][1];
                fctGen.designation = (string)table.Rows[0][2];
                fctGen.description = (string)table.Rows[0][3];
            }
            return fctGen;
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
            FonctionGenerique fonction = new FonctionGenerique();
            DbCommand cmd = db.CreerCommande();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select * from Fonction_Générique where id_fonction='" + idFonction + "'";
            DataTable table = db.CreerDatatable(cmd);
            if (table.Rows.Count >= 1)
            {
                fonction.idFonction = (int)table.Rows[0][0];
                fonction.rubrique = (string)table.Rows[0][1].ToString();
                fonction.designation = (string)table.Rows[0][2].ToString();
                fonction.description = (string)table.Rows[0][3].ToString();
            }
            return fonction;

        }
        /// <summary>
        /// Obtenir une liste d'objet FonctionGenerique
        /// </summary>
        /// <returns>
        /// Une liste d'objet FonctionGenerique
        /// </returns> 
        public List<FonctionGenerique> getListFonctionGen()
        {
            List<FonctionGenerique> listFctGen = new List<FonctionGenerique>();

            DbCommand cmd = db.CreerCommande();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select * from Fonction_Générique";
            DataTable table = db.CreerDatatable(cmd);
            if (table != null)
            {
                foreach (DataRow row in table.Rows)
                {
                    FonctionGenerique fctGen = new FonctionGenerique();
                    fctGen.idFonction = (int)row[0];
                    fctGen.rubrique = (string)row[1];
                    fctGen.designation = (string)row[2];
                    fctGen.description = (string)row[3].ToString();
                    listFctGen.Add(fctGen);
                }
            }
            return listFctGen;

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
            DbCommand cmd = db.CreerCommande();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "UPDATE Fonction_Générique " +
                                "SET rubrique = '" + fctGen.rubrique  + "', désignation = '"
                                + fctGen.designation  + "', description='"
                                + fctGen.description  + "' " +
                                "WHERE id_fonction = " + fctGen.idFonction;
            return db.ExecuterRequete(cmd);
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
            DbCommand cmd = db.CreerCommande();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "DELETE FROM Fonction_Générique " +
                              "WHERE id_fonction =" + fctGen.idFonction;
            return db.ExecuterRequete(cmd);
        }

    }
}

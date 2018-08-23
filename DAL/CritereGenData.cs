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
        //Création des méthodes CRUD pour la classe CritereGenerique
    */
    /// <summary>
    /// <c>CritereGenData</c> class.
    /// Contient les méthodes CRUD de la classe CritereGenerique
    /// </summary>
    /// <remarks>
    /// <para>Cette classe peut ajouter, modifier et supprimer un objet CritereGenerique</para>
    /// <para>Cette classe permet d'obtenir la liste entière des CritereGenerique</para>
    /// </remarks>   
    public class CritereGenData
    {
        private DbConnexion db = new DbConnexion();

        /// <summary>
        /// Ajouter un <paramref name="critGen"/> dans la table Critère_Générique de la base de données.
        /// </summary>
        /// <returns>
        /// Nombre de lignes affectées
        /// </returns>
        /// <param name="critGen">un objet CritereGenerique</param>     
        public int ajouterCriGen(CritereGenerique critGen)
        {           
            DbCommand cmd = db.CreerCommande();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "INSERT INTO Critère_Générique(id_critère  , désignation , unité, donnée_chiffrée, description) " +
                                "VALUES ('" + critGen.idCritere + "', '" + critGen.designation 
                                + "', '" + critGen.unite  + "', '" + critGen.donneeChiffree + "', '" + critGen.description + "')";
            return db.ExecuterRequete(cmd);
        }


        /// <summary>
        /// Obtenir un objet CritereGenerique par son <paramref name="idCrit"/>
        /// </summary>
        /// <returns>
        /// Un objet FonctionGenerique
        /// </returns>
        /// <param name="idCrit">identifiant du critère générique</param>
        public CritereGenerique getCritGenById(int idCrit)
        {
            CritereGenerique critGen = new CritereGenerique();
            DbCommand cmd = db.CreerCommande();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select * from Critère_Générique where id_critère='" + idCrit + "'";
            DataTable table = db.CreerDatatable(cmd);
            if (table.Rows.Count >= 1)
            {
                critGen.idCritere = (int)table.Rows[0][0];
                critGen.designation = (string)table.Rows[0][1];
                critGen.unite = (string)table.Rows[0][2];
                critGen.donneeChiffree = (Boolean)table.Rows[0][3];
                critGen.description = (string)table.Rows[0][4].ToString();
            }
            return critGen;
        }

        /// <summary>
        /// Obtenir une liste d'objet CritereGenerique
        /// </summary>
        /// <returns>
        /// Une liste d'objet CritereGenerique
        /// </returns> 
        public List<CritereGenerique> getListCriGen()
        {
            List<CritereGenerique> listCriGen = new List<CritereGenerique>();

            DbCommand cmd = db.CreerCommande();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select * from Critère_Générique";
            DataTable table = db.CreerDatatable(cmd);

            foreach (DataRow row in table.Rows)
            {
                CritereGenerique critGen = new CritereGenerique();
                critGen.idCritere = (int)row[0];
                critGen.designation = (string)row[1];
                critGen.unite = (string)row[2];
                critGen.donneeChiffree = (Boolean)row[3];
                critGen.description = (string)row[4].ToString();
                listCriGen.Add(critGen);
            }
            return listCriGen;

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
           DbCommand cmd = db.CreerCommande();
            cmd.CommandType = CommandType.Text;                
            cmd.CommandText = "UPDATE Critère_Générique " +
                                "SET désignation = '" + critGen.designation  + "', unité = '" + critGen.unite 
                                + "', donnée_chiffrée =" + critGen.donneeChiffree + ", description='" + critGen.description  + "' " +
                                "WHERE id_critère = " + critGen.idCritere;
            return db.ExecuterRequete(cmd);
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
            DbCommand cmd = db.CreerCommande();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "DELETE FROM Critère_Générique " +
                              "WHERE id_critère =" + critGen.idCritere;
            return db.ExecuterRequete(cmd);
        }

    }
}

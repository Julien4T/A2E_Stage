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
    //Création des méthodes CRUD pour la classe IophysiqueGenerique
    */
    /// <summary>
    /// <c>IoPhysiqueGenData</c> class.
    /// Contient les méthodes CRUD de la classe IophysiqueGenerique
    /// </summary>
    /// <remarks>
    /// <para>Cette classe peut ajouter, modifier et supprimer un objet IophysiqueGenerique</para>
    /// <para>Cette classe permet d'obtenir la liste entière des IophysiqueGenerique</para>
    /// </remarks>    
    public class IoPhysiqueGenData
    {
        private DbConnexion db = new DbConnexion();

        /// <summary>
        /// Ajouter un <paramref name="IoPhysiqueGen"/> dans la table IO_Physique_Générique de la base de données.
        /// </summary>
        /// <returns>
        /// Nombre de lignes affectées
        /// </returns>
        /// <param name="IoPhysiqueGen">un objet IophysiqueGenerique</param>     
        public int ajouterIoPhysiqueGen(IoPhysiqueGenerique ioPhysiqueGen)
        {           
            DbCommand cmd = db.CreerCommande();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "INSERT INTO IO_Physique_Générique(id_io_physique  , désignation , description ) " +
                                "VALUES ('" + ioPhysiqueGen.idIophysique + "', '" + ioPhysiqueGen.designation 
                                + "', '" + ioPhysiqueGen.description  + "')";
            return db.ExecuterRequete(cmd);
        }

        /// <summary>
        /// Obtenir un objet IophysiqueGenerique par son <paramref name="idIo"/>
        /// </summary>
        /// <returns>
        /// Un objet IophysiqueGenerique
        /// </returns>
        /// <param name="idIo">identifiant de l'Io physique générique</param> 
        public IoPhysiqueGenerique getIoGenById(int idIo)
        {
            IoPhysiqueGenerique ioPhy = new IoPhysiqueGenerique();
            DbCommand cmd = db.CreerCommande();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select * from IO_Physique_Générique where id_io_physique='" + idIo + "'";
            DataTable table = db.CreerDatatable(cmd);
            if (table.Rows.Count >= 1)
            {
                ioPhy.idIophysique = (int)table.Rows[0][0];
                ioPhy.designation = (string)table.Rows[0][1];
                ioPhy.description = (string)table.Rows[0][2];
            }
            return ioPhy;
        }

        /// <summary>
        /// Obtenir une liste d'objet IophysiqueGenerique
        /// </summary>
        /// <returns>
        /// Une liste d'objet IophysiqueGenerique
        /// </returns> 
        public List<IoPhysiqueGenerique> getListIoPhysiqueGen()
        {
            List<IoPhysiqueGenerique> listIoPhGen = new List<IoPhysiqueGenerique>();

            DbCommand cmd = db.CreerCommande();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select * from IO_Physique_Générique";
            DataTable table = db.CreerDatatable(cmd);

            foreach (DataRow row in table.Rows)
            {
                IoPhysiqueGenerique ioPhGen = new IoPhysiqueGenerique();
                ioPhGen.idIophysique = (int)row[0];
                ioPhGen.designation = (string)row[1];
                ioPhGen.description = (string)row[2].ToString();
                listIoPhGen.Add(ioPhGen);
            }
            return listIoPhGen;

        }

        /// <summary>
        /// Modifier un <paramref name="IoPhysiqueGen"/> dans la table IO_Physique_Générique de la base de données.
        /// </summary>
        /// <returns>
        /// Nombre de lignes affectées
        /// </returns>
        /// <param name="IoPhysiqueGen">un objet IophysiqueGenerique</param>   
        public int modifierIoPhysiqueGen(IoPhysiqueGenerique ioPhysiqueGen)
        {
            //id_io_physique  , désignation , description
            DbCommand cmd = db.CreerCommande();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "UPDATE IO_Physique_Générique " +
                              "SET désignation = '" + ioPhysiqueGen.designation 
                              + "', description = '" + ioPhysiqueGen.description  + "' " +
                              "WHERE id_io_physique = " + ioPhysiqueGen.idIophysique;
            return db.ExecuterRequete(cmd);
        }

        /// <summary>
        /// Supprimer un <paramref name="ioPhysiqueGen"/> dans la table IO_Physique_Générique de la base de données.
        /// </summary>
        /// <returns>
        /// Nombre de lignes affectées
        /// </returns>
        /// <param name="ioPhysiqueGen">un objet IophysiqueGenerique</param>   
        public int supprimerIoPhysiqueGen(IoPhysiqueGenerique ioPhysiqueGen)
        {
            DbCommand cmd = db.CreerCommande();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "DELETE FROM IO_Physique_Générique " +
                              "WHERE id_io_physique =" + ioPhysiqueGen.idIophysique;
            return db.ExecuterRequete(cmd);
        }



    }
}

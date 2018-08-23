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
      //Création des méthodes CRUD pour la classe IoPhysiqueAssociee
   */
    /// <summary>
    /// <c>IoPhysiqueData</c> class.
    /// Contient les méthodes CRUD de la classe Associer_IO_Physique
    /// </summary>
    /// <remarks>
    /// <para>Cette classe peut ajouter, modifier et supprimer un objet IoPhysiqueAssociee</para>
    /// <para>Cette classe permet d'obtenir la liste entière des IoPhysiqueAssociee</para>
    /// </remarks>   
    public class IoPhysiqueAssocieData
    {
        private DbConnexion db = new DbConnexion();
        private IoPhysiqueGenData iopgd = new IoPhysiqueGenData();


        /// <summary>
        /// Ajouter un <paramref name="ioPhysAss"/> dans la table Associer_Critère de la base de données pour une  <paramref name="FonctionElectronique"/>
        /// </summary>
        /// <returns>
        /// Nombre de lignes affectées
        /// </returns>
        /// <param name="critAss">un objet IoPhysiqueAssociee</param>  
        /// <param name="critAss">un objet FonctionElectronique</param> 
        public int ajouterIoPhysAssocieByFonction(FonctionElectronique fct, IoPhysiqueAssociee ioPhysAss)
        {
            DbCommand cmd = db.CreerCommande();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "INSERT INTO Associer_IO_Physique(id_projet,id_fonction, id_io_physique  , "
                            + "	quantité) " +
                                "VALUES ('" + fct.projet.idProjet  
                                + "', '" + fct.fonction.idFonction + "', '"
                                + ioPhysAss.ioPhysique.idIophysique + "', '" + ioPhysAss.quantite + "')";
            return db.ExecuterRequete(cmd);
        }

        /// <summary>
        /// Obtenir une liste d'objet IoPhysiqueAssociee pour <paramref name="fct"/>
        /// </summary>
        /// <returns>
        /// Une liste d'objet IoPhysiqueAssociee
        /// </returns> 
        /// <param name="fct">un objet FonctionElectronique</param>  
        public List<IoPhysiqueAssociee> getListIoAssocieeByFonction(FonctionElectronique fct)
        {
            List<IoPhysiqueAssociee> listIotAss = new List<IoPhysiqueAssociee>();

            DbCommand cmd = db.CreerCommande();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select * from Associer_IO_Physique where " +
            "id_projet='" + fct.projet.idProjet  + "' and  id_fonction='" 
            + fct.fonction.idFonction + "'";
            DataTable table = db.CreerDatatable(cmd);

            foreach (DataRow row in table.Rows)
            {
                IoPhysiqueAssociee ioAss = new IoPhysiqueAssociee();
                ioAss.ioPhysique = iopgd.getIoGenById((int)row[2]);
                ioAss.quantite = (int) row[3];
                listIotAss.Add(ioAss);
            }
            return listIotAss;
        }

        /// <summary>
        /// Modifier un <paramref name="ioAss"/> dans la table Associer_IO_Physique de la base de données pour <paramref name="fct"/>
        /// </summary>
        /// <returns>
        /// Nombre de lignes affectées
        /// </returns>
        /// <param name="ioAss">un objet IoPhysiqueAssociee</param>  
        /// <param name="fct">un objet FonctionElectronique</param>  
        public int modifierIoPhysAssocieByFonction(FonctionElectronique fct, IoPhysiqueAssociee ioAss)
        {
            DbCommand cmd = db.CreerCommande();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "UPDATE Associer_IO_Physique " +
                                "SET "
                                + "quantité = '" + ioAss.quantite + "' "                             
                                + "WHERE "
                                + "id_projet = '" + fct.projet.idProjet  + "' "
                                + "and id_fonction = " + fct.fonction.idFonction + " "
                                + "and id_io_physique = " + ioAss.ioPhysique.idIophysique + " ";
            return db.ExecuterRequete(cmd);
        }

        /// <summary>
        /// Supprimer tout les ioPhysique dans la table Associer_IO_Physique de la base de données pour <paramref name="fct"/>
        /// </summary>
        /// <returns>
        /// Nombre de lignes affectées
        /// </returns>
        /// <param name="fct">un objet FonctionElectronique</param> 
        public int supprimerIoPhystAssocieByFonction(FonctionElectronique fct)
        {
            DbCommand cmd = db.CreerCommande();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "DELETE FROM Associer_IO_Physique " +
                              "WHERE id_projet ='" + fct.projet.idProjet  + "' and  id_fonction= " + fct.fonction.idFonction;
            return db.ExecuterRequete(cmd);

        }


    
    }
}

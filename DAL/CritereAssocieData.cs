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
    public class CritereAssocieData
    {
        private DbConnexion db = new DbConnexion();
        private CritereGenData cgd = new CritereGenData();


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
            DbCommand cmd = db.CreerCommande();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "INSERT INTO Associer_Critère(id_projet,id_fonction, id_critère  , "
                            + "niveau_nombre, niveau_texte) " +
                                "VALUES ('" + fct.projet.idProjet
                                + "', '" + fct.fonction.idFonction + "', '"
                                + critAss.critere.idCritere + "', '" + critAss.valeurNbr.Replace(",",".") + "', '" + critAss.valeurTexte  + "')";
            return db.ExecuterRequete(cmd);
        }
            

        /// <summary>
        /// Obtenir une liste d'objet CritereAssociee pour <paramref name="fct"/>
        /// </summary>
        /// <returns>
        /// Une liste d'objet CritereAssociee
        /// </returns> 
        /// <param name="fct">un objet FonctionElectronique</param>  
        public List<CritereAssociee> getListCritAssocieeByFonction(FonctionElectronique fct)
        {
            List<CritereAssociee> listCritAss = new List<CritereAssociee>();

            DbCommand cmd = db.CreerCommande();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select * from Associer_Critère where " +
            "id_projet='" + fct.projet.idProjet  + "' and  id_fonction='" + fct.fonction.idFonction + "'";
            DataTable table = db.CreerDatatable(cmd);

            foreach (DataRow row in table.Rows)
            {
                CritereAssociee critAss = new CritereAssociee();              
                critAss.critere = cgd.getCritGenById((int)row[2]);
                critAss.valeurNbr = row[3].ToString();
                critAss.valeurTexte = (string)row[4].ToString();
                listCritAss.Add(critAss);
            }
            return listCritAss;
        }



        /// <summary>
        /// Modifier un <paramref name="critAss"/> dans la table Associer_Critère de la base de données pour <paramref name="fct"/>
        /// </summary>
        /// <returns>
        /// Nombre de lignes affectées
        /// </returns>
        /// <param name="critAss">un objet CritereAssociee</param>  
        /// <param name="fct">un objet FonctionElectronique</param>  
        public int modifierCritAssocieByFonction(FonctionElectronique fct, CritereAssociee critAss)
        {
            DbCommand cmd = db.CreerCommande();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "UPDATE Associer_Critère " +
                                "SET "
                                + "niveau_nombre = '" + critAss.valeurNbr.Replace(",", ".") + "', "
                                + "niveau_texte = '" + critAss.valeurTexte  + "' "
                                + "WHERE "
                                + "id_projet = '" + fct.projet.idProjet  + "' "
                                + "and id_fonction = " + fct.fonction.idFonction + " "
                                + "and id_critère = " + critAss.critere.idCritere + " ";
            return db.ExecuterRequete(cmd);
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
            DbCommand cmd = db.CreerCommande();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "DELETE FROM Associer_Critère " +
                              "WHERE id_projet ='" + fct.projet.idProjet  
                              + "' and  id_fonction= " + fct.fonction.idFonction;
            return db.ExecuterRequete(cmd);
          
        }



    }
}

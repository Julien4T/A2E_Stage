using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BEL;
using System.Data.Common;
using System.Data;
using MySql.Data.MySqlClient;


namespace DAL
{
    /*
    //Création des méthodes CRUD pour la classe FonctionElectronique
    */
    /// <summary>
    /// <c>FonctionGenData</c> class.
    /// Contient les méthodes CRUD de la classe FonctionElectronique
    /// </summary>
    /// <remarks>
    /// <para>Cette classe peut ajouter, modifier et supprimer un objet FonctionElectronique</para>
    /// <para>Cette classe permet d'obtenir la liste entière des FonctionElectronique</para>
    /// </remarks> 
    /// 
    public class FonctionData
    {
        private DbConnexion db = new DbConnexion();
        private ProjetData prjManager = new ProjetData();
        private FonctionGenData fctGenData = new FonctionGenData();
        private IoPhysiqueAssocieData ioPhysAssData = new IoPhysiqueAssocieData();
        private CritereAssocieData critAssData = new CritereAssocieData();
        //private IoAssocieeManager fctIoManager = new IoAssocieeManager();
        //private CritereAssocieManager fctCritManager = new CritereAssocieManager();


        /// <summary>
        /// Ajouter un <paramref name="fctElec"/> dans la table Fonction de la base de données.
        /// </summary>
        /// <returns>
        /// Nombre de lignes affectées
        /// </returns>
        /// <param name="fctElec">un objet FonctionElectronique</param>     
        public int ajouterFonction(FonctionElectronique fctElec)
        {
            DbCommand cmd = db.CreerCommande();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "INSERT INTO Fonction " 
                                + "(id_projet, "
                                + "id_fonction , "
                                + "description , "
                                + "schéma , "
                                + "tension_entree_min , "
                                + "tension_entree_max , "
                                + "intensite_entree_min , "
                                + "intensite_entree_max , "
                                + "tension_sortie_min , "
                                + "tension_sortie_max , "
                                + "intensite_sortie_min , "
                                + "intensite_sortie_max , "                                     
                                + "cout , " 
                                + "validation , "
                                + "lien_SVN_Dossier_PV ) "
                                + "VALUES ('" + fctElec.projet.idProjet  + "', '" 
                                + fctElec.fonction.idFonction + "', '"
                                + fctElec.description  + "', '" 
                                + fctElec.schema + "', "
                                + fctElec.tensionInputMin.ToString().Replace(",", ".") + ", "
                                + fctElec.tensionInputMax.ToString().Replace(",", ".") + ", "
                                + fctElec.intensiteInputMin.ToString().Replace(",", ".") + ", "
                                + fctElec.intensiteInputMax.ToString().Replace(",", ".") + ", "
                                + fctElec.tensionOutputMin.ToString().Replace(",", ".") + ", "
                                + fctElec.tensionOutputMax.ToString().Replace(",", ".") + ", "
                                + fctElec.intensiteOutputMin.ToString().Replace(",", ".") + ", "
                                + fctElec.intensiteOutputMax.ToString().Replace(",", ".") + ", "
                                + fctElec.cout.ToString().Replace(",", ".") + ", "
                                + fctElec.validation + ", '"
                                + fctElec.lienSVNTest  + "')";          
            return db.ExecuterRequete(cmd);
          
        }
        /// <summary>
        /// Obtenir un objet FonctionElectronique par son <paramref name="idFonction"/>
        /// </summary>
        /// <returns>
        /// Un objet FonctionElectronique
        /// </returns>
        /// <param name="idFonction">Identifiant de la fonction</param>
        public FonctionElectronique getFonctionById(int idFonction, string idprojet)
        {
            FonctionElectronique fctElect = new FonctionElectronique();
            DbCommand cmd = db.CreerCommande();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select * from Fonction where id_fonction=" + idFonction + " and id_projet ='" + idprojet  + "";
            DataTable table = db.CreerDatatable(cmd);
            if (table.Rows.Count >= 1)
            {
                fctElect.projet = prjManager.getProjetById((string)table.Rows[0][0]);
                fctElect.fonction = fctGenData.getFonctionGenById((int)table.Rows[0][1]);
                fctElect.description = (string)table.Rows[0][2].ToString();
                fctElect.schema = (string)table.Rows[0][3].ToString();

                //les données io tension et intensité
                fctElect.tensionInputMin = float.Parse(table.Rows[0][4].ToString());
                fctElect.tensionInputMax = float.Parse(table.Rows[0][5].ToString());
                fctElect.intensiteInputMin = float.Parse(table.Rows[0][6].ToString());
                fctElect.intensiteInputMax = float.Parse(table.Rows[0][7].ToString());
                fctElect.tensionOutputMin = float.Parse(table.Rows[0][8].ToString());
                fctElect.tensionOutputMax = float.Parse(table.Rows[0][9].ToString());
                fctElect.intensiteOutputMin = float.Parse(table.Rows[0][10].ToString());
                fctElect.intensiteOutputMax = float.Parse(table.Rows[0][11].ToString());
                
                fctElect.cout = float.Parse(table.Rows[0][12].ToString());
                fctElect.validation = (Boolean)table.Rows[0][13];
                fctElect.lienSVNTest = (string)table.Rows[0][14].ToString();
                fctElect.enAttente = (Boolean)table.Rows[0][15];
                //fctElect.listIO = fctIoManager.getListIOAssocieeByFonction((string)table.Rows[0][0], (int)table.Rows[0][1]);
                //fctElect.listCritere = fctCritManager.getListCritAssocieeByFonction((string)table.Rows[0][0], (int)table.Rows[0][1]);
            }
            return fctElect;
        }

        /// <summary>
        /// Obtenir une liste d'objet FonctionElectronique
        /// </summary>
        /// <returns>
        /// Une liste d'objet FonctionElectronique
        /// </returns> 
        public List<FonctionElectronique> getListFonction()
        {
            List<FonctionElectronique> listFonction = new List<FonctionElectronique>();

            DbCommand cmd = db.CreerCommande();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select * from Fonction";
            DataTable table = db.CreerDatatable(cmd);

            foreach (DataRow row in table.Rows)
            {
                FonctionElectronique fctElect = new FonctionElectronique();

                fctElect.projet = prjManager.getProjetById((string)row[0]);
                fctElect.fonction = fctGenData.getFonctionGenById((int)row[1]);
                fctElect.description = (string)row[2].ToString();
                fctElect.schema = (string)row[3].ToString();
                //les données io tension et intensité
                fctElect.tensionInputMin = float.Parse(row[4].ToString());
                fctElect.tensionInputMax = float.Parse(row[5].ToString());
                fctElect.intensiteInputMin = float.Parse(row[6].ToString());
                fctElect.intensiteInputMax = float.Parse(row[7].ToString());
                fctElect.tensionOutputMin = float.Parse(row[8].ToString());
                fctElect.tensionOutputMax = float.Parse(row[9].ToString());
                fctElect.intensiteOutputMin = float.Parse(row[10].ToString());
                fctElect.intensiteOutputMax = float.Parse(row[11].ToString());

                fctElect.cout = float.Parse(row[12].ToString());
                fctElect.validation = (Boolean)row[13];
                fctElect.lienSVNTest = (string)row[14].ToString();
                fctElect.enAttente = (Boolean)row[15];
                fctElect.listIO = ioPhysAssData.getListIoAssocieeByFonction(fctElect);
                fctElect.listCritere = critAssData.getListCritAssocieeByFonction(fctElect);
                listFonction.Add(fctElect);
            }

            return listFonction;
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

            List<FonctionElectronique> listFonction = new List<FonctionElectronique>();

            DbCommand cmd = db.CreerCommande();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "call filtrerPremier (" + Math.Abs(f.fonction.idFonction) + ", "
                + f.tensionInMin.ToString().Replace(",", ".") + ", " + f.tensionInMax.ToString().Replace(",", ".") + ", "
                + f.intensiteInMin.ToString().Replace(",", ".") + ", " + f.intensiteInMax.ToString().Replace(",", ".") + ", "
                + f.tensionOutMin.ToString().Replace(",", ".") + ", " + f.tensionOutMax.ToString().Replace(",", ".") + ", "
                + f.intensiteOutMin.ToString().Replace(",", ".") + ", " + f.intensiteOutMax.ToString().Replace(",", ".") + ", "
                + ((f.critRecherche[0].crit != null) ? f.critRecherche[0].crit.idCritere : CritereRecherche.valeurParDefisNull) + ", " 
                + ((f.critRecherche[0].signe != null) ? f.critRecherche[0].signe.valeur : CritereRecherche.valeurParDefisNull) + ", "
                + f.critRecherche[0].valeur.ToString().Replace(",", ".") + ", "
                + ((f.critRecherche[1].crit != null) ? f.critRecherche[1].crit.idCritere : CritereRecherche.valeurParDefisNull) + ", " 
                + ((f.critRecherche[1].signe != null) ? f.critRecherche[1].signe.valeur : CritereRecherche.valeurParDefisNull) + ", "
                + f.critRecherche[1].valeur.ToString().Replace(",", ".") + ", "                
                 + ((f.critRecherche[2].crit != null) ? f.critRecherche[2].crit.idCritere : CritereRecherche.valeurParDefisNull) + ", " 
                + ((f.critRecherche[2].signe != null) ? f.critRecherche[2].signe.valeur : CritereRecherche.valeurParDefisNull) + ", "
                + f.critRecherche[2].valeur.ToString().Replace(",", ".") + ", "                
                 + ((f.critRecherche[3].crit != null) ? f.critRecherche[3].crit.idCritere : CritereRecherche.valeurParDefisNull) + ", " 
                + ((f.critRecherche[3].signe != null) ? f.critRecherche[3].signe.valeur : CritereRecherche.valeurParDefisNull) + ", "
                + f.critRecherche[3].valeur.ToString().Replace(",", ".") + ", "                
                 + ((f.critRecherche[4].crit != null) ? f.critRecherche[4].crit.idCritere : CritereRecherche.valeurParDefisNull) + ", " 
                + ((f.critRecherche[4].signe != null) ? f.critRecherche[4].signe.valeur : CritereRecherche.valeurParDefisNull) + ", "
                + f.critRecherche[4].valeur.ToString().Replace(",", ".") + ", "                
                 + ((f.critRecherche[5].crit != null) ? f.critRecherche[5].crit.idCritere : CritereRecherche.valeurParDefisNull) + ", " 
                + ((f.critRecherche[5].signe != null) ? f.critRecherche[5].signe.valeur : CritereRecherche.valeurParDefisNull) + ", "
                + f.critRecherche[5].valeur.ToString().Replace(",", ".") + ", "
                + ((f.ioRecherche[0].io != null) ? f.ioRecherche[0].io.idIophysique : CritereRecherche.valeurParDefisNull) + ", "
                + ((f.ioRecherche[0].signe != null) ? f.ioRecherche[0].signe.valeur : CritereRecherche.valeurParDefisNull) + ", "
                + f.ioRecherche[0].valeur.ToString().Replace(",", ".") + ", "
                 + ((f.ioRecherche[1].io != null) ? f.ioRecherche[1].io.idIophysique : CritereRecherche.valeurParDefisNull) + ", "
                + ((f.ioRecherche[1].signe != null) ? f.ioRecherche[1].signe.valeur : CritereRecherche.valeurParDefisNull) + ", "
                + f.ioRecherche[1].valeur.ToString().Replace(",", ".") + ", "
                 + ((f.ioRecherche[1].io != null) ? f.ioRecherche[1].io.idIophysique : CritereRecherche.valeurParDefisNull) + ", "
                + ((f.ioRecherche[1].signe != null) ? f.ioRecherche[1].signe.valeur : CritereRecherche.valeurParDefisNull) + ", "
                + f.ioRecherche[1].valeur.ToString().Replace(",", ".") + " "
                + ") ";




            DataTable table = db.CreerDatatable(cmd);

            foreach (DataRow row in table.Rows)
            {
                FonctionElectronique fctElect = new FonctionElectronique();

                fctElect.projet = prjManager.getProjetById((string)row[0]);
                fctElect.fonction = fctGenData.getFonctionGenById((int)row[1]);
                fctElect.description = (string)row[2].ToString();
                fctElect.schema = (string)row[3].ToString();
                //les données io tension et intensité
                fctElect.tensionInputMin = float.Parse(row[4].ToString());
                fctElect.tensionInputMax = float.Parse(row[5].ToString());
                fctElect.intensiteInputMin = float.Parse(row[6].ToString());
                fctElect.intensiteInputMax = float.Parse(row[7].ToString());
                fctElect.tensionOutputMin = float.Parse(row[8].ToString());
                fctElect.tensionOutputMax = float.Parse(row[9].ToString());
                fctElect.intensiteOutputMin = float.Parse(row[10].ToString());
                fctElect.intensiteOutputMax = float.Parse(row[11].ToString());

                fctElect.cout = float.Parse(row[12].ToString());
                fctElect.validation = (Boolean)row[13];
                fctElect.lienSVNTest = (string)row[14].ToString();
                fctElect.enAttente = (Boolean)row[15];
                fctElect.taux = float.Parse(row[16].ToString());
                fctElect.listIO = ioPhysAssData.getListIoAssocieeByFonction(fctElect);
                fctElect.listCritere = critAssData.getListCritAssocieeByFonction(fctElect);
                listFonction.Add(fctElect);
            
            }
            return listFonction;
        }



        /// <summary>
        /// Obtenir une liste d'objet FonctionElectronique avec une close where 
        /// </summary>
        /// <returns>
        /// Une liste d'objet FonctionElectronique
        /// </returns> 
        public List<FonctionElectronique> getListFonction(string closeWhere)
        {
            List<FonctionElectronique> listFonction = new List<FonctionElectronique>();

            DbCommand cmd = db.CreerCommande();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select * from Fonction where " + closeWhere ;
            DataTable table = db.CreerDatatable(cmd);

            foreach (DataRow row in table.Rows)
            {
                FonctionElectronique fctElect = new FonctionElectronique();

                fctElect.projet = prjManager.getProjetById((string)row[0]);
                fctElect.fonction = fctGenData.getFonctionGenById((int)row[1]);
                fctElect.description = (string)row[2].ToString();
                fctElect.schema = (string)row[3].ToString();

                //les données io tension et intensité
                fctElect.tensionInputMin = float.Parse(row[4].ToString());
                fctElect.tensionInputMax = float.Parse(row[5].ToString());
                fctElect.intensiteInputMin = float.Parse(row[6].ToString());
                fctElect.intensiteInputMax = float.Parse(row[7].ToString());
                fctElect.tensionOutputMin = float.Parse(row[8].ToString());
                fctElect.tensionOutputMax = float.Parse(row[9].ToString());
                fctElect.intensiteOutputMin = float.Parse(row[10].ToString());
                fctElect.intensiteOutputMax = float.Parse(row[11].ToString());

                fctElect.cout = float.Parse(row[12].ToString());
                fctElect.validation = (Boolean)row[13];
                fctElect.lienSVNTest = (string)row[14].ToString();
                fctElect.enAttente = (Boolean)row[15];
                //fctElect.listIO = fctIoManager.getListIOAssocieeByFonction((string)row[0], (int)row[1]);
                //fctElect.listCritere = fctCritManager.getListCritAssocieeByFonction((string)row[0], (int)row[1]);
                listFonction.Add(fctElect);
            }

            return listFonction;
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
            DbCommand cmd = db.CreerCommande();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "UPDATE Fonction " +
                                "SET description = '" + fctElec.description  + "', "
                                + "schéma = '" + fctElec.schema + "', "
                                + "tension_entree_min = " + fctElec.tensionInputMin.ToString().Replace(",", ".") + ", "
                                + "tension_entree_max  = " + fctElec.tensionInputMax.ToString().Replace(",", ".") + ", "
                                + "intensite_entree_min  = " + fctElec.intensiteInputMin.ToString().Replace(",", ".") + ", "
                                + "intensite_entree_max  = " + fctElec.intensiteInputMax.ToString().Replace(",", ".") + ", "
                                + "tension_sortie_min = " + fctElec.tensionOutputMin.ToString().Replace(",", ".") + ", "
                                + "tension_sortie_max  = " + fctElec.tensionOutputMax.ToString().Replace(",", ".") + ", "
                                + "intensite_sortie_min  = " + fctElec.intensiteOutputMin.ToString().Replace(",", ".") + ", "
                                + "intensite_sortie_max  = " + fctElec.intensiteOutputMax.ToString().Replace(",", ".") + ", "
                                + "cout=" + fctElec.cout.ToString().Replace(",",".") + ", "
                                + "validation=" + fctElec.validation + ", "
                                + "lien_SVN_Dossier_PV='" + fctElec.lienSVNTest  + "', "
                                + "en_attente = " + fctElec.enAttente + " "
                                + "WHERE id_projet = '" + fctElec.projet.idProjet + "' and id_fonction=" + fctElec.fonction.idFonction;
            cmd.Parameters.Add(new MySqlParameter("@cout", MySqlDbType.Float, 8));
            cmd.Parameters["@cout"].Value = fctElec.cout; 
            return db.ExecuterRequete(cmd);
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
            DbCommand cmd = db.CreerCommande();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "DELETE FROM Fonction " +
                              "WHERE id_projet ='" + fctElec.projet.idProjet  + "' and id_fonction=" + fctElec.fonction.idFonction;
            return db.ExecuterRequete(cmd);
        }




      
    }
}
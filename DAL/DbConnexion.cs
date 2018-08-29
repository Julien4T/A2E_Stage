using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Data.Common;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace DAL
{
    public class DbConnexion
    {
        private enum connexionType { MaBaseOleDb, MaBaseSqlServer, MaBaseMySql };
        //construction liste de base de données ici pour notre projet il s'agit d'un moteur mariaDb donc chaine de connection MySql
        private static connexionType bddType = connexionType.MaBaseMySql;
        private DbConnection con;

        public DbConnection CreateConnexion()
        {
            //fonctoin générique qui ouvre la connection selon n'importa quel type de bdd (ici MySql) 

            switch (bddType)
            {
                case connexionType.MaBaseOleDb:
                    con = new OleDbConnection("maChaineDeConnexion");
                    break;
                case connexionType.MaBaseSqlServer:
                    con = new SqlConnection("maChaineDeConnexion");
                    break;
                case connexionType.MaBaseMySql:
                    //construction de la chaine de connection
                    DbConnectionStringBuilder connBuilder = new DbConnectionStringBuilder();
                    connBuilder.Add("Database", "Projets_Etudes");
                    connBuilder.Add("Data Source", "192.168.2.250");
                    connBuilder.Add("User Id", "root_etudes");
                    connBuilder.Add("Password", "dB24zK6c");
                    con = new MySqlConnection(connBuilder.ConnectionString);
                    break;
            }
            return con;
        }
        public DbCommand CreerCommande()
        {
            DbCommand db = null;
            switch (bddType)
            {
                case connexionType.MaBaseOleDb:
                    db = new OleDbCommand();
                    break;
                case connexionType.MaBaseSqlServer:
                    db = new SqlCommand();
                    break;
                case connexionType.MaBaseMySql:
                    db = new MySqlCommand();
                    break;
            }
            return db;
        }

        public int ExecuterRequete(DbCommand cmd)
        {
            con = CreateConnexion();
            
            con.Open();
            cmd.Connection = con;
            int ligneAffectee = -1;
            try
            {
                ligneAffectee = cmd.ExecuteNonQuery();
               
            }
            // Most specific:
            catch (DbException e )

            {                
                switch (e.ErrorCode)
                {
                       
                    case -2147467259:
                        MessageBox.Show("Vous ne pouvez pas insérer ses données, la clé primaire existe déjà "
                            , "Duplication impossible", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    default:
                         MessageBox.Show("Une erreur est survenue : " + e.Message, "Erreur base de données",MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                }

                
                
               

               
              
               
              
            }
            // Least specific:
            catch (Exception e)
            {
              
                MessageBox.Show(e.Message);             
            } 
            
            con.Close();
            return ligneAffectee;
        }

        public DataTable CreerDatatable(DbCommand cmd) 
        {
            con = CreateConnexion();
            DataTable table = new DataTable();

             try
            {
                cmd.Connection = con;
                DbDataAdapter dbda = null;
                switch (bddType)
                {
                    case connexionType.MaBaseOleDb:
                        dbda = new OleDbDataAdapter();
                        break;
                    case connexionType.MaBaseSqlServer:
                        dbda = new SqlDataAdapter();
                        break;
                    case connexionType.MaBaseMySql:
                        dbda = new MySqlDataAdapter();
                        break;
                }
                dbda.SelectCommand = cmd;
                
                dbda.Fill(table);
                con.Close();
               
            }
             catch (DbException e)
             {                 
                 MessageBox.Show("Une erreur est survenue : " + e.Message, "Erreur base de données", MessageBoxButtons.OK, MessageBoxIcon.Error);
             }
                      
       
            return table;        
        }
    }
 
}

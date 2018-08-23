using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Data;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Data.Common;
using System.Drawing;



namespace ConnectBDD
{
    public class Connection
    {
        private enum connectionType { MaBaseOleDb, MaBaseSqlServer, MaBaseMySql };
        //construction liste de base de données ici pour notre projet il s'agit d'un moteur mariaDb donc chaine de connection MySql
        private static connectionType bddType = connectionType.MaBaseMySql; 
     

        public static DbConnection CreateConnection()
        {
            //fonctoin générique qui ouvre la connection selon n'importa quel type de bdd (ici MySql) 
            DbConnection connection = null;

            switch (bddType)
            {
                case connectionType.MaBaseOleDb:
                    connection = new OleDbConnection("maChaineDeConnexion");
                    break;
                case connectionType.MaBaseSqlServer:
                    connection = new SqlConnection("maChaineDeConnexion");
                    break;
                case connectionType.MaBaseMySql:
                    //construction de la chaine de connection
                    DbConnectionStringBuilder connBuilder = new DbConnectionStringBuilder();
                    connBuilder.Add("Database", "Projets_Etudes");
                    connBuilder.Add("Data Source", "192.168.2.250");
                    connBuilder.Add("User Id", "root_etudes");
                    connBuilder.Add("Password", "dB24zK6c");
                    connection = new MySqlConnection(connBuilder.ConnectionString);
                    break;                      
            }
            
            return connection;
        }

        public static DbCommand CreerCommande(string commandText)
        {
            // Ajouter la gestion des cas d'erreur
           
            return CreateConnection().CreateCommand();
        }

        public static DataTable CreerDataTable(string commandText)
        {
            DbDataAdapter adapter = null;


            switch (bddType)
            {
                case connectionType.MaBaseOleDb:
                    adapter = new OleDbDataAdapter();
                    break;
                case connectionType.MaBaseSqlServer:
                    adapter = new SqlDataAdapter();
                    break;
                case connectionType.MaBaseMySql:
                    adapter = new MySqlDataAdapter();
                    break;
            }

            DbCommand commande = CreerCommande(commandText);
            commande.CommandText = commandText;
            adapter.SelectCommand = commande;

            DataTable ds = new DataTable();
            adapter.Fill(ds);
            adapter.SelectCommand.Connection.Close();
            
            return ds;
        }
        
        //public String getStringImage(Bitmap bmp){
           //ByteArrayOutputStream baos=new ByteArrayOutputStream();
           //bmp.compress(Bitmap.CompressFormat.JPEG, 100, baos);
           ////byte[] imageBytes= baos.toByteArray();
           //String encodedImage = Base64.encodeToString(imageBytes, Base64.DEFAULT);
           //return encodedImage;
        
        //}




       
    }
}

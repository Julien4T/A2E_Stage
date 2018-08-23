using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;

namespace ConnectBDD
{
    class Personnel
    {
        static String nomTable = "Personnel";

        public DataTable listePersonnel() 
        {
            return Connection.CreerDataTable("Select * from " + nomTable );
        
        }


        public static void InscrireNom(string nom, string prenom, string email)
        {
            string query = "Insert into " + nomTable + "(nom, prenom, adresse_mail) VALUES ('" + nom + "','" + prenom + "','" + email + "')";
            DbCommand commande = Connection.CreerCommande(query);
           

        }

    }
}

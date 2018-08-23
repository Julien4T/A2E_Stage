using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using BEL;
using System.Data.Common;
using System.Data;


namespace BAL
{
    public class ProjetManager
    {
        private ProjetData projetData = new ProjetData();

        /// <summary>
        /// Ajouter un <paramref name="projet"/> dans la table Personnel de la base de données.
        /// </summary>
        /// <returns>
        /// Nombre de lignes affectées
        /// </returns>
        /// <param name="projet">un objet Projet</param>     
        public int ajouterProjet(Projet projet)
        {
            return projetData.ajouterProjet(this.echappementProjet(projet));
        }

        public Projet getProjetById(string idProjet)
        {
            idProjet = idProjet.Replace("'", "''").Replace(@"\", "\\");  
            return projetData.getProjetById(idProjet);
        }

        // <summary>
        /// Obtenir une liste de tout les projets
        /// </summary>
        /// <returns>
        /// Une liste de projet
        /// </returns>
        public List<Projet> getListProjet()
        {
            return projetData.getListProjet();
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
            nom = nom.Replace("'", "''").Replace(@"\", "\\");  
            return projetData.modifierProjetByNom(this.echappementProjet(projet), nom);
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

            return projetData.supprimerProjet(this.echappementProjet(projet));
        }

        //controler les caractères d'échappement pour l'insertion SQL  
        private Projet echappementProjet(Projet projet)
        {
            Projet p = new Projet();
            p.idProjet = projet.idProjet.Replace("'", "''").Replace(@"\", "\\");          
            p.personnel = projet.personnel;
            p.dateProjet = projet.dateProjet;
            p.lienSnvProjet = projet.lienSnvProjet.Replace("'", "''").Replace(@"\", "\\");          
            return p;
        }
    }
}

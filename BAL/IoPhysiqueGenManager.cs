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
    /*
    //Création des méthodes CRUD pour la classe IophysiqueGenerique
    */
    /// <summary>
    /// <c>IoPhysiqueGenManager</c> class.
    /// Contient les méthodes logiques applicatives CRUD de la classe IophysiqueGenerique
    /// </summary>
    /// <remarks>
    /// <para>Cette classe peut ajouter, modifier et supprimer un objet IophysiqueGenerique</para>
    /// <para>Cette classe permet d'obtenir la liste entière des IophysiqueGenerique</para>
    /// </remarks>  
    public class IoPhysiqueGenManager
    {
        private IoPhysiqueGenData iopgd = new IoPhysiqueGenData();
     

        /// <summary>
        /// Ajouter un <paramref name="IoPhysiqueGen"/> dans la table IO_Physique_Générique de la base de données.
        /// </summary>
        /// <returns>
        /// Nombre de lignes affectées
        /// </returns>
        /// <param name="IoPhysiqueGen">un objet IophysiqueGenerique</param>     
        public int ajouterIoPhysiqueGen(IoPhysiqueGenerique ioPhysiqueGen)
        {
            if (ioPhysiqueGen.designation.Trim() == "")
            {
                return 0;
            }
            else
            {
                return iopgd.ajouterIoPhysiqueGen(this.echappementIoPhysGen(ioPhysiqueGen));
            }        
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
            return iopgd.getIoGenById(idIo);
        }

        /// <summary>
        /// Obtenir une liste d'objet IophysiqueGenerique
        /// </summary>
        /// <returns>
        /// Une liste d'objet IophysiqueGenerique
        /// </returns> 
        public List<IoPhysiqueGenerique> getListIoPhysiqueGen()
        {
            return iopgd.getListIoPhysiqueGen();
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
            if (ioPhysiqueGen.designation.Trim() == "")
            {
                return 0;
            }
            else
            {
                return iopgd.modifierIoPhysiqueGen(this.echappementIoPhysGen(ioPhysiqueGen));
            }
                     
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
            return iopgd.supprimerIoPhysiqueGen(this.echappementIoPhysGen(ioPhysiqueGen));
           
        }

        //controler les caractères d'échappement pour l'insertion SQL  
        private IoPhysiqueGenerique echappementIoPhysGen(IoPhysiqueGenerique ioPhysiqueGen)
        {
            IoPhysiqueGenerique iopg = new IoPhysiqueGenerique();
            iopg.idIophysique = ioPhysiqueGen.idIophysique;
            iopg.designation = ioPhysiqueGen.designation.Replace("'", "''").Replace(@"\", "\\");
            iopg.description = ioPhysiqueGen.description.Replace("'", "''").Replace(@"\", "\\");
            return iopg;
        }

    }
}

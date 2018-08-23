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
    public class IoPhysiqueAssocieManager
    {

        private IoPhysiqueAssocieData iopad = new IoPhysiqueAssocieData();

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
            return iopad.ajouterIoPhysAssocieByFonction(this.echappementFonction(fct), ioPhysAss);
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
            return iopad.getListIoAssocieeByFonction(this.echappementFonction(fct)); ;
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
            return iopad.modifierIoPhysAssocieByFonction(this.echappementFonction(fct), ioAss);
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
            return iopad.supprimerIoPhystAssocieByFonction(this.echappementFonction(fct));

        }

        //controler les caractères d'échappement pour l'insertion SQL  
        private FonctionElectronique echappementFonction(FonctionElectronique fct)
        {
            FonctionElectronique f = new FonctionElectronique();
            f = fct;
            f.projet.idProjet = f.projet.idProjet.Replace("'", "''").Replace(@"\", "\\");
 
            return f;
        }

      


    }
}

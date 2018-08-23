using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BEL;
using BAL;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text.RegularExpressions;


namespace IHM
{
    public class IhmManager
    {
        public static Personnel pers = new Personnel();
       
        //public static PersonnelManager persoManager = new PersonnelManager();
        //public static IhmManager ihmManager = new IhmManager();

        public enum metier { Personnel, Projet, FonctionGen, IoPhysGen, CritGen };
      
        
        
        public static Boolean ajouter = false;  // Booléen choix de la méthode ajouter (true) ou modifier (false)
        public static Boolean ajouterFonctionElect = false;  // Booléen choix de la méthode ajouter (true) ou modifier (false) pour la fonction electronique
        public static Boolean ajouterAssociation = false;  // Booléen choix de la méthode ajouter (true) ou modifier (false) pour les critères et Io associés à la fonction
     

        //Paramètres CRUD pour FonctionGénérique
        public static List<FonctionGenerique> listFctGen = new List<FonctionGenerique>();
        public static FonctionGenerique fctGenSelect = new FonctionGenerique();
        private FonctionGenManager fctGenManager = new FonctionGenManager();

        //Paramètres CRUD pour CritereGenerique
        public static List<CritereGenerique> listCritGen = new List<CritereGenerique>();
        public static CritereGenerique critGenSelect = new CritereGenerique();
        private CritereGenManager critGenManager = new CritereGenManager();

        //Paramètres CRUD pour IophysiqueGenerique
        public static List<IoPhysiqueGenerique> listIoPhysGen = new List<IoPhysiqueGenerique>();
        public static IoPhysiqueGenerique ioPhysGenSelect = new IoPhysiqueGenerique();
        private IoPhysiqueGenManager ioPhysGenManager = new IoPhysiqueGenManager();

        //Paramètres CRUD pour Projet et personnel
        public static List<Projet> listProjet = new List<Projet>();
        public static List<Personnel> listPers = new List<Personnel>();
        public static Projet projetSelect = new Projet();
        public static Personnel persSelect = new Personnel();
        private ProjetManager projetManager = new ProjetManager();
        private PersonnelManager persManager = new PersonnelManager();


        //Paramètres CRUD pour FonctionElectronique
        
        public static List<FonctionElectronique> listFctElct = new List<FonctionElectronique>();
        public static FonctionElectronique fctElectSelect = new FonctionElectronique();
        public static CritereAssociee critAssSelect = new CritereAssociee();
        public static IoPhysiqueAssociee ioPhysAssSelect = new IoPhysiqueAssociee();
      
        private string cheminAccesImage = @"\\Backup\web\Projets_Etudes\Schemas\"; //chemin pour stocker l'image sur le serveur


         


        /*raffraichir les données des comboboxs en cascade pour la liste des fonctions génériques 
        (rubrique pour une et désignation en fonction de la rubrique pour l'autre)
        */
        public void raffraichirCombobox(metier m, ComboBox cb1, ComboBox cb2)
        {
            if (m == metier.FonctionGen)
            {                
                    IhmManager.listFctGen = this.fctGenManager.getListFonctionGen();
                    cb1.DataSource = IhmManager.listFctGen
                                .GroupBy(r => r.rubrique)
                                .Select(ru => ru.Key)
                                .ToList(); ;
                    cb2.DataSource = IhmManager.listFctGen
                                .OrderBy(d => d.designation)
                                .Where(r => r.rubrique == cb1.SelectedValue.ToString())
                                .ToList();
            } 
        }
        public void raffraichirCombobox(metier m , ComboBox cb) 
        {
            switch (m)
            {

                case metier.Projet:
                    IhmManager.listProjet = this.projetManager.getListProjet();
                    cb.DataSource = IhmManager.listProjet;                   
                    break;
                case metier.Personnel:
                    IhmManager.listPers = this.persManager.getListPersonnel();
                    cb.DataSource = IhmManager.listPers;                    
                    break;
                case metier.FonctionGen:                   
                    break;
                case metier.IoPhysGen:
                    IhmManager.listIoPhysGen = this.ioPhysGenManager.getListIoPhysiqueGen();
                    cb.DataSource = IhmManager.listIoPhysGen;                    
                    break;
                case metier.CritGen:
                    IhmManager.listCritGen = this.critGenManager.getListCriGen();
                    cb.DataSource = IhmManager.listCritGen;                    
                    break;
                default:
                    break;
            }
        }      

        public void ajouterObj(metier m) 
        {
            IhmManager.ajouter = true;
            Form form;
            switch (m)
            {
                case metier.Projet:                    
                    form = new FenCrudProjet();
                    form.ShowDialog();                    
                    break;
                case metier.Personnel:
                    form = new FenCrudPersonnel();
                    form.ShowDialog();
                    break;
                case metier.FonctionGen:
                    form = new FenCrudFctGen();
                    form.ShowDialog();      
                    break;
                case metier.IoPhysGen:
                    form = new FenCrudIoPhysiqueGen();
                    form.ShowDialog();      
                    break;
                case metier.CritGen:
                    form = new FenCrudCritGen();
                    form.ShowDialog();      
                    break;
                default:
                    break;
            }       
        
        }
        public void modifierObj(metier m, Object ob)
        {
            IhmManager.ajouter = false;
            Form form;
            switch (m)
            {
                case metier.Projet:
                    IhmManager.projetSelect = (Projet)ob;                   
                    form = new FenCrudProjet();
                    form.ShowDialog();               
                    break;
                case metier.Personnel:
                    IhmManager.persSelect = (Personnel)ob;
                    form = new FenCrudPersonnel();
                    form.ShowDialog();
                    break;
                case metier.FonctionGen:
                    IhmManager.fctGenSelect = (FonctionGenerique)ob;
                    form = new FenCrudFctGen();
                    form.ShowDialog();
                    break;
                case metier.IoPhysGen:
                    IhmManager.ioPhysGenSelect = (IoPhysiqueGenerique)ob;
                    form = new FenCrudIoPhysiqueGen();
                    form.ShowDialog();
                    break;
                case metier.CritGen:
                    IhmManager.critGenSelect = (CritereGenerique)ob;
                    form = new FenCrudCritGen();
                    form.ShowDialog();
                    break;
                default:
                    break;
            }       
        }
        public void supprimerObj(metier m, Object ob)
        {
            DialogResult dialogResult ;

            switch (m)
            {
                case metier.Projet:

                    IhmManager.projetSelect = (Projet)ob;
                    dialogResult = MessageBox.Show("Etes-vous sur de vouloir supprimer le projet #" + IhmManager.projetSelect + " ?",
                        "Suppression", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (dialogResult == DialogResult.Yes)
                    {
                        //do something
                        this.projetManager.supprimerProjet(IhmManager.projetSelect);                      
                    }
                    break;

                case metier.Personnel:

                    IhmManager.persSelect = (Personnel)ob;
                    dialogResult = MessageBox.Show("Etes-vous sur de vouloir supprimer le personnel #" + IhmManager.persSelect + " ?",
                       "Suppression", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (dialogResult == DialogResult.Yes)
                    {
                        //do something
                        this.persManager.supprimerPersonne(IhmManager.persSelect);
                    }
                    break;

                case metier.FonctionGen:

                    IhmManager.fctGenSelect = (FonctionGenerique)ob;
                    dialogResult = MessageBox.Show("Etes-vous sur de vouloir supprimer la fonction #" + IhmManager.fctGenSelect + " ?",
                       "Suppression", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (dialogResult == DialogResult.Yes)
                    {
                        //do something
                        this.fctGenManager.supprimerFctGen(IhmManager.fctGenSelect);
                    }
                    break;

                case metier.IoPhysGen:

                    IhmManager.ioPhysGenSelect = (IoPhysiqueGenerique) ob;
                    dialogResult = MessageBox.Show("Etes-vous sur de vouloir supprimer l'IO physique #" + IhmManager.ioPhysGenSelect + " ?",
                        "Suppression", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (dialogResult == DialogResult.Yes)
                    {
                        //do something
                        this.ioPhysGenManager.supprimerIoPhysiqueGen(IhmManager.ioPhysGenSelect);
                    }
                    break;

                case metier.CritGen:

                    IhmManager.critGenSelect = (CritereGenerique)ob;
                    dialogResult = MessageBox.Show("Etes-vous sur de vouloir supprimer le critère #" + IhmManager.critGenSelect + " ?",
                        "Suppression", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (dialogResult == DialogResult.Yes)
                    {
                        //do something
                        this.critGenManager.supprimerCritGen(IhmManager.critGenSelect);
                    }
                    break;
                default:
                    break;
            }
        }
        
        public string cleanString(string strIn)
        {
            // Replace invalid characters with empty strings.
            try
            {
                return Regex.Replace(strIn, @"[^\w\.@-]", "",
                                     RegexOptions.None);
            }
            // If we timeout when replacing invalid characters, 
            // we should return Empty.
            catch (Exception)
            {
                return String.Empty;
            }
        }

        public string enregistrerImage(Bitmap image, string nomImage) 
        {
            string lienImage = this.cheminAccesImage;
           
            nomImage = this.cleanString(nomImage);
            lienImage += nomImage + ".jpeg";
            string lienForBdd = lienImage.Replace(@"\", @"\\");  

            try
            {               
                image.Save(lienImage, ImageFormat.Jpeg);
                return lienForBdd;
            }   
            catch (Exception e)
            {             
                MessageBox.Show(e.Message);
                return null;
            }  
        }
        public Size chargerSchema(string chemin, PictureBox pb)
        {
            Size s = new Size();

            try
            {
                Bitmap schema = (Bitmap)Image.FromFile(chemin);
                Bitmap schema2 = new Bitmap(schema);               
                pb.Image = schema2;
                pb.Height = schema2.Height;
                pb.Width = schema2.Width;
                s = new Size(schema2.Width, schema2.Height);
                schema.Dispose();
            }
            catch (Exception e)
            {
                MessageBox.Show("Une erreur est survenue : " + e.Message, "Impossible de charger l'image", MessageBoxButtons.OK, MessageBoxIcon.Error);
                pb.Image = null;
                pb.Refresh();
            }
            return s;
        }
        public void chargerSchema(Bitmap image, PictureBox pb)
        {          
            try
            {
                Bitmap schema = new Bitmap(image);
                pb.Image = schema;
                image.Dispose();
            }
            catch (Exception e)
            {
                MessageBox.Show("Une erreur est survenue : " + e.Message, "Impossible de charger l'image", MessageBoxButtons.OK, MessageBoxIcon.Error);
               
            }
        }

        //Cette fonction autorise seulement les nombres et une seule virgule dans la textbox    
        public void texteBoxFloatConstraint(TextBox tb, KeyPressEventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(e.KeyChar.ToString().ToUpper(), @"[^0-9^.]"))
            {
                //Empeche les characteres autre que ceux specifié d'être écris
                e.Handled = true;
            }
            if (e.KeyChar == (char)8) //autorise la touche backspace
            {
                e.Handled = false;
            }
            if ((tb.Text.Contains(".") || tb.Text.Contains(",")) & e.KeyChar == '.') // autorise un seul .
            {
                e.Handled = true;
            }
            if (tb.Text.Length <=0  & e.KeyChar == '-') // autorise un seul - au début du mot
            {
                e.Handled = false;
            }
        }
        public void texteBoxIntConstraint(TextBox tb, KeyPressEventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(e.KeyChar.ToString().ToUpper(), @"[^0-9^]"))
            {
                //Empeche les characteres autre que ceux specifié d'être écris
                e.Handled = true;
            }
            if (e.KeyChar == (char)8) //autorise la touche backspace
            {
                e.Handled = false;
            }        
        }




    }
}

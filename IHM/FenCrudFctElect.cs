using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BEL;
using BAL;
using CaptureEcran;

namespace IHM
{
    public partial class FenCrudFctElect : Form
    {
        public enum state {ajouter, modifier}
        public static state etat;
         
        private IhmManager ihmM = new IhmManager();
        private ProjetManager projetManager = new ProjetManager();
        private FonctionElectronique fctElectronique;
        private FonctionManager fctManager = new FonctionManager();
        private CritereAssocieManager critAssocieManager = new CritereAssocieManager();
        private IoPhysiqueAssocieManager ioPhysAssocieManager = new IoPhysiqueAssocieManager();
       
        public FenCrudFctElect()
        {
            InitializeComponent();
        }
        private void FenCrudFctElect_Load(object sender, EventArgs e)
        {
            this.initialiserDonnees(FenCrudFctElect.etat);
        }

        #region Main fonction
        private void initialiserDonnees(state e) {

            ihmM.raffraichirCombobox(IhmManager.metier.Projet, comboBoxProjet);
            ihmM.raffraichirCombobox(IhmManager.metier.FonctionGen, comboBoxRubrique, comboBoxFonction);
            IhmManager.projetSelect = (Projet)comboBoxProjet.SelectedValue;
            this.fctElectronique = new FonctionElectronique();

            switch (e)
            {
                case FenCrudFctElect.state.ajouter:
                    
                    this.fctElectronique.enAttente = true;
                    this.comboBoxProjet.Enabled = true;
                    this.comboBoxRubrique.Enabled = true;
                    this.comboBoxFonction.Enabled = true;
                    this.buttonValider.Visible = false;

                    this.addProjet.Enabled = true;
                    this.updateProjet.Enabled = true;
                    this.deleteProjet.Enabled = true;

                    this.addFonction.Enabled = true;
                    this.updateFonction.Enabled = true;
                    this.deleteFonction.Enabled = true;

                    this.pictureBox1.Image = null;

                    this.textBoxLienSvnTest.Text =  IhmManager.projetSelect.lienSnvProjet;

                    this.supprimerLaFonctionToolStripMenuItem.Enabled = false;

                    break;
                case FenCrudFctElect.state.modifier:

                    this.fctElectronique = IhmManager.fctElectSelect;
                    this.fctElectronique.listCritere = this.critAssocieManager.getListCritAssocieeByFonction(IhmManager.fctElectSelect).ToList();
                    this.fctElectronique.listIO = this.ioPhysAssocieManager.getListIoAssocieeByFonction(IhmManager.fctElectSelect).ToList();
                    
                    this.comboBoxProjet.Text = IhmManager.fctElectSelect.projet.ToString();
                    this.comboBoxProjet.Enabled = false;
                    this.comboBoxRubrique.Text = IhmManager.fctElectSelect.fonction.rubrique;
                    this.comboBoxRubrique.Enabled = false;
                    this.comboBoxFonction.Text = IhmManager.fctElectSelect.fonction.designation;
                    this.comboBoxFonction.Enabled = false;
           
                    this.ihmM.chargerSchema(this.fctElectronique.schema, pictureBox1);

                    this.buttonValider.Visible = true;

                    this.addProjet.Enabled = false;
                    this.updateProjet.Enabled = false;
                    this.deleteProjet.Enabled = false;

                    this.addFonction.Enabled = false;
                    this.updateFonction.Enabled = false;
                    this.deleteFonction.Enabled = false;

                    this.textBoxLienSvnTest.Text = this.fctElectronique.lienSVNTest;

                    this.supprimerLaFonctionToolStripMenuItem.Enabled = true;
                    break;
                default:
                    break;
            }

            this.radioButtonTestOui.Checked = (this.fctElectronique.validation) ? true : false;
            this.radioButtonTestNon.Checked = (!this.fctElectronique.validation) ? true : false;

            this.comportementButtonValider();                      

            //charger les io tension intensité dans les tb
            this.textBox3.Text = this.fctElectronique.tensionInputMin.ToString();
            this.textBox4.Text = this.fctElectronique.tensionInputMax.ToString();
            this.textBox5.Text = this.fctElectronique.intensiteInputMin.ToString();
            this.textBox6.Text = this.fctElectronique.intensiteInputMax.ToString();
            this.textBox7.Text = this.fctElectronique.tensionOutputMin.ToString();
            this.textBox8.Text = this.fctElectronique.tensionOutputMax.ToString();
            this.textBox9.Text = this.fctElectronique.intensiteOutputMin.ToString();
            this.textBox10.Text = this.fctElectronique.intensiteOutputMax.ToString(); 
            
            this.textBoxCout.Text = this.fctElectronique.cout.ToString();
            this.richTextBoxDescription.Text = this.fctElectronique.description;
            this.listBoxCrit.DataSource = this.fctElectronique.listCritere;
            this.listBoxIo.DataSource = this.fctElectronique.listIO;        
        }
        private int enregistrer(state e)
        {
            int nbLigne = 0;

            this.fctElectronique.projet = (Projet)this.comboBoxProjet.SelectedValue;
            this.fctElectronique.fonction = (FonctionGenerique)this.comboBoxFonction.SelectedValue;

            //données io tension intensite
            this.fctElectronique.tensionInputMin    = (textBox3.Text != "") ? float.Parse(textBox3.Text.Replace(".", ",")) : 0;
            this.fctElectronique.tensionInputMax    = (textBox4.Text != "") ? float.Parse(textBox4.Text.Replace(".", ",")) : this.fctElectronique.tensionInputMin;
            this.fctElectronique.intensiteInputMin  = (textBox5.Text != "") ? float.Parse(textBox5.Text.Replace(".", ",")) : 0;
            this.fctElectronique.intensiteInputMax  = (textBox6.Text != "") ? float.Parse(textBox6.Text.Replace(".", ",")) : this.fctElectronique.intensiteInputMin;
            this.fctElectronique.tensionOutputMin   = (textBox7.Text != "") ? float.Parse(textBox7.Text.Replace(".", ",")) : 0;
            this.fctElectronique.tensionOutputMax   = (textBox8.Text != "") ? float.Parse(textBox8.Text.Replace(".", ",")) : this.fctElectronique.tensionOutputMin;
            this.fctElectronique.intensiteOutputMin = (textBox9.Text != "") ? float.Parse(textBox9.Text.Replace(".", ",")) : 0;
            this.fctElectronique.intensiteOutputMax = (textBox10.Text != "") ? float.Parse(textBox10.Text.Replace(".", ",")) : this.fctElectronique.intensiteOutputMin;

            this.fctElectronique.cout = (textBoxCout.Text != "") ? float.Parse(textBoxCout.Text.Replace(".", ",")) : 0;

            string nomFichierImage = this.comboBoxFonction.Text + "-" + this.fctElectronique.projet.idProjet;
            this.fctElectronique.schema = ihmM.enregistrerImage((Bitmap)pictureBox1.Image, nomFichierImage);

            this.fctElectronique.description = richTextBoxDescription.Text;
                     
            this.fctElectronique.validation = radioButtonTestOui.Checked;
            this.fctElectronique.lienSVNTest = textBoxLienSvnTest.Text;            

            switch (e)
            {
                case FenCrudFctElect.state.ajouter:                    
                    //si problème lors de l'ajoutFonction, on ne continue pas
                    int i =  this.fctManager.ajouterFonction(this.fctElectronique);
                    if ( i < 0 )
                    {                       
                        break;
                    }
                    this.saveListCritere();
                    this.saveListIo();
                    IhmManager.fctElectSelect = this.fctElectronique;
                    FenCrudFctElect.etat = state.modifier;
                    this.initialiserDonnees(FenCrudFctElect.etat);
                    break;
                case FenCrudFctElect.state.modifier:                   
                    this.fctManager.modifierFonction(this.fctElectronique);
                    this.saveListCritere();
                    this.saveListIo();
                    break;
            }           
            return nbLigne;

        }
        private void comportementButtonValider()
        {
            if (this.fctElectronique.enAttente)
            {
                this.buttonValider.Text = "Fonction en attente de validation !";
                this.buttonValider.Image = IHM.Properties.Resources.validerNon;
                this.Refresh();
            }
            else
            {
                this.buttonValider.Text = "Fonction validée !";
                this.buttonValider.Image = IHM.Properties.Resources.valider;
                this.Refresh();
            }

        }
        private void saveListCritere()
        {
            this.critAssocieManager.supprimerCritAssocieByFonction(this.fctElectronique);
            foreach (CritereAssociee crit in this.fctElectronique.listCritere)
            {
                this.critAssocieManager.ajouterCritAssocieByFonction(this.fctElectronique, crit);
            }
        }
        private void saveListIo()
        {
            this.ioPhysAssocieManager.supprimerIoPhystAssocieByFonction(this.fctElectronique);
            foreach (IoPhysiqueAssociee io in this.fctElectronique.listIO)
            {
                this.ioPhysAssocieManager.ajouterIoPhysAssocieByFonction(this.fctElectronique, io);
            }
        }
        #endregion

        #region Boutons Menu
        private void nouveauToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult;
            dialogResult = MessageBox.Show("Voulez-vous sauvegarder les modifications avant d'ajouter une nouvelle fonction?",
               "Nouveau", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                this.enregistrer(FenCrudFctElect.etat);
            }

            FenCrudFctElect.etat = state.ajouter;
            this.initialiserDonnees(FenCrudFctElect.etat);
        }
        private void supprimerLaFonctionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult;
            dialogResult = MessageBox.Show("Etes-vous sur de vouloir supprimer la fonction #" + this.fctElectronique + " ?",
               "Suppression", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
            {
                this.critAssocieManager.supprimerCritAssocieByFonction(this.fctElectronique);
                this.ioPhysAssocieManager.supprimerIoPhystAssocieByFonction(this.fctElectronique);
                this.fctManager.supprimerFonction(this.fctElectronique);
                FenCrudFctElect.etat = state.ajouter;
                this.initialiserDonnees(FenCrudFctElect.etat);
            }
        }
        private void enregistrerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult;
            dialogResult = MessageBox.Show("Voulez-vous sauvegarder les modifications?",
               "Nouveau", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                this.enregistrer(FenCrudFctElect.etat);
            }
        }
        private void quitterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region Boutons main toolstrip
        private void buttonSave_Click(object sender, EventArgs e)
        {
            this.enregistrer(FenCrudFctElect.etat);

        }
        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void buttonValider_Click(object sender, EventArgs e)
        {
            if (this.fctElectronique.enAttente)
            {
                this.fctElectronique.enAttente = false;
                this.enregistrer(FenCrudFctElect.etat);
                this.comportementButtonValider();
            }
            else
            {
                this.fctElectronique.enAttente = true;
                this.enregistrer(FenCrudFctElect.etat);
                this.comportementButtonValider();
            }
        }
        #endregion

        
       
        private void openLienSvnTest_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("explorer.exe", @"" + textBoxLienSvnTest.Text + "");
        }

        #region Gestion projet et fonction
        private void addProjet_Click(object sender, EventArgs e)
        {
            ihmM.ajouterObj(IhmManager.metier.Projet);
            ihmM.raffraichirCombobox(IhmManager.metier.Projet, this.comboBoxProjet);
        }
        private void updateProjet_Click(object sender, EventArgs e)
        {
            ihmM.modifierObj(IhmManager.metier.Projet, this.comboBoxProjet.SelectedValue);
            ihmM.raffraichirCombobox(IhmManager.metier.Projet, this.comboBoxProjet);
        }
        private void deleteProjet_Click(object sender, EventArgs e)
        {
            ihmM.supprimerObj(IhmManager.metier.Projet, this.comboBoxProjet.SelectedValue);
            ihmM.raffraichirCombobox(IhmManager.metier.Projet, this.comboBoxProjet);
        }
        private void addFonction_Click(object sender, EventArgs e)
        {
            ihmM.ajouterObj(IhmManager.metier.FonctionGen);
            ihmM.raffraichirCombobox(IhmManager.metier.FonctionGen, this.comboBoxRubrique, this.comboBoxFonction);
        }
        private void updateFonction_Click(object sender, EventArgs e)
        {
            ihmM.modifierObj(IhmManager.metier.FonctionGen, this.comboBoxFonction.SelectedValue);
            ihmM.raffraichirCombobox(IhmManager.metier.FonctionGen, this.comboBoxRubrique, this.comboBoxFonction);
        }
        private void deleteFonction_Click(object sender, EventArgs e)
        {
            ihmM.supprimerObj(IhmManager.metier.FonctionGen, this.comboBoxFonction.SelectedValue);
            ihmM.raffraichirCombobox(IhmManager.metier.FonctionGen, this.comboBoxRubrique, this.comboBoxFonction);

        }
        private void comboBoxProjet_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (FenCrudFctElect.etat == state.ajouter)
            {
                IhmManager.projetSelect = (Projet)comboBoxProjet.SelectedValue;
                textBoxLienSvnTest.Text = IhmManager.projetSelect.lienSnvProjet;
            }
        }
        private void comboBoxRubrique_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxFonction.DataSource = IhmManager.listFctGen
                            .OrderBy(d => d.designation)
                            .Where(r => r.rubrique == comboBoxRubrique.SelectedValue.ToString())
                            .ToList();
        }
        private void comboBoxFonction_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                FonctionGenerique fg = (FonctionGenerique)this.comboBoxFonction.SelectedItem;
                this.toolTipFonction.SetToolTip(this.comboBoxFonction, fg.description);
            }
            catch
            { 
                
            }
        }

        #endregion        

        #region Gestion io et critère
        private void buttonAddCrit_Click(object sender, EventArgs e)
        {
            IhmManager.ajouterAssociation = true;
            FenCrudCritAssocie form = new FenCrudCritAssocie();
            form.ShowDialog();

            if (FenCrudCritAssocie.critAss.critere != null)
            {
                this.fctElectronique.ajouterCritere(FenCrudCritAssocie.critAss);
                this.listBoxCrit.DataSource = null;
                this.listBoxCrit.DataSource = this.fctElectronique.listCritere;
            }
        }
        private void buttonUpdateCrit_Click(object sender, EventArgs e)
        {
            IhmManager.ajouterAssociation = false;
            IhmManager.critAssSelect = (CritereAssociee)listBoxCrit.SelectedItem;

            if (IhmManager.critAssSelect != null)
            {
                FenCrudCritAssocie form = new FenCrudCritAssocie();
                form.ShowDialog();
                if (FenCrudCritAssocie.critAss.critere != null)
                {
                    this.fctElectronique.modifierCritere(FenCrudCritAssocie.critAss);
                    this.listBoxCrit.DataSource = null;
                    this.listBoxCrit.DataSource = this.fctElectronique.listCritere;
                }
            }
            else
            {
                MessageBox.Show("Veuillez d'abord selectionner un critère ! ");
            }

        }
        private void buttonDeleteCrit_Click(object sender, EventArgs e)
        {
            this.fctElectronique.supprimerCritere((CritereAssociee)listBoxCrit.SelectedItem);
            this.listBoxCrit.DataSource = null;
            this.listBoxCrit.DataSource = this.fctElectronique.listCritere;

        }

        private void buttonAddIo_Click(object sender, EventArgs e)
        {
            IhmManager.ajouterAssociation = true;
            FenCrudIoPhysAssocie form = new FenCrudIoPhysAssocie();
            form.ShowDialog();

            if (FenCrudIoPhysAssocie.ioPhystAss.ioPhysique != null)
            {
                this.fctElectronique.ajouterIoPhys(FenCrudIoPhysAssocie.ioPhystAss);
                this.listBoxIo.DataSource = null;
                this.listBoxIo.DataSource = this.fctElectronique.listIO;
            }

        }
        private void buttonUpdateIo_Click(object sender, EventArgs e)
        {
            IhmManager.ajouterAssociation = false;
            IhmManager.ioPhysAssSelect = (IoPhysiqueAssociee)this.listBoxIo.SelectedItem;

            if (IhmManager.ioPhysAssSelect != null)
            {
                FenCrudIoPhysAssocie form = new FenCrudIoPhysAssocie();
                form.ShowDialog();

                if (FenCrudIoPhysAssocie.ioPhystAss != null)
                {
                    this.fctElectronique.modifierIoPhys(FenCrudIoPhysAssocie.ioPhystAss);
                    this.listBoxIo.DataSource = null;
                    this.listBoxIo.DataSource = this.fctElectronique.listIO;
                }
            }
            else
            {
                MessageBox.Show("Veuillez d'abord selectionner un critère ! ");
            }

        }
        private void buttonDeleteIo_Click(object sender, EventArgs e)
        {
            this.fctElectronique.supprimerIoPhys((IoPhysiqueAssociee)this.listBoxIo.SelectedItem);
            this.listBoxIo.DataSource = null;
            this.listBoxIo.DataSource = this.fctElectronique.listIO;

        }
        #endregion

        #region Gestion du schéma
        private void buttonAddSchema_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialogSchema = new OpenFileDialog();
            openFileDialogSchema.Filter =
                "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png, *.bmp) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png; *.bmp";

            if (openFileDialogSchema.ShowDialog() == DialogResult.OK)
            {
                this.ihmM.chargerSchema(openFileDialogSchema.FileName, pictureBox1);
            }
        }
        #endregion

        #region TexteBoxFloat           
        private void textBoxCout_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            this.ihmM.texteBoxFloatConstraint(this.textBoxCout, e);
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.ihmM.texteBoxFloatConstraint(this.textBox3, e);
        }
        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.ihmM.texteBoxFloatConstraint(this.textBox4, e);
        }
        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.ihmM.texteBoxFloatConstraint(this.textBox5, e);
        }
        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.ihmM.texteBoxFloatConstraint(this.textBox6, e);
        }
        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.ihmM.texteBoxFloatConstraint(this.textBox7, e);
        }
        private void textBox8_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.ihmM.texteBoxFloatConstraint(this.textBox8, e);
        }
        private void textBox9_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.ihmM.texteBoxFloatConstraint(this.textBox9, e);
        }
        private void textBox10_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.ihmM.texteBoxFloatConstraint(this.textBox10, e);
        }
        #endregion

        private void buttonCaptureSchema_Click(object sender, EventArgs e)
        {                     
            CaptureEcran.FormControlePrintScreen.formMainCapture.ShowDialog();
            if (CaptureEcran.FormControlePrintScreen.imageOutput != null) 
            {
                this.ihmM.chargerSchema( CaptureEcran.FormControlePrintScreen.imageOutput, pictureBox1);   
            }            
            
        }

      
       

       
       

       
        























    }
}

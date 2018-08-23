using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BAL;
using BEL;


namespace IHM
{
    public partial class MainForm : Form
    {       
        //filtre
        public Boolean filtreVisible = true; 

        private IhmManager ihmM = new IhmManager();
        private FonctionManager fctManager = new FonctionManager();
        private FonctionElectronique fctPrivate = new FonctionElectronique();
        
        private CritereGenManager cgm = new CritereGenManager();

        private Size tailleImage = new Size();

        private Filtre filtre = new Filtre();
       

        public MainForm()
        {
            InitializeComponent();
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            this.chargerDonneesFiltre();
        }
        //Gestion du panel filtre cacher/montrer
        
        private void buttonFiltreShowHide_Click(object sender, EventArgs e)
        {
            switch (this.filtreVisible)
            {
                case false:
                    this.panelFiltre.Show();
                    this.buttonFiltreShowHideL.Text = "˄";
                    this.tableLayoutPanelMain.RowStyles[0].Height = 200F;
                    this.Refresh();
                    this.filtreVisible = true;
                    break;
                case true:
                    this.panelFiltre.Hide();
                    this.buttonFiltreShowHideL.Text = "˅";
                    this.tableLayoutPanelMain.RowStyles[0].Height = 32F;
                    this.filtreVisible = false;
                    break;
            }
        }
 
        #region CRUD Fct

        
        private void remplirTreeView(List<FonctionElectronique> listFct, int idFonction)
        {
            this.treeViewFonction.Nodes.Clear();


            if (idFonction == CritereRecherche.valeurParDefisNull)
            {
                var projets = listFct.GroupBy(prj => prj.projet.idProjet)
                        .Select(p => p.Key)
                        .ToList();
                foreach (var p in projets)
                {
                    int i = projets.IndexOf(p);
                    var rootNode = treeViewFonction.Nodes.Add(new TreeNode(p));
                    var fonctions = new List<FonctionElectronique>();
                    fonctions = listFct.Where(prj => prj.projet.idProjet == p).ToList();

                    foreach (FonctionElectronique f in fonctions)
                    {
                        TreeNode fonctionNode = new TreeNode(f.fonction.designation);
                        fonctionNode.Tag = f;
                        treeViewFonction.Nodes[i].Nodes.Add(fonctionNode);
                    }
                }
            } else
            {
                foreach (FonctionElectronique f in listFct)
                {
                    TreeNode fonctionNode = new TreeNode(f.taux + "% - " + f.projet.idProjet);
                    treeViewFonction.Nodes.Add(fonctionNode);
                    fonctionNode.Tag = f;
                }
 
            
            }
        }
        private void chargerFonction(FonctionElectronique fctElec)
        {
            this.labelTitre.Text = fctElec.ToString();
            this.labelResponsable.Text = "Crédit : " + fctElec.projet.personnel.getCredit();

            this.labelDate.Text = "Date : " + fctElec.projet.getDate();
            this.labelValidation.Text = (fctElec.validation) ? "Fonction validée !" : "Fonction non validée !";

            //voir les controle definie dans la region Controle picture box
            this.tailleImage = this.ihmM.chargerSchema(fctElec.schema, this.pictureBoxSchema);
            this.recentrerSchema();
            this.locationPictureBox();
            this.trackBarZoomSchema.Value = this.positionScrool();
            
            this.openSvnProjet.Tag = fctElec.projet.lienSnvProjet;
            this.openSvnFonction.Tag = fctElec.lienSVNTest;
            this.labelPlageTensionInput.Text = fctElec.getPlageTensionInput();
            this.labelPlageIntensitéInput.Text = fctElec.getPlageIntensiteInput();
            this.labelPlageTensionOutput.Text = fctElec.getPlageTensionOutput();
            this.labelPlageIntensitéOutput.Text = fctElec.getPlageIntensiteOutput();

            this.listBoxCritere.DataSource = fctElec.listCritere;
            this.listBoxIoPhysique.DataSource = fctElec.listIO;

            this.richTextBox1.Text = fctElec.description;

        }
        private void treeViewFonction_DoubleClick(object sender, EventArgs e)
        {
            object ob = null;
            if (this.treeViewFonction.SelectedNode != null)
            {
                ob = (this.treeViewFonction.SelectedNode.Tag != null) ? this.treeViewFonction.SelectedNode.Tag.GetType() : null;
            }
            if (ob != null)
            {
                this.fctPrivate = (FonctionElectronique)this.treeViewFonction.SelectedNode.Tag;
                this.chargerFonction(this.fctPrivate);
            }
        }
        //Ajouter une fonction
        private void buttonAddFonction_Click(object sender, EventArgs e)
        {
            FenCrudFctElect.etat = FenCrudFctElect.state.ajouter;
            FenCrudFctElect formCrudElec = new FenCrudFctElect();
            formCrudElec.ShowDialog();
        }
        private void buttonUpdateFonction_Click(object sender, EventArgs e)
        {            
            if (this.fctPrivate.projet != null)
            {
                FenCrudFctElect.etat = FenCrudFctElect.state.modifier;
                IhmManager.ajouterFonctionElect = false;
                IhmManager.fctElectSelect = this.fctPrivate;
                FenCrudFctElect formCrudElec = new FenCrudFctElect();
                formCrudElec.ShowDialog();
            }
        }
        private void buttonListAttenteValidation_Click(object sender, EventArgs e)
        {
            FenListeAttente formListeAttente = new FenListeAttente();
            formListeAttente.ShowDialog();
        }
        #endregion

        #region Controle lien SVN
        private void openSvnProjet_Click(object sender, EventArgs e)
        {
            if (this.openSvnProjet.Tag != null)
            System.Diagnostics.Process.Start("explorer.exe", @"" + this.openSvnProjet.Tag.ToString() + "");
        }
        private void openSvnFonction_Click(object sender, EventArgs e)
        {
            if (this.openSvnFonction.Tag != null)
            System.Diagnostics.Process.Start("explorer.exe", @"" + this.openSvnFonction.Tag.ToString() + "");
        }
        #endregion

        #region Controle picture box

        private Boolean deplacementImage = false;
        private Point positionDep = new Point();
        private Point positionSourisDep = new Point();

        //Cette fonction centre la picture box dans le panel lorsque celle ci est plus petite que le panel
        private void locationPictureBox() {
            
            int x, y;
            x = ((this.panelSchema.Size.Width - this.pictureBoxSchema.Size.Width)> 0) ? (this.panelSchema.Size.Width - this.pictureBoxSchema.Size.Width)/2 : 0;
            y = ((this.panelSchema.Size.Height - this.pictureBoxSchema.Size.Height) > 0) ? (this.panelSchema.Size.Height - this.pictureBoxSchema.Size.Height)/2 : 0;
            Point location = new Point(x,y);

            this.pictureBoxSchema.Location = location;       

        }
        //Cette fonction indique la valeur du zoom de l'image dans le pictureBox
        private int positionScrool() {
            float pourcentageTailleImageWidth;
            float pourcentageTailleImageHeight;
            if (tailleImage.Height > 0 & tailleImage.Width > 0)
            {
                pourcentageTailleImageWidth = (float)((float)this.pictureBoxSchema.Width / (float)this.tailleImage.Width) * 100F;
                pourcentageTailleImageHeight = (float)((float)this.pictureBoxSchema.Height / (float)this.tailleImage.Height) * 100F;
                return (int)Math.Min(pourcentageTailleImageWidth,pourcentageTailleImageHeight);
            }
            {
                return 100;
            }   
        }
        //cette fonction recentre la picture box dans le panel
        private void recentrerSchema() {

            this.pictureBoxSchema.Dock = DockStyle.Fill;
            this.pictureBoxSchema.SizeMode = PictureBoxSizeMode.Zoom;
            this.trackBarZoomSchema.Value = this.positionScrool();
            this.pictureBoxSchema.Size = new Size(tailleImage.Width * trackBarZoomSchema.Value / 100, tailleImage.Height * trackBarZoomSchema.Value / 100);
            this.pictureBoxSchema.Dock = DockStyle.None;
            this.pictureBoxSchema.SizeMode = PictureBoxSizeMode.StretchImage;
            this.locationPictureBox();
        }
        //On modifie la taille de la pitucte box à l'aide de l'evenement sroll du track bar
        private void trackBarZoomSchema_Scroll(object sender, EventArgs e)
        {
            this.pictureBoxSchema.Dock = DockStyle.None;
            this.pictureBoxSchema.SizeMode = PictureBoxSizeMode.StretchImage;
            this.pictureBoxSchema.Size = new Size(tailleImage.Width * trackBarZoomSchema.Value / 100, tailleImage.Height * trackBarZoomSchema.Value / 100);
            this.locationPictureBox();
        }
        
        private void pictureBoxSchema_MouseClick(object sender, MouseEventArgs e)
        {
            this.trackBarZoomSchema.Focus();
        }
        private void buttonRecentrerSchema_Click(object sender, EventArgs e)
        {
            this.recentrerSchema();
        }

        //*********************************************************************
        //Debut controle position de la picture box dans le panel
        //*********************************************************************
        private void pictureBoxSchema_MouseDown(object sender, MouseEventArgs e)
        {
            this.deplacementImage = true;
            this.pictureBoxSchema.Dock = DockStyle.None;
            this.pictureBoxSchema.SizeMode = PictureBoxSizeMode.StretchImage;           
         
            this.positionSourisDep = MainForm.MousePosition;
            this.positionDep.X = this.panelSchema.HorizontalScroll.Value;
            this.positionDep.Y = this.panelSchema.VerticalScroll.Value;
            this.pictureBoxSchema.Cursor = Cursors.NoMove2D;
        }
        private void pictureBoxSchema_MouseMove(object sender, MouseEventArgs e)
        {
            Point souris = new Point();
            souris = MainForm.MousePosition;
            int x, y;

            if (this.deplacementImage)
            {
                x = this.positionDep.X + souris.X - this.positionSourisDep.X;
                y = this.positionDep.Y + souris.Y - this.positionSourisDep.Y;

                if (x > this.panelSchema.HorizontalScroll.Minimum & x < this.panelSchema.HorizontalScroll.Maximum)
                {
                    this.panelSchema.HorizontalScroll.Value = x;
                }
                if (y > this.panelSchema.VerticalScroll.Minimum & y < this.panelSchema.VerticalScroll.Maximum)
                {
                    this.panelSchema.VerticalScroll.Value = y;
                }
            }
        }
        private void pictureBoxSchema_MouseUp(object sender, MouseEventArgs e)
        {
            this.deplacementImage = false;
            this.pictureBoxSchema.Cursor = Cursors.Default;
        }             
        //*********************************************************************
        //Fin controle position de la picture box dans le panel
        //*********************************************************************      
        #endregion

        #region Controle filtre
        private void chargerDonneesFiltre()
        {
            this.comboBoxRubrique.Items.Add("Tous");
            this.ihmM.raffraichirCombobox(IhmManager.metier.FonctionGen, comboBoxRubrique, comboBoxFonction);
        }


        private void ajouterCrit(Button b) {
            b.Dispose();

            this.buttonCrit1 = new Button();
            this.buttonCrit1.Anchor = AnchorStyles.Left;
            this.buttonCrit1.BackColor = System.Drawing.SystemColors.Menu;
            this.buttonCrit1.BackgroundImage = global::IHM.Properties.Resources.add;
            this.buttonCrit1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonCrit1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonCrit1.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.buttonCrit1.FlatAppearance.BorderSize = 0;
            this.buttonCrit1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCrit1.Location = new System.Drawing.Point(8, 0);
            this.buttonCrit1.Margin = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.buttonCrit1.Size = new System.Drawing.Size(25, 25);
            this.buttonCrit1.UseVisualStyleBackColor = false;
            
            List<CritereGenerique> listCrit;
            listCrit = new List<CritereGenerique>();
            listCrit = this.cgm.getListCriGen();          
            ControlCritere cc = new ControlCritere(listCrit);
            this.tableLayoutPanelCrit.Controls.Add(cc);
            this.tableLayoutPanelCrit.Controls.Add(this.buttonCrit1);

            this.buttonCrit1.Click += new System.EventHandler(this.buttonCrit1_Click);
        }

        private void buttonCrit1_Click(object sender, EventArgs e)        
        {
            this.ajouterCrit(this.buttonCrit1);
        }

        private void comboBoxRubrique_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxFonction.DataSource = IhmManager.listFctGen
                          .OrderBy(d => d.designation)
                          .Where(r => r.rubrique == comboBoxRubrique.SelectedValue.ToString())
                          .ToList();
        }


        
        private void toolStripButtonSearch_Click(object sender, EventArgs e)
        {
            this.filtre.fonction = (FonctionGenerique)this.comboBoxFonction.SelectedValue;

            this.filtre.validation = (this.radioButtonVTous.Checked) ? -1 : ((this.radioButtonVnon.Checked) ? 0 : 1);

            this.filtre.tensionInMin = (this.textBox1.Text != "") ? float.Parse(textBox1.Text.Replace(".", ",")) : CritereRecherche.valeurParDefisNull;
            this.filtre.tensionInMax = (this.textBox2.Text != "") ? float.Parse(textBox2.Text.Replace(".", ",")) : CritereRecherche.valeurParDefisNull;
            this.filtre.intensiteInMin = (this.textBox3.Text != "") ? float.Parse(textBox3.Text.Replace(".", ",")) : CritereRecherche.valeurParDefisNull;
            this.filtre.intensiteInMax = (this.textBox4.Text != "") ? float.Parse(textBox4.Text.Replace(".", ",")) : CritereRecherche.valeurParDefisNull;

            this.filtre.tensionOutMin = (this.textBox5.Text != "") ? float.Parse(textBox5.Text.Replace(".", ",")) : CritereRecherche.valeurParDefisNull;
            this.filtre.tensionOutMax = (this.textBox6.Text != "") ? float.Parse(textBox6.Text.Replace(".", ",")) : CritereRecherche.valeurParDefisNull;
            this.filtre.intensiteOutMin = (this.textBox7.Text != "") ? float.Parse(textBox7.Text.Replace(".", ",")) : CritereRecherche.valeurParDefisNull;
            this.filtre.intensiteOutMax = (this.textBox8.Text != "") ? float.Parse(textBox8.Text.Replace(".", ",")) : CritereRecherche.valeurParDefisNull;


            //Construction du tableau de critere de recherche
            List<CritereRecherche> listCrit = new List<CritereRecherche>();
            foreach (ControlCritere cc in this.tableLayoutPanelCrit.Controls.OfType<ControlCritere>())
            {
                listCrit.Add(cc.getCritere());
            }
            this.filtre.setCritere(listCrit);


            IhmManager.listFctElct = this.fctManager.getListFonction(this.filtre);
            this.remplirTreeView(IhmManager.listFctElct, this.filtre.fonction.idFonction);

            this.toolTipFiltre.SetToolTip(this.toolStrip2, this.filtre.ToString());
            this.toolTipFiltre.SetToolTip(this.groupBoxFiltre, this.filtre.ToString());
 
        }
        private void reinitialiserFiltre() 
        {
            foreach (ControlCritere cc in this.tableLayoutPanelCrit.Controls.OfType<ControlCritere>().Reverse())
            {
                cc.Dispose();
            }

            foreach (TextBox tb in tableLayoutPanelDataInput.Controls.OfType<TextBox>()) 
            {
                tb.Text="";
            }    
        
        }

        #endregion

        private void toolStripButtonRefresh_Click(object sender, EventArgs e)
        {
            this.reinitialiserFiltre();
        }

      

       
     
       
       
        
      
        
       
        
       

       
       
    

      
       




















    }
}

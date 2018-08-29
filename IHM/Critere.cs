﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BEL;
using System.Windows.Forms;


namespace IHM
{
    public class ControlCritere: Panel
    {
     
        private TableLayoutPanel tableLayoutPanelMain;
        private TableLayoutPanel tableLayoutPanelCrit;
        private Button button;
        private Panel panelCrit;
        private ComboBox comboBoxCrit, comboBoxSign;
        private TextBox texBoxCrit;
        private Label labelUnite; 
        private List<Signe> listSigne;
        private IhmManager ihmM = new IhmManager();
        private IhmManager.typeFiltre tfi;
         


        public ControlCritere( IhmManager.typeFiltre tf, List<CritereGenerique> listC, List<IoPhysiqueGenerique> listIo)
        {
            this.Dock = DockStyle.Fill;

            this.tfi = tf;

            Signe inferieur = new Signe("≤", -1);
            Signe egal = new Signe("=", 0);
            Signe superieur = new Signe("≥", 1);
            this.listSigne = new List<Signe>();
            this.listSigne.Add(inferieur);
            this.listSigne.Add(egal);
            this.listSigne.Add(superieur);
            
            
            
            //Constrution du tableLayout main
            this.tableLayoutPanelMain = new TableLayoutPanel();
            this.tableLayoutPanelMain.ColumnCount = 2;
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            
            this.tableLayoutPanelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelMain.Location = new System.Drawing.Point(5, 5);
            this.tableLayoutPanelMain.Margin = new System.Windows.Forms.Padding(5);
            this.tableLayoutPanelMain.Name = "tableLayoutPanelCrit1";
            this.tableLayoutPanelMain.RowCount = 1;
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 41F));
            this.tableLayoutPanelMain.Size = new System.Drawing.Size(302, 41);
            this.tableLayoutPanelMain.TabIndex = 0;
          

            //Construction du bouton ajouter ou supprimer
            this.button = new Button();
            this.button.Anchor = AnchorStyles.Left;
            this.button.BackColor = System.Drawing.SystemColors.Menu;
            this.button.BackgroundImage = global::IHM.Properties.Resources.delete;
            this.button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button.FlatAppearance.BorderSize = 0;
            this.button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button.Location = new System.Drawing.Point(8, 0);
            this.button.Margin = new System.Windows.Forms.Padding(8, 0, 0, 0);                  
            this.button.Size = new System.Drawing.Size(25, 25);            
            this.button.UseVisualStyleBackColor = false;
            this.button.Click += new System.EventHandler(this.button_Click);

            //Construction du premier panel 
            this.panelCrit = new Panel();
            this.panelCrit.BackColor = System.Drawing.SystemColors.ControlLight;            
            this.panelCrit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCrit.Location = new System.Drawing.Point(43, 3);
            this.panelCrit.Name = "panelCrit1";
            this.panelCrit.Size = new System.Drawing.Size(256, 35);

            // Ajouter panel et le boutton au tlpanelmain
            this.tableLayoutPanelMain.Controls.Add(this.button, 0, 0);
            this.tableLayoutPanelMain.Controls.Add(this.panelCrit, 1, 0);

            //Contruction du tableLayoutPanelCrit
            this.tableLayoutPanelCrit = new TableLayoutPanel();
            this.tableLayoutPanelCrit.ColumnCount = 4;
            this.tableLayoutPanelCrit.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanelCrit.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanelCrit.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanelCrit.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));         
            this.tableLayoutPanelCrit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelCrit.Location = new System.Drawing.Point(0, 0);            
            this.tableLayoutPanelCrit.RowCount = 1;
            this.tableLayoutPanelCrit.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelCrit.Size = new System.Drawing.Size(256, 35);
            this.tableLayoutPanelCrit.TabIndex = 0;

            //Label unite
            this.labelUnite = new Label();
            this.labelUnite.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelUnite.AutoSize = true;
            this.labelUnite.Location = new System.Drawing.Point(3, 16);
            this.labelUnite.Size = new System.Drawing.Size(59, 13);
         

            //Combobox crit
            this.comboBoxCrit = new ComboBox();
            this.comboBoxCrit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxCrit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCrit.FormattingEnabled = true;
            this.comboBoxCrit.Location = new System.Drawing.Point(3, 7);          
            this.comboBoxCrit.Size = new System.Drawing.Size(137, 21);
            this.comboBoxCrit.TabIndex = 0;
            this.comboBoxCrit.SelectedIndexChanged += new System.EventHandler(this.comboBoxCrit_SelectedIndexChanged);

          
            switch (tf) 
            { 
                case IhmManager.typeFiltre.critere:                  
                    this.comboBoxCrit.DataSource = listC;
                    CritereGenerique cg = (CritereGenerique)listC[0];
                    this.labelUnite.Text = cg.unite;
                  
                    break;
                case IhmManager.typeFiltre.iophys:
                    this.labelUnite.Text = "Qte";
                    this.comboBoxCrit.DataSource = listIo;
                    break;
            }
           

            //Combobox signe
            this.comboBoxSign = new ComboBox();
            this.comboBoxSign.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxSign.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSign.FormattingEnabled = true;
            this.comboBoxSign.Location = new System.Drawing.Point(143, 7);
            this.comboBoxSign.Margin = new System.Windows.Forms.Padding(0);           
            this.comboBoxSign.Size = new System.Drawing.Size(35, 21);
            this.comboBoxSign.DataSource = this.listSigne;
 

            //Textbox crit
            this.texBoxCrit = new TextBox();
            this.texBoxCrit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.texBoxCrit.Location = new System.Drawing.Point(181, 7);            
            this.texBoxCrit.Size = new System.Drawing.Size(72, 20);
            this.texBoxCrit.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.texBoxCrit_KeyPress);
            
           

            //Ajouter les tb et cb dans le tb           
            this.tableLayoutPanelCrit.Controls.Add(this.comboBoxCrit, 0, 0);
            this.tableLayoutPanelCrit.Controls.Add(this.comboBoxSign, 1, 0);
            this.tableLayoutPanelCrit.Controls.Add(this.texBoxCrit, 2, 0);
            this.tableLayoutPanelCrit.Controls.Add(this.labelUnite, 3, 0);
         
            this.panelCrit.Controls.Add(this.tableLayoutPanelCrit); 
            this.Controls.Add(this.tableLayoutPanelMain);
        }
        private void texBoxCrit_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.ihmM.texteBoxFloatConstraint(this.texBoxCrit, e);
        }


        private void button_Click(object sender, EventArgs e)
        {  
            this.Dispose();  
        }

        private void comboBoxCrit_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            switch (this.tfi)
            {
                case IhmManager.typeFiltre.critere:
                    CritereGenerique cg = (CritereGenerique)this.comboBoxCrit.SelectedItem;
                    this.labelUnite.Text = cg.unite;
                    break;
                case IhmManager.typeFiltre.iophys:
                    this.labelUnite.Text = "Qte";
                    break;
            }    
        }



        public CritereRecherche getCritere() 
        {
            float valeurCrit;

            valeurCrit = (this.texBoxCrit.Text != "") ? float.Parse(texBoxCrit.Text.Replace(".", ",")) : CritereRecherche.valeurParDefisNull;
            //CritereRecherche c22 = new CritereRecherche();
            CritereRecherche cr = new CritereRecherche((CritereGenerique)this.comboBoxCrit.SelectedValue,
                (Signe)this.comboBoxSign.SelectedValue, valeurCrit);
            return cr;
        }

        public IoRecherche getIo()
        {
            int valeurIo;

            valeurIo = (this.texBoxCrit.Text != "") ? int.Parse(texBoxCrit.Text.Replace(".", ",")) : CritereRecherche.valeurParDefisNull;
            //IoRecherche io22 = new IoRecherche();
            IoRecherche ior = new IoRecherche((IoPhysiqueGenerique)this.comboBoxCrit.SelectedValue,
                (Signe)this.comboBoxSign.SelectedValue, valeurIo);
            return ior;
        }


    }


}



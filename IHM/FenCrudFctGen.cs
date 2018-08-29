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


namespace IHM
{
    public partial class FenCrudFctGen : Form
    {
        private FonctionGenManager fgm = new FonctionGenManager();       

        public FenCrudFctGen()
        {
            InitializeComponent();
        }      

        private void button1_Click(object sender, EventArgs e)
        {
            FonctionGenerique fg = new FonctionGenerique();
            fg.designation = this.textBox1.Text;
            fg.rubrique = this.comboBox1.Text;
            fg.description = this.richTextBox1.Text;

            if (IhmManager.ajouter)
            {
                int nbligne = fgm.ajouterFonctionGen(fg);
                if (nbligne > 0){
                    MessageBox.Show("Ajout effectué avec succès !");                    
                    this.Close();
                };
            }
            else 
            {               
                fg.idFonction = IhmManager.fctGenSelect.idFonction;
                int nbligne = fgm.modifierFctGen(fg);
                if (nbligne > 0)
                {
                    MessageBox.Show("Modifcation effectuée avec succès !");                    
                    this.Close();
                };
            }
        }

        private void FenCrudFctGen_Load(object sender, EventArgs e)
        {
            var rubrique = IhmManager.listFctGen
                  .Where(i => i.idFonction !=-9999)
                 .GroupBy(r => r.rubrique)               
                 .Select(ru => ru.Key)
                 .ToList();
            comboBox1.DataSource = rubrique;
            this.button1.Text = "Ajouter";

            if (!IhmManager.ajouter)
            {
                this.button1.Text = "Modifier";
                comboBox1.SelectedItem = IhmManager.fctGenSelect.rubrique;
                textBox1.Text = IhmManager.fctGenSelect.designation;
                richTextBox1.Text = IhmManager.fctGenSelect.description;
            }
        
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

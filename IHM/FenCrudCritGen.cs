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
    public partial class FenCrudCritGen : Form
    {
        private CritereGenManager cgm = new CritereGenManager();   

        public FenCrudCritGen()
        {
            InitializeComponent();
        }       

        private void FenCrudCritGen_Load(object sender, EventArgs e)
        {
            this.button1.Text = "Ajouter";

            if (!IhmManager.ajouter)
            {
                this.button1.Text = "Modifier";
                textBox1.Text = IhmManager.critGenSelect.designation;
                textBox2.Text = IhmManager.critGenSelect.unite;
                if (IhmManager.critGenSelect.donneeChiffree)
                {
                    rbchiffre.Checked = true;
                }
                else 
                {
                    rbnombre.Checked = true;
                }

                richTextBox1.Text = IhmManager.critGenSelect.description;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CritereGenerique cg = new CritereGenerique();
            cg.designation = this.textBox1.Text;
            cg.unite = this.textBox2.Text;
            if (rbchiffre.Checked)
            {
                cg.donneeChiffree=true;
            }else
            {
                cg.donneeChiffree=false;
            }           
            cg.description = this.richTextBox1.Text;


            if (IhmManager.ajouter)
            {
                int nbligne = cgm.ajouterCritGen(cg);
                if (nbligne > 0)
                {
                    MessageBox.Show("Ajout effectué avec succès !");
                    this.Close();
                };
            }
            else
            {
                cg.idCritere = IhmManager.critGenSelect.idCritere;
                int nbligne = cgm.modifierCritGen(cg);
                if (nbligne > 0)
                {
                    MessageBox.Show("Modifcation effectuée avec succès !");
                    this.Close();
                };
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

      
    }
}

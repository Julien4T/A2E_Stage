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
    public partial class FenCrudIoPhysiqueGen : Form
    {
        private IoPhysiqueGenManager iopgm = new IoPhysiqueGenManager();   
    
        public FenCrudIoPhysiqueGen()
        {
            InitializeComponent();
        }

        private void FenCrudIoPhysiqueGen_Load(object sender, EventArgs e)
        {
            this.button1.Text = "Ajouter";

            if (!IhmManager.ajouter)
            {
                this.button1.Text = "Modifier";
                textBox1.Text = IhmManager.ioPhysGenSelect.designation;
                richTextBox1.Text = IhmManager.ioPhysGenSelect.description;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            IoPhysiqueGenerique iopg = new IoPhysiqueGenerique();
            iopg.designation = this.textBox1.Text;
            iopg.description = this.richTextBox1.Text;

            if (IhmManager.ajouter)
            {
                int nbligne = iopgm.ajouterIoPhysiqueGen(iopg);
                if (nbligne > 0)
                {
                    MessageBox.Show("Ajout effectué avec succès !");
                    this.Close();
                };
            }
            else
            {
                iopg.idIophysique = IhmManager.ioPhysGenSelect.idIophysique;
                int nbligne = iopgm.modifierIoPhysiqueGen(iopg);
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

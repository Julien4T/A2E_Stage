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
    public partial class FenCrudPersonnel : Form
    {
        private PersonnelManager persManager = new PersonnelManager();

        public FenCrudPersonnel()
        {
            InitializeComponent();
        }
        private void FenCrudPersonnel_Load(object sender, EventArgs e)
        {          
            this.buttonAddUpdate.Text = "Ajouter";

            if (!IhmManager.ajouter)
            {
                this.buttonAddUpdate.Text = "Modifier";
                textBox1.Text = IhmManager.persSelect.prenom;
                textBox2.Text = IhmManager.persSelect.nom;
                textBox3.Text = IhmManager.persSelect.mail; 
            }
        }
        private void buttonAddUpdate_Click(object sender, EventArgs e)
        {
            Personnel pers = new Personnel();

            pers.prenom =   textBox1.Text;
            pers.nom =      textBox2.Text;
            pers.mail =     textBox3.Text;

            if (IhmManager.ajouter)
            {
                int nbligne = persManager.ajouterPersonne(pers);
                if (nbligne > 0)
                {
                    MessageBox.Show("Ajout effectué avec succès !");
                    this.Close();
                };
            }
            else
            {
                pers.idPersonnel= IhmManager.persSelect.idPersonnel;
                int nbligne = persManager.modifierPersonne(pers);
                if (nbligne > 0)
                {
                    MessageBox.Show("Modifcation effectuée avec succès !");
                    this.Close();
                };
            }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        }

}


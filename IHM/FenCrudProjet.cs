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
    public partial class FenCrudProjet : Form
    {
        private PersonnelManager persManager = new PersonnelManager();
        private ProjetManager projetManager = new ProjetManager();
        private IhmManager ihmM = new IhmManager();

        public FenCrudProjet()
        {
            InitializeComponent();
        }
        private void FenCrudProjet_Load(object sender, EventArgs e)
        {
            ihmM.raffraichirCombobox(IhmManager.metier.Personnel,comboBox1);
            this.buttonAddUpdate.Text = "Ajouter";

            if (!IhmManager.ajouter)
            {
                this.buttonAddUpdate.Text = "Modifier";
                textBox1.Text = IhmManager.projetSelect.idProjet;
                textBox2.Text = IhmManager.projetSelect.lienSnvProjet;
                dateTimePicker1.Value = IhmManager.projetSelect.dateProjet;
                this.comboBox1.Text = persManager.getPersonneById(IhmManager.projetSelect.personnel.idPersonnel).ToString();

              
            }
        }

    

        private void buttonAddUpdate_Click(object sender, EventArgs e)
        {
            Projet pj = new Projet();
            string nomP = IhmManager.projetSelect.idProjet;

            pj.idProjet = textBox1.Text;
            pj.dateProjet = dateTimePicker1.Value;
           
            pj.lienSnvProjet = textBox2.Text;
            IhmManager.persSelect = (Personnel)comboBox1.SelectedValue;
            pj.personnel = IhmManager.persSelect;
          

            if (IhmManager.ajouter)
            {
                int nbligne = projetManager.ajouterProjet(pj);
                if (nbligne > 0)
                {
                    MessageBox.Show("Ajout effectué avec succès !");
                    this.Close();
                };
            }
            else
            {                
                int nbligne = projetManager.modifierProjetByNom(pj,nomP);
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

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void deletePersonnel_Click(object sender, EventArgs e)
        {
            ihmM.supprimerObj(IhmManager.metier.Personnel, this.comboBox1.SelectedValue);
            ihmM.raffraichirCombobox(IhmManager.metier.Personnel, this.comboBox1);
        }

        private void updatePersonnel_Click(object sender, EventArgs e)
        {
            ihmM.modifierObj(IhmManager.metier.Personnel, this.comboBox1.SelectedValue);
            ihmM.raffraichirCombobox(IhmManager.metier.Personnel, this.comboBox1);
        }

        private void addPersonnel_Click(object sender, EventArgs e)
        {
            ihmM.ajouterObj(IhmManager.metier.Personnel);
            ihmM.raffraichirCombobox(IhmManager.metier.Personnel, this.comboBox1);

        }

      

       

       

       
    }
}

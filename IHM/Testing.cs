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
    public partial class Testing : Form
    {
        private IhmManager ihmM = new IhmManager();
        private FonctionGenManager fgm = new FonctionGenManager();
        private CritereGenManager cgm = new CritereGenManager();
        private IoPhysiqueGenManager iopgm = new IoPhysiqueGenManager();
        private ProjetManager pjm = new ProjetManager();

        public Testing()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            ihmM.raffraichirCombobox(IhmManager.metier.FonctionGen,comboBox2, comboBox3);
            ihmM.raffraichirCombobox(IhmManager.metier.CritGen,this.comboBox4);
            ihmM.raffraichirCombobox(IhmManager.metier.IoPhysGen,this.comboBox5);
            ihmM.raffraichirCombobox(IhmManager.metier.Projet,this.comboBox6);
        }
    

        private void button1_Click(object sender, EventArgs e)
        {
            IhmManager.pers.nom = textBox1.Text;
            IhmManager.pers.prenom = textBox2.Text;
            IhmManager.pers.mail = textBox3.Text;
            //IhmManager.persoManager.ajouterPersonne(IhmManager.pers);
            IhmManager.listPers.Add(IhmManager.pers);
            comboBox1.Refresh();          
            
        }

        private void bsPersonnel_ListChanged(object sender, ListChangedEventArgs e)
        {
           
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

            //IhmManager.listFctElct = IhmManager.fctmanger.getListFonction();
            //dataGridView1.DataSource = IhmManager.listFctElct;
        
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

          
                
            
            //MessageBox.Show(dataGridView1.CurrentCell.Value.GetType().ToString());

        }

        private void button5_Click(object sender, EventArgs e)
        {
          
            
        }

      
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox3.DataSource = IhmManager.listFctGen
                              .OrderBy(d => d.designation)
                              .Where(r => r.rubrique == comboBox2.SelectedValue.ToString())
                              .ToList();
        }

        private void AjouterFctGen_Click(object sender, EventArgs e)
        {
            ihmM.ajouterObj(IhmManager.metier.FonctionGen);
            ihmM.raffraichirCombobox(IhmManager.metier.FonctionGen, this.comboBox2, this.comboBox3);          
        }

        private void button9_Click(object sender, EventArgs e)
        {
            
            IhmManager.fctGenSelect = (FonctionGenerique)this.comboBox3.SelectedValue;

            DialogResult dialogResult = MessageBox.Show(Program.mainForm, "Etes-vous sur de vouloir supprimer la fonction #" + IhmManager.fctGenSelect + " ?", 
                "Suppression", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (dialogResult == DialogResult.Yes)
            {
                //do something
                this.fgm.supprimerFctGen(IhmManager.fctGenSelect);
                ihmM.raffraichirCombobox(IhmManager.metier.FonctionGen, this.comboBox2, this.comboBox3);            
              
            }
            else if (dialogResult == DialogResult.No)
            {
                //do something else
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            ihmM.modifierObj(IhmManager.metier.FonctionGen, comboBox3.SelectedValue);
            ihmM.raffraichirCombobox(IhmManager.metier.FonctionGen, this.comboBox2, this.comboBox3);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            ihmM.ajouterObj(IhmManager.metier.CritGen);
            ihmM.raffraichirCombobox(IhmManager.metier.CritGen, this.comboBox4);
            
        }

        private void button10_Click(object sender, EventArgs e)
        {
            ihmM.modifierObj(IhmManager.metier.CritGen, comboBox4.SelectedValue);
            ihmM.raffraichirCombobox(IhmManager.metier.CritGen, this.comboBox4);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            ihmM.supprimerObj(IhmManager.metier.CritGen, comboBox4.SelectedValue);
            ihmM.raffraichirCombobox(IhmManager.metier.CritGen, this.comboBox4);
           
        }

        private void button14_Click(object sender, EventArgs e)
        {
            ihmM.ajouterObj(IhmManager.metier.IoPhysGen);
            ihmM.raffraichirCombobox(IhmManager.metier.IoPhysGen, this.comboBox5);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            ihmM.modifierObj(IhmManager.metier.IoPhysGen, comboBox5.SelectedValue);
            ihmM.raffraichirCombobox(IhmManager.metier.IoPhysGen, this.comboBox5);
        }

        private void button12_Click(object sender, EventArgs e)
        {

            ihmM.supprimerObj(IhmManager.metier.IoPhysGen, comboBox5.SelectedValue);
            ihmM.raffraichirCombobox(IhmManager.metier.IoPhysGen,this.comboBox5);
        }

        private void addProjet_Click(object sender, EventArgs e)
        {
            ihmM.ajouterObj(IhmManager.metier.Projet);
            ihmM.raffraichirCombobox(IhmManager.metier.Projet, this.comboBox6);
        }

        private void updateProjet_Click(object sender, EventArgs e)
        {
            ihmM.modifierObj(IhmManager.metier.Projet, this.comboBox6.SelectedValue);
            ihmM.raffraichirCombobox(IhmManager.metier.Projet, this.comboBox6);
        }

        private void deleteProjet_Click(object sender, EventArgs e)
        {
            ihmM.supprimerObj(IhmManager.metier.Projet, this.comboBox6.SelectedValue);
            ihmM.raffraichirCombobox(IhmManager.metier.Projet, this.comboBox6);

           
        }

     

  
    }
}

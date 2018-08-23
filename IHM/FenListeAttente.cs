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
    public partial class FenListeAttente : Form
    {
        private FonctionManager fctManager = new FonctionManager();
     

        public FenListeAttente()
        {
            InitializeComponent();
        }

        private void FenListeAttente_Load(object sender, EventArgs e)
        {

            IhmManager.listFctElct = this.fctManager.getListFonction("en_attente=true");
            this.listBox1.DataSource =  IhmManager.listFctElct ;

         

        }

        private void buttonQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonVoir_Click(object sender, EventArgs e)
        {
            if (this.listBox1.SelectedItem!=null && this.listBox1.SelectedItem.GetType() == IhmManager.fctElectSelect.GetType())
            {
                FenCrudFctElect.etat = FenCrudFctElect.state.modifier;
                IhmManager.ajouterFonctionElect = false;
                IhmManager.fctElectSelect = (FonctionElectronique )this.listBox1.SelectedItem;
                FenCrudFctElect formCrudElec = new FenCrudFctElect();
                formCrudElec.ShowDialog();
                IhmManager.listFctElct = this.fctManager.getListFonction("en_attente=true");
                this.listBox1.DataSource = IhmManager.listFctElct;            
            } 
            
            
           
        }

      
    }
}

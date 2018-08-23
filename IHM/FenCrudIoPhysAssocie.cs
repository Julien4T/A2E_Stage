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
    public partial class FenCrudIoPhysAssocie : Form
    {

        private IoPhysiqueGenManager iogm = new IoPhysiqueGenManager();      
        private IhmManager ihmM = new IhmManager();
        public static IoPhysiqueAssociee ioPhystAss = new IoPhysiqueAssociee();

        public FenCrudIoPhysAssocie()
        {
            InitializeComponent();
        }
        private IoPhysiqueAssociee creerIoPhysAss()
        {
            IoPhysiqueAssociee ioa = new IoPhysiqueAssociee();
            IhmManager.ioPhysGenSelect = (IoPhysiqueGenerique)this.cbIoGen.SelectedValue;
            ioa.ioPhysique = IhmManager.ioPhysGenSelect;
            ioa.quantite     = (textBoxValeur.Text != "") ? int.Parse(textBoxValeur.Text) : 0;        
          
            return ioa;

        }

        private void FenCrudIoPhysAssocie_Load(object sender, EventArgs e)
        {
            IhmManager.listIoPhysGen = iogm.getListIoPhysiqueGen();
            this.cbIoGen.DataSource = IhmManager.listIoPhysGen;
            this.buttonAssocier.Text = "Ajouter";

            if (!IhmManager.ajouterAssociation)
            {
                this.buttonAssocier.Text = "Modifier";
                this.cbIoGen.Text = IhmManager.ioPhysAssSelect.ioPhysique.designation;
                this.cbIoGen.Enabled = false;
                this.textBoxValeur.Text = IhmManager.ioPhysAssSelect.quantite.ToString();

            }
        }

        private void addIoGen_Click(object sender, EventArgs e)
        {
            this.ihmM.ajouterObj(IhmManager.metier.IoPhysGen);
            this.ihmM.raffraichirCombobox(IhmManager.metier.IoPhysGen, this.cbIoGen);
        }

        private void updateIoGen_Click(object sender, EventArgs e)
        {
            this.ihmM.modifierObj(IhmManager.metier.IoPhysGen, this.cbIoGen.SelectedValue);
            this.ihmM.raffraichirCombobox(IhmManager.metier.IoPhysGen, this.cbIoGen);
        }

        private void deleteIoGen_Click(object sender, EventArgs e)
        {
            this.ihmM.supprimerObj(IhmManager.metier.IoPhysGen, this.cbIoGen.SelectedValue);
            this.ihmM.raffraichirCombobox(IhmManager.metier.IoPhysGen, this.cbIoGen);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonAssocier_Click(object sender, EventArgs e)
        {
            FenCrudIoPhysAssocie.ioPhystAss = this.creerIoPhysAss();
            this.Close();
        }

        private void textBoxValeur_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.ihmM.texteBoxIntConstraint(this.textBoxValeur, e);
        }

        private void cbIoGen_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                IoPhysiqueGenerique io = (IoPhysiqueGenerique)this.cbIoGen.SelectedItem;
                this.toolTipIoPhys.SetToolTip(this.cbIoGen, io.description);
            }
            catch
            {

            }
        }
    }
}

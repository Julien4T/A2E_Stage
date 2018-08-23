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
    public partial class FenCrudCritAssocie : Form
    {
        private CritereGenManager cgm = new CritereGenManager();
        //private CritereAssociee ca = new CritereAssociee();
        private IhmManager ihmM = new IhmManager();
        public static CritereAssociee critAss = new CritereAssociee();     

        public FenCrudCritAssocie()
        {
            InitializeComponent();
        }

        private void FenCrudCritAssocie_Load(object sender, EventArgs e)
        {
            IhmManager.listCritGen = cgm.getListCriGen();
            this.cbCritere.DataSource = IhmManager.listCritGen;
            this.buttonAssocier.Text = "Ajouter";

            if (!IhmManager.ajouterAssociation) 
            {
                this.buttonAssocier.Text = "Modifier";
                this.cbCritere.Text = IhmManager.critAssSelect.critere.designation;
                this.cbCritere.Enabled = false;
                this.textBoxValeur.Text = IhmManager.critAssSelect.valeurTexte + IhmManager.critAssSelect.valeurNbr;               
            }
        }

        private void cbCritere_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                IhmManager.critGenSelect = (CritereGenerique)cbCritere.SelectedValue;
                this.labelUnite.Text = IhmManager.critGenSelect.unite;
                this.toolTipCritere.SetToolTip(this.cbCritere, IhmManager.critGenSelect.description);
            }
            catch
            {

            }
        }

        private void addCrit_Click(object sender, EventArgs e)
        {
            ihmM.ajouterObj(IhmManager.metier.CritGen);
            ihmM.raffraichirCombobox(IhmManager.metier.CritGen, this.cbCritere);
        }

        private void updateCrit_Click(object sender, EventArgs e)
        {
            ihmM.modifierObj(IhmManager.metier.CritGen, this.cbCritere.SelectedValue);
            ihmM.raffraichirCombobox(IhmManager.metier.CritGen, this.cbCritere);
        }

        private void deleteCrit_Click(object sender, EventArgs e)
        {
            ihmM.supprimerObj(IhmManager.metier.CritGen, this.cbCritere.SelectedValue);
            ihmM.raffraichirCombobox(IhmManager.metier.CritGen, this.cbCritere);

        }

        private void buttonAssocier_Click(object sender, EventArgs e)
        {
            FenCrudCritAssocie.critAss = this.creerCritereAss();
            this.Close();

        }
        private CritereAssociee creerCritereAss() 
        {
            CritereAssociee crit = new CritereAssociee();
            IhmManager.critGenSelect = (CritereGenerique)cbCritere.SelectedValue;
            crit.critere = IhmManager.critGenSelect;

            if (IhmManager.critGenSelect.donneeChiffree)
            {
                crit.valeurNbr = (this.textBoxValeur.Text!="")? this.textBoxValeur.Text : "0" ;
                crit.valeurTexte = null;
            }
            else
            {
                crit.valeurNbr = null;
                crit.valeurTexte = textBoxValeur.Text;
            }            
            return crit;
        }

        private void textBoxValeur_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (IhmManager.critGenSelect.donneeChiffree)
            {
                this.ihmM.texteBoxFloatConstraint(this.textBoxValeur, e);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

      
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Imaging;

namespace CaptureEcran
{
    public partial class FormControlePrintScreen : Form
    {
        public static FormControlePrintScreen formMainCapture = new FormControlePrintScreen();
        public static Bitmap imprimeEcran;
        public enum etat{initial, fonctionnement}; //initiale pour la première ouverture, fontionnement pour clic nouveau

        private enum modeImage { stretch, center, zoom };
        private modeImage etatModeImage;

        public static Bitmap imageOutput;

        public FormControlePrintScreen()
        {
            InitializeComponent();
        }
        public static void chargerImage(etat e,FormControlePrintScreen form)
        {
            switch (e) 
            { 
                case etat.initial:
                    form.Hide();
                    System.Threading.Thread.Sleep(250);
                    FormWindowScreen formWS = new FormWindowScreen();
                    formWS.ShowDialog();
                    break;
                case etat.fonctionnement:
                    using (MemoryStream s = new MemoryStream())
                    {
                        try
                        {
                            //save graphic variable into memory
                            FormControlePrintScreen.imprimeEcran.Save(s, ImageFormat.Bmp);
                            form.pictureBoxMain.Size = new System.Drawing.Size(form.Width, form.Height);
                            //set the picture box with temporary stream
                            form.pictureBoxMain.Image = Image.FromStream(s);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.GetType().ToString());
                        }
                        finally
                        {
                        }
                    }
                    break;
            }
        
        }

        private void FormControlePrintScreen_Load(object sender, EventArgs e)
        {
            this.etatModeImage = modeImage.center;
            this.buttonMode.Text = "Zoomer";
            FormControlePrintScreen.chargerImage(etat.initial, this);
            this.Focus();
        }

        private void buttonNew_Click(object sender, EventArgs e)
        {
            this.Hide();
            System.Threading.Thread.Sleep(250);
            FormWindowScreen formWS = new FormWindowScreen();
            formWS.ShowDialog();
            
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {

            if ((Bitmap)this.pictureBoxMain.Image != null)
            {
                FormControlePrintScreen.imageOutput = (Bitmap)this.pictureBoxMain.Image;
                this.Close();
            }
        }

        private void buttonMode_Click(object sender, EventArgs e)
        {
            switch (this.etatModeImage)
            {
                case modeImage.stretch:
                    this.pictureBoxMain.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                    this.buttonMode.Text = "Zoomer";
                    this.pictureBoxMain.Refresh();
                    this.etatModeImage = modeImage.center;
                    break;
                case modeImage.center:
                    this.pictureBoxMain.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
                    this.buttonMode.Text = "Centrer";
                    this.pictureBoxMain.Refresh();
                    this.etatModeImage = modeImage.zoom;
                    break;
                case modeImage.zoom:
                    this.pictureBoxMain.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
                    this.buttonMode.Text = "Etirer";
                    this.pictureBoxMain.Refresh();
                    this.etatModeImage = modeImage.stretch;
                    break;
            }
        }

        private void buttonQuitter_Click(object sender, EventArgs e)
        {
            this.Close();            
        }

        private void FormControlePrintScreen_FormClosed(object sender, FormClosedEventArgs e)
        {
           
           
        }

       
    }
}

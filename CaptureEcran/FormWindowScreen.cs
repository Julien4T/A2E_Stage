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
using System.Drawing.Drawing2D;

namespace CaptureEcran
{
    public partial class FormWindowScreen : Form
    {
        
      
       

        //controle de la position de la souris
        int postionX0;
        int positionY0;
        int selectLargeur;
        int selectHauteur;
        public Pen selectionOutil;
        int compteurClic;

        //départ du clic souris
        bool start = false;



        public FormWindowScreen()
        {
            InitializeComponent();
        }

        private void FormWindowScreen_Load(object sender, EventArgs e)
        {
            this.Hide();
            //créer le screenshot
            Bitmap printscreen = new Bitmap(Screen.PrimaryScreen.Bounds.Width,
                                     Screen.PrimaryScreen.Bounds.Height);
            //création du graphique et ses paramètres
            Graphics graphique = Graphics.FromImage(printscreen as Image);
            graphique.CopyFromScreen(0, 0, 0, 0, printscreen.Size);
            //mémoire temporaire pour stocker l'image
            using (MemoryStream s = new MemoryStream())
            {
                printscreen.Save(s, ImageFormat.Bmp);
                pictureBox1.Size = new System.Drawing.Size(this.Width, this.Height);
                pictureBox1.Image = Image.FromStream(s);
            }
            this.Show();
            Cursor = Cursors.Cross;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {           
            //gestion erreur image null
            if (pictureBox1.Image == null)
                return;
            //demarre le processus si deuxième clic souris (dessiner un rectangle)
            if (start)
            {
                pictureBox1.Refresh();
                selectLargeur = e.X - postionX0;
                selectHauteur = e.Y - positionY0;
                pictureBox1.CreateGraphics().DrawRectangle(selectionOutil,
                          postionX0, positionY0, selectLargeur, selectHauteur);
            }
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            //demarre le processus au clic droit de la souris
            if (!start)
            {
                if (e.Button == System.Windows.Forms.MouseButtons.Left)
                {
                    //starts coordinates for rectangle
                    postionX0 = e.X;
                    positionY0 = e.Y;
                    selectionOutil = new Pen(Color.Red, 1);
                    selectionOutil.DashStyle = DashStyle.DashDotDot;
                    compteurClic += 1;
                }
                pictureBox1.Refresh();
                //demarre le controle pour dessiner le rectangle
                start = true;
            }
            else
            {
                if (pictureBox1.Image == null)
                    return;
                if (e.Button == System.Windows.Forms.MouseButtons.Left)
                {
                    pictureBox1.Refresh();
                    selectLargeur = e.X - postionX0;
                    selectHauteur = e.Y - positionY0;
                    pictureBox1.CreateGraphics().DrawRectangle(selectionOutil, postionX0,
                             positionY0, selectLargeur, selectHauteur);

                }
                start = false;
                SaveToClipboard();
            }
        }

        private void SaveToClipboard()
        {
            //valide si une selection existe
            if (selectLargeur > 0 && selectHauteur>0 )
            {

                Rectangle rect = new Rectangle(postionX0, positionY0, selectLargeur, selectHauteur);
                Bitmap OriginalImage = new Bitmap(pictureBox1.Image, pictureBox1.Width, pictureBox1.Height);
                Bitmap _img = new Bitmap(selectLargeur, selectHauteur);
                Graphics g = Graphics.FromImage(_img);
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
                g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                g.DrawImage(OriginalImage, 0, 0, rect, GraphicsUnit.Pixel);

                FormControlePrintScreen.imprimeEcran = _img;
            

                FormControlePrintScreen.chargerImage(FormControlePrintScreen.etat.fonctionnement, FormControlePrintScreen.formMainCapture);
                FormControlePrintScreen.formMainCapture.Show();
                FormControlePrintScreen.formMainCapture.Focus();
                this.Close();
                
            }
        }



    }
}

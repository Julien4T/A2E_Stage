using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace ConnectBDD
{
    public partial class Form1 : Form
    {

      

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            DataTable ds = Connection.CreerDataTable("Select * from Personnel");

            dataGridView1.DataSource = ds;
            //dataGridView1.SetDataBinding(ds, "Test");
            MessageBox.Show("ok");
        }

       
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Personnel.InscrireNom("nicolas","inot","àlpfe");

          
        }
        private void Control1_MouseClick(object sender, EventArgs e)
        {

            var mouseEventArgs = e as MouseEventArgs;
            if (mouseEventArgs != null) textBox1.Text = "X= " + mouseEventArgs.X + " Y= " + mouseEventArgs.Y;
        }


        private void panel1_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            // Update the mouse path with the mouse information
            Point position = MousePosition;
            MessageBox.Show("OK");

            string eventString = null;
            switch (e.Button){
                case MouseButtons.Left:
                    eventString = "L";
                    MessageBox.Show("OK");
                    textBox1.Text = "X: " + position.X +
                 "\n" +
                    "Y: " + position.Y;
                    break;
                case MouseButtons.Right:
                    eventString = "R";
                    break;
                case MouseButtons.Middle:
                    eventString = "M";
                    break;
                case MouseButtons.XButton1:
                    eventString = "X1";
                    break;
                case MouseButtons.XButton2:
                    eventString = "X2";
                    break;
                case MouseButtons.None:
                default:
                    break;
            }
        }

        

        
    }
}

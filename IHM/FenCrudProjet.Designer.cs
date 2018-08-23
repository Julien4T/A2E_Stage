namespace IHM
{
    partial class FenCrudProjet
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FenCrudProjet));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.buttonClose = new System.Windows.Forms.Button();
            this.buttonAddUpdate = new System.Windows.Forms.Button();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button5 = new System.Windows.Forms.Button();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.deletePersonnel = new System.Windows.Forms.Button();
            this.updatePersonnel = new System.Windows.Forms.Button();
            this.addPersonnel = new System.Windows.Forms.Button();
            this.updateProjet = new System.Windows.Forms.Button();
            this.statusStrip1.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel2});
            this.statusStrip1.Location = new System.Drawing.Point(0, 240);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(584, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "Projet";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(56, 17);
            this.toolStripStatusLabel1.Text = "Un projet";
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 4;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.12369F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 66.87631F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 57F));
            this.tableLayoutPanel5.Controls.Add(this.label5, 1, 1);
            this.tableLayoutPanel5.Controls.Add(this.label6, 1, 2);
            this.tableLayoutPanel5.Controls.Add(this.tableLayoutPanel6, 2, 6);
            this.tableLayoutPanel5.Controls.Add(this.dateTimePicker1, 2, 2);
            this.tableLayoutPanel5.Controls.Add(this.label7, 1, 3);
            this.tableLayoutPanel5.Controls.Add(this.label8, 1, 4);
            this.tableLayoutPanel5.Controls.Add(this.textBox1, 2, 1);
            this.tableLayoutPanel5.Controls.Add(this.textBox2, 2, 3);
            this.tableLayoutPanel5.Controls.Add(this.tableLayoutPanel2, 2, 4);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 7;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(584, 240);
            this.tableLayoutPanel5.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(53, 33);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Nom projet :";
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(53, 73);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(36, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "Date :";
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.ColumnCount = 2;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel6.Controls.Add(this.buttonClose, 1, 0);
            this.tableLayoutPanel6.Controls.Add(this.buttonAddUpdate, 0, 0);
            this.tableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel6.Location = new System.Drawing.Point(211, 203);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 1;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(313, 34);
            this.tableLayoutPanel6.TabIndex = 6;
            // 
            // buttonClose
            // 
            this.buttonClose.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonClose.Location = new System.Drawing.Point(159, 3);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(151, 28);
            this.buttonClose.TabIndex = 5;
            this.buttonClose.Text = "Annuler";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // buttonAddUpdate
            // 
            this.buttonAddUpdate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonAddUpdate.Location = new System.Drawing.Point(3, 3);
            this.buttonAddUpdate.Name = "buttonAddUpdate";
            this.buttonAddUpdate.Size = new System.Drawing.Size(150, 28);
            this.buttonAddUpdate.TabIndex = 6;
            this.buttonAddUpdate.Text = "Ajouter/Modifier";
            this.buttonAddUpdate.UseVisualStyleBackColor = true;
            this.buttonAddUpdate.Click += new System.EventHandler(this.buttonAddUpdate_Click);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.dateTimePicker1.Location = new System.Drawing.Point(211, 70);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(313, 20);
            this.dateTimePicker1.TabIndex = 7;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(53, 113);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(87, 13);
            this.label7.TabIndex = 8;
            this.label7.Text = "Lien SVN projet :";
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(53, 153);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(75, 13);
            this.label8.TabIndex = 9;
            this.label8.Text = "Responsable :";
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(211, 30);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(313, 20);
            this.textBox1.TabIndex = 10;
            // 
            // textBox2
            // 
            this.textBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox2.Location = new System.Drawing.Point(211, 110);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(313, 20);
            this.textBox2.TabIndex = 11;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.BackColor = System.Drawing.SystemColors.Control;
            this.tableLayoutPanel2.ColumnCount = 4;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel2.Controls.Add(this.deletePersonnel, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.updatePersonnel, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.addPersonnel, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.comboBox1, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(208, 140);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(319, 40);
            this.tableLayoutPanel2.TabIndex = 14;
            // 
            // comboBox1
            // 
            this.comboBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(3, 9);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(208, 21);
            this.comboBox1.TabIndex = 17;
            // 
            // button5
            // 
            this.button5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button5.Location = new System.Drawing.Point(3, 3);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(150, 28);
            this.button5.TabIndex = 4;
            this.button5.Text = "Ajouter/Modifier";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(38, 17);
            this.toolStripStatusLabel2.Text = "Projet";
            // 
            // deletePersonnel
            // 
            this.deletePersonnel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.deletePersonnel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.deletePersonnel.BackColor = System.Drawing.SystemColors.Menu;
            this.deletePersonnel.BackgroundImage = global::IHM.Properties.Resources.delete;
            this.deletePersonnel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.deletePersonnel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.deletePersonnel.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.deletePersonnel.FlatAppearance.BorderSize = 0;
            this.deletePersonnel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.deletePersonnel.Location = new System.Drawing.Point(290, 10);
            this.deletePersonnel.Margin = new System.Windows.Forms.Padding(6, 0, 0, 0);
            this.deletePersonnel.Name = "deletePersonnel";
            this.deletePersonnel.Padding = new System.Windows.Forms.Padding(5);
            this.deletePersonnel.Size = new System.Drawing.Size(20, 20);
            this.deletePersonnel.TabIndex = 16;
            this.deletePersonnel.UseVisualStyleBackColor = false;
            this.deletePersonnel.Click += new System.EventHandler(this.deletePersonnel_Click);
            // 
            // updatePersonnel
            // 
            this.updatePersonnel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.updatePersonnel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.updatePersonnel.BackColor = System.Drawing.SystemColors.Menu;
            this.updatePersonnel.BackgroundImage = global::IHM.Properties.Resources.update;
            this.updatePersonnel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.updatePersonnel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.updatePersonnel.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.updatePersonnel.FlatAppearance.BorderSize = 0;
            this.updatePersonnel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.updatePersonnel.Location = new System.Drawing.Point(256, 10);
            this.updatePersonnel.Margin = new System.Windows.Forms.Padding(7, 0, 0, 0);
            this.updatePersonnel.Name = "updatePersonnel";
            this.updatePersonnel.Padding = new System.Windows.Forms.Padding(5);
            this.updatePersonnel.Size = new System.Drawing.Size(23, 20);
            this.updatePersonnel.TabIndex = 15;
            this.updatePersonnel.UseVisualStyleBackColor = false;
            this.updatePersonnel.Click += new System.EventHandler(this.updatePersonnel_Click);
            // 
            // addPersonnel
            // 
            this.addPersonnel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.addPersonnel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.addPersonnel.BackColor = System.Drawing.SystemColors.Menu;
            this.addPersonnel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("addPersonnel.BackgroundImage")));
            this.addPersonnel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.addPersonnel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.addPersonnel.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.addPersonnel.FlatAppearance.BorderSize = 0;
            this.addPersonnel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addPersonnel.Location = new System.Drawing.Point(222, 10);
            this.addPersonnel.Margin = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.addPersonnel.Name = "addPersonnel";
            this.addPersonnel.Padding = new System.Windows.Forms.Padding(5);
            this.addPersonnel.Size = new System.Drawing.Size(20, 20);
            this.addPersonnel.TabIndex = 13;
            this.addPersonnel.UseVisualStyleBackColor = false;
            this.addPersonnel.Click += new System.EventHandler(this.addPersonnel_Click);
            // 
            // updateProjet
            // 
            this.updateProjet.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.updateProjet.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.updateProjet.BackColor = System.Drawing.SystemColors.Menu;
            this.updateProjet.BackgroundImage = global::IHM.Properties.Resources.update;
            this.updateProjet.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.updateProjet.Cursor = System.Windows.Forms.Cursors.Hand;
            this.updateProjet.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.updateProjet.FlatAppearance.BorderSize = 0;
            this.updateProjet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.updateProjet.Location = new System.Drawing.Point(256, 10);
            this.updateProjet.Margin = new System.Windows.Forms.Padding(7, 0, 0, 0);
            this.updateProjet.Name = "updateProjet";
            this.updateProjet.Padding = new System.Windows.Forms.Padding(5);
            this.updateProjet.Size = new System.Drawing.Size(23, 20);
            this.updateProjet.TabIndex = 15;
            this.updateProjet.UseVisualStyleBackColor = false;
            // 
            // FenCrudProjet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 262);
            this.Controls.Add(this.tableLayoutPanel5);
            this.Controls.Add(this.statusStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FenCrudProjet";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Ajouter/Modifier un projet";
            this.Load += new System.EventHandler(this.FenCrudProjet_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            this.tableLayoutPanel6.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button deletePersonnel;
        private System.Windows.Forms.Button updatePersonnel;
        private System.Windows.Forms.Button addPersonnel;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button updateProjet;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Button buttonAddUpdate;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
    }
}
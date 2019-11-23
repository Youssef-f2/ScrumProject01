namespace Location_De_Voitures
{
    partial class RechercherVoiture
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RechercherVoiture));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Marque = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Matricule = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Capacite = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BoiteVitesse = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Carburant = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Couleur = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Disponibilite = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Prix = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Rechercher = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.InactiveCaption;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.Marque,
            this.Matricule,
            this.Capacite,
            this.BoiteVitesse,
            this.Carburant,
            this.Couleur,
            this.Disponibilite,
            this.Prix});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.Location = new System.Drawing.Point(11, 78);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView1.Size = new System.Drawing.Size(1020, 215);
            this.dataGridView1.TabIndex = 0;
            // 
            // ID
            // 
            this.ID.DataPropertyName = "IdVoiture";
            this.ID.Frozen = true;
            this.ID.HeaderText = "ID Voiture";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ID.Width = 90;
            // 
            // Marque
            // 
            this.Marque.DataPropertyName = "Marque";
            this.Marque.Frozen = true;
            this.Marque.HeaderText = "Marque";
            this.Marque.MinimumWidth = 10;
            this.Marque.Name = "Marque";
            this.Marque.ReadOnly = true;
            this.Marque.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Marque.Width = 150;
            // 
            // Matricule
            // 
            this.Matricule.DataPropertyName = "Matricule";
            this.Matricule.Frozen = true;
            this.Matricule.HeaderText = "Matricule";
            this.Matricule.Name = "Matricule";
            this.Matricule.ReadOnly = true;
            this.Matricule.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Matricule.Width = 110;
            // 
            // Capacite
            // 
            this.Capacite.DataPropertyName = "Capacite";
            this.Capacite.Frozen = true;
            this.Capacite.HeaderText = "Capacite";
            this.Capacite.Name = "Capacite";
            this.Capacite.ReadOnly = true;
            this.Capacite.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // BoiteVitesse
            // 
            this.BoiteVitesse.DataPropertyName = "Boite_Vitesse";
            this.BoiteVitesse.Frozen = true;
            this.BoiteVitesse.HeaderText = "Boite a vitesse";
            this.BoiteVitesse.Name = "BoiteVitesse";
            this.BoiteVitesse.ReadOnly = true;
            this.BoiteVitesse.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.BoiteVitesse.Width = 105;
            // 
            // Carburant
            // 
            this.Carburant.DataPropertyName = "Carburant";
            this.Carburant.Frozen = true;
            this.Carburant.HeaderText = "Carburant";
            this.Carburant.Name = "Carburant";
            this.Carburant.ReadOnly = true;
            this.Carburant.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // Couleur
            // 
            this.Couleur.DataPropertyName = "Couleur";
            this.Couleur.Frozen = true;
            this.Couleur.HeaderText = "Couleur";
            this.Couleur.Name = "Couleur";
            this.Couleur.ReadOnly = true;
            this.Couleur.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // Disponibilite
            // 
            this.Disponibilite.DataPropertyName = "Disponibilite";
            this.Disponibilite.Frozen = true;
            this.Disponibilite.HeaderText = "Disponibilite";
            this.Disponibilite.Name = "Disponibilite";
            this.Disponibilite.ReadOnly = true;
            this.Disponibilite.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // Prix
            // 
            this.Prix.DataPropertyName = "Prix_Par_Jour";
            this.Prix.Frozen = true;
            this.Prix.HeaderText = "Prix par 24H";
            this.Prix.Name = "Prix";
            this.Prix.ReadOnly = true;
            this.Prix.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Prix.Width = 110;
            // 
            // Rechercher
            // 
            this.Rechercher.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Rechercher.ForeColor = System.Drawing.Color.Black;
            this.Rechercher.Location = new System.Drawing.Point(359, 24);
            this.Rechercher.Name = "Rechercher";
            this.Rechercher.Size = new System.Drawing.Size(184, 22);
            this.Rechercher.TabIndex = 12;
            this.Rechercher.Enter += new System.EventHandler(this.Rechercher_Enter);
            this.Rechercher.Leave += new System.EventHandler(this.Rechercher_Leave);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightSteelBlue;
            this.button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Location = new System.Drawing.Point(549, 24);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(182, 25);
            this.button2.TabIndex = 24;
            this.button2.Text = "             Rechercher";
            this.button2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            this.button2.MouseEnter += new System.EventHandler(this.button2_MouseEnter);
            this.button2.MouseLeave += new System.EventHandler(this.button2_MouseLeave);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(737, 24);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(182, 25);
            this.button1.TabIndex = 27;
            this.button1.Text = "Aficher tous les Voitures";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(127, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(226, 18);
            this.label3.TabIndex = 28;
            this.label3.Text = "Recherche sur tous les champs :";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Location = new System.Drawing.Point(657, 25);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(29, 23);
            this.pictureBox1.TabIndex = 86;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            this.pictureBox1.MouseEnter += new System.EventHandler(this.button2_MouseEnter);
            this.pictureBox1.MouseLeave += new System.EventHandler(this.button2_MouseLeave);
            // 
            // RechercherVoiture
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1043, 318);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.Rechercher);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RechercherVoiture";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Recherche Des Voitures";
            this.Load += new System.EventHandler(this.RechercherVoiture_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox Rechercher;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Marque;
        private System.Windows.Forms.DataGridViewTextBoxColumn Matricule;
        private System.Windows.Forms.DataGridViewTextBoxColumn Capacite;
        private System.Windows.Forms.DataGridViewTextBoxColumn BoiteVitesse;
        private System.Windows.Forms.DataGridViewTextBoxColumn Carburant;
        private System.Windows.Forms.DataGridViewTextBoxColumn Couleur;
        private System.Windows.Forms.DataGridViewTextBoxColumn Disponibilite;
        private System.Windows.Forms.DataGridViewTextBoxColumn Prix;
    }
}
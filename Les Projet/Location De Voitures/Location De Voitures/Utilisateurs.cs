using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Location_De_Voitures
{
    public partial class Utilisateurs : Form
    {
        MyTools o = new MyTools();
        BindingSource bs = new BindingSource();
        public Utilisateurs()
        {
            InitializeComponent();
        }
        public void RemplirUTI()
        {
            o.da = new SqlDataAdapter("Select * from Identification order by Nom", o.cn);
            o.da.Fill(o.ds, "Utu");
            comboBox3.DataSource = o.ds.Tables["Utu"];
            comboBox3.DisplayMember = "Nom";
            comboBox3.ValueMember = "Identifiant";
            comboBox3.SelectedIndex = -1;
        }
        private void button9_MouseEnter(object sender, EventArgs e)
        {
            pictureBox5.BackColor = System.Drawing.Color.Gray;
            button9.BackColor = System.Drawing.Color.Gray;

        }

        private void button9_MouseLeave(object sender, EventArgs e)
        {
            button9.BackColor = System.Drawing.Color.White;
            pictureBox5.BackColor = System.Drawing.Color.White;
        }
        private void button4_MouseEnter(object sender, EventArgs e)
        {
            pictureBox2.BackColor = System.Drawing.Color.Gray;
            button4.BackColor = System.Drawing.Color.Gray;

        }

        private void button4_MouseLeave(object sender, EventArgs e)
        {
            button4.BackColor = System.Drawing.Color.White;
            pictureBox2.BackColor = System.Drawing.Color.White;
        }
        private void button1_MouseEnter(object sender, EventArgs e)
        {
            pictureBox3.BackColor = System.Drawing.Color.Gray;
            button1.BackColor = System.Drawing.Color.Gray;

        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackColor = System.Drawing.Color.White;
            pictureBox3.BackColor = System.Drawing.Color.White;
        }
        private void button3_MouseEnter(object sender, EventArgs e)
        {
            pictureBox1.BackColor = System.Drawing.Color.IndianRed;
            button3.BackColor = System.Drawing.Color.IndianRed;
        }


        private void button3_MouseLeave(object sender, EventArgs e)
        {
            button3.BackColor = System.Drawing.Color.LightCoral;
            pictureBox1.BackColor = System.Drawing.Color.LightCoral;
        }
        private void Utilisateurs_Load(object sender, EventArgs e)
        {
            comboBox3.Items.Clear();
            RemplirUTI();
            o.conex();
            SqlCommand cmd = new SqlCommand("Select * from Identification ", o.cn);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            bs.DataSource = dt;

            textBox7.DataBindings.Add(new Binding("text", bs, "Nom"));
            textBox1.DataBindings.Add(new Binding("text", bs, "Prenom"));
            textBox2.DataBindings.Add(new Binding("text", bs, "Email"));
            textBox3.DataBindings.Add(new Binding("text", bs, "Identifiant"));
            textBox4.DataBindings.Add(new Binding("text", bs, "MotDePasse"));
            comboBox2.DataBindings.Add(new Binding("text", bs, "Privilege"));
            comboBox1.DataBindings.Add(new Binding("text", bs, "QuestionDeSecurite"));
            textBox6.DataBindings.Add(new Binding("text", bs, "Reponse"));
            o.Deconex();
            button1.Focus();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            o.conex();
            SqlCommand cmd = new SqlCommand("Select * from Identification ", o.cn);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            bs.DataSource = dt;
            o.Deconex();
            bs.MoveNext();
            comboBox3.SelectedIndex = -1;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            o.conex();
            SqlCommand cmd = new SqlCommand("Select * from Identification ", o.cn);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            bs.DataSource = dt;
            o.Deconex();
            bs.MovePrevious();
            comboBox3.SelectedIndex = -1;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            o.conex();
            SqlCommand cmd = new SqlCommand("Select * from Identification ", o.cn);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            bs.DataSource = dt;
            o.Deconex();
            bs.MoveFirst();
            comboBox3.SelectedIndex = -1;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            o.conex();
            SqlCommand cmd = new SqlCommand("Select * from Identification ", o.cn);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            bs.DataSource = dt;
            o.Deconex();
            comboBox3.SelectedIndex = -1;
            bs.MoveLast();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            button2.Visible = false;
            button3.Enabled = false;
            button5.Visible = false;
            button6.Visible = false;
            button7.Visible = false;
            button8.Visible = false;
            button4.Visible = true;
            button9.Visible = true;
            comboBox3.Enabled = false;
            textBox1.ReadOnly = false;
            textBox2.ReadOnly = false;
            textBox4.ReadOnly = false;
            textBox7.ReadOnly = false;
            comboBox1.Enabled = true;
            comboBox2.Enabled = true;
            textBox6.ReadOnly = false;
            pictureBox5.Visible = true;
            pictureBox2.Visible = true;
                pictureBox2.Enabled = false;
            pictureBox1.Enabled = false;
            pictureBox3.Enabled = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            button1.Enabled = true;
            button2.Visible = true;
            button3.Enabled = true;
            button5.Visible = true;
            button6.Visible = true;
            button7.Visible = true;
            button8.Visible = true;
            button4.Visible = false;
            button9.Visible = false;
            comboBox3.Enabled = true;
            comboBox3.SelectedIndex = -1;
            textBox1.ReadOnly = true;
            textBox2.ReadOnly = true;
            textBox4.ReadOnly = true;
            textBox7.ReadOnly = true;
            comboBox1.Enabled = false;
            comboBox2.Enabled = false;
            textBox6.ReadOnly = true;
            pictureBox5.Visible = false;
            pictureBox2.Visible = false;
            pictureBox3.Enabled = true;
            pictureBox1.Enabled = true;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox6.Text == "" || textBox7.Text == "")
            {
                MessageBox.Show("Veuillez remplir tout les champs avant de Enregistrer", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                o.conex();
                o.cmd = new SqlCommand("Update Identification set Nom = '" + textBox7.Text + "' , Prenom = '" + textBox1.Text + "' , MotDePasse ='" + textBox4.Text + "' , Privilege = '" + comboBox2.Text + "' , Email ='" + textBox2.Text + "' , QuestionDeSecurite = '" + comboBox1.Text + "' , Reponse = '" + textBox6.Text.ToUpper() + "' where Identifiant ='" + textBox3.Text + "'", o.cn);
                o.cmd.ExecuteNonQuery();
                o.Deconex();
                MessageBox.Show("Element bien modifie", "Modification reussi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
                Utilisateurs U = new Utilisateurs();
                U.ShowDialog();
                this.Close();

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Voulez-vous vraiment supprimer L'"+comboBox2.Text+" "+textBox1.Text+" "+textBox7.Text+" ?","Confirmation",MessageBoxButtons.YesNo,MessageBoxIcon.Warning)==DialogResult.Yes)
            {
                o.conex();
                o.cmd = new SqlCommand("Delete from Identification where Identifiant = '" + textBox3.Text + "'", o.cn);
                o.cmd.ExecuteNonQuery();
                o.Deconex();
                MessageBox.Show("Element bien supprime", "Reussi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
                Utilisateurs U = new Utilisateurs();
                U.ShowDialog();
                this.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            AjouterUtilisateur AU = new AjouterUtilisateur();
            AU.ShowDialog();
            this.Close();
        }

        private void comboBox3_SelectionChangeCommitted(object sender, EventArgs e)
        {
            o.conex();
            o.cmd = new SqlCommand("Select * from Identification where Identifiant = '" + comboBox3.SelectedValue + "'", o.cn);
            o.dr = o.cmd.ExecuteReader();
            while (o.dr.Read())
            {
                textBox3.Text = o.dr[0].ToString();
                textBox7.Text = o.dr[1].ToString();
                textBox1.Text = o.dr[2].ToString();
                textBox4.Text = o.dr[3].ToString();
                comboBox2.Text = o.dr[4].ToString();
                textBox2.Text = o.dr[5].ToString();
                comboBox1.Text = o.dr[6].ToString();
                textBox6.Text = o.dr[7].ToString();
            }
            o.dr.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Hide();
            AjouterUtilisateur AU = new AjouterUtilisateur();
            AU.ShowDialog();
            this.Close();
        }
    }
}

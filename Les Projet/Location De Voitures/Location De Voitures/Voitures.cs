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
    public partial class Voitures : Form
    {
        int i ;
        string hh;
        int h;
        string ii;
        MyTools o = new MyTools();
        BindingSource bs = new BindingSource();
        public Voitures()
        {
            InitializeComponent();
        }
        public void RemplirVoitures()
        {
            o.da = new SqlDataAdapter("Select * from Voitures order by Marque", o.cn);
            o.da.Fill(o.ds, "Voitures");
            comboBox4.DataSource = o.ds.Tables["Voitures"];
            comboBox4.DisplayMember = "Marque";
            comboBox4.ValueMember = "IdVoiture";
            comboBox4.SelectedIndex = -1;
        }
        private void buttonan_MouseEnter(object sender, EventArgs e)
        {
            pictureBox3.BackColor = System.Drawing.Color.LightSteelBlue;
            Annuler.BackColor = System.Drawing.Color.LightSteelBlue;

        }

        private void buttonan_MouseLeave(object sender, EventArgs e)
        {
            Annuler.BackColor = ColorTranslator.FromHtml("#BFCDDB");
            pictureBox3.BackColor = ColorTranslator.FromHtml("#BFCDDB");
        }
        private void buttoneng_MouseEnter(object sender, EventArgs e)
        {
            pictureBox5.BackColor = System.Drawing.Color.LightSteelBlue;
            Enregistrer.BackColor = System.Drawing.Color.LightSteelBlue;

        }

        private void buttoneng_MouseLeave(object sender, EventArgs e)
        {
            Enregistrer.BackColor = ColorTranslator.FromHtml("#BFCDDB");
            pictureBox5.BackColor = ColorTranslator.FromHtml("#BFCDDB");
        }
                private void button2_MouseEnter(object sender, EventArgs e)
        {
            pictureBox1.BackColor = System.Drawing.Color.LightSteelBlue;
            button2.BackColor = System.Drawing.Color.LightSteelBlue;
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            button2.BackColor = ColorTranslator.FromHtml("#BFCDDB");
            pictureBox1.BackColor = ColorTranslator.FromHtml("#BFCDDB");
        }
        private void button4_MouseEnter(object sender, EventArgs e)
        {
            pictureBox2.BackColor = System.Drawing.Color.LightSteelBlue;
            button4.BackColor = System.Drawing.Color.LightSteelBlue;

        }

        private void button4_MouseLeave(object sender, EventArgs e)
        {
            button4.BackColor = ColorTranslator.FromHtml("#BFCDDB");
            pictureBox2.BackColor = ColorTranslator.FromHtml("#BFCDDB");
        }

        private void Voitures_Load(object sender, EventArgs e)
        {
            comboBox4.Items.Clear();
            RemplirVoitures();
            o.conex();
            SqlCommand cmd = new SqlCommand("Select * from Voitures order by Marque", o.cn);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            bs.DataSource = dt;




            textBox1.DataBindings.Add(new Binding("text", bs, "IdVoiture"));
            textBox2.DataBindings.Add(new Binding("text", bs, "Marque"));
            textBox3.DataBindings.Add(new Binding("text", bs, "Matricule"));
            textBox4.DataBindings.Add(new Binding("text", bs, "Capacite"));
            i = textBox4.Text.IndexOf(" ");
             hh = textBox4.Text.Substring(0, i);
            numericUpDown2.Value = Convert.ToInt32(hh);
            comboBox2.DataBindings.Add(new Binding("text", bs, "Boite_Vitesse"));
            comboBox3.DataBindings.Add(new Binding("text", bs, "Carburant"));
            textBox7.DataBindings.Add(new Binding("text", bs, "Couleur"));
            comboBox1.DataBindings.Add(new Binding("text", bs, "Disponibilite"));
            textBox9.DataBindings.Add(new Binding("text", bs, "Prix_Par_Jour"));
            h = textBox9.Text.IndexOf(" ");
            ii = textBox9.Text.Substring(0, h);
            numericUpDown1.Value = Convert.ToInt32(ii);
            o.cn.Close();
            comboBox4.Focus();
        }

        private void Suivant_Click(object sender, EventArgs e)
        {
            o.conex();
            SqlCommand cmd = new SqlCommand("Select * from Voitures order by Marque", o.cn);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            bs.DataSource = dt;
            o.Deconex();
            bs.MoveNext();
            i = textBox4.Text.IndexOf(" ");
            hh = textBox4.Text.Substring(0, i);
            numericUpDown2.Value = Convert.ToInt32(hh);

            comboBox4.SelectedIndex = -1;

            
        }

        private void Last_Click(object sender, EventArgs e)
        {
            o.conex();
            SqlCommand cmd = new SqlCommand("Select * from Voitures order by Marque", o.cn);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            bs.DataSource = dt;
            o.Deconex();
            bs.MoveLast();
            i = textBox4.Text.IndexOf(" ");
            hh = textBox4.Text.Substring(0, i);
            numericUpDown2.Value = Convert.ToInt32(hh);

            comboBox4.SelectedIndex = -1;

        }

        private void Precedant_Click(object sender, EventArgs e)
        {
            o.conex();
            SqlCommand cmd = new SqlCommand("Select * from Voitures order by Marque", o.cn);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            bs.DataSource = dt;
            o.Deconex();
            bs.MovePrevious();
            i = textBox4.Text.IndexOf(" ");
            hh = textBox4.Text.Substring(0, i);
            numericUpDown2.Value = Convert.ToInt32(hh);
            h = textBox9.Text.IndexOf(" ");

            comboBox4.SelectedIndex = -1;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            o.conex();
            SqlCommand cmd = new SqlCommand("Select * from Voitures order by Marque", o.cn);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            bs.DataSource = dt;
            o.Deconex();
            bs.MoveFirst();
            i = textBox4.Text.IndexOf(" ");
            hh = textBox4.Text.Substring(0, i);
            numericUpDown2.Value = Convert.ToInt32(hh);

            comboBox4.SelectedIndex = -1;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Precedant.Visible = false;
            Suivant.Visible = false;
            Last.Visible = false;
            button3.Visible = false;
            Enregistrer.Visible = true;
            Annuler.Visible = true;
            textBox2.ReadOnly = false;
            textBox3.ReadOnly = false;
            textBox4.ReadOnly = false;
            comboBox2.Enabled = true;
            comboBox3.Enabled = true;
            textBox7.ReadOnly = false;
            textBox9.ReadOnly = false;
            comboBox1.Enabled = true;
            label10.Visible = true;
            button1.Enabled = false;
            comboBox4.Enabled = false;
            pictureBox3.Visible = true;
            pictureBox5.Visible = true;
            textBox9.Visible = false;
            numericUpDown1.Visible = true;
            label11.Visible = true;
            textBox4.Visible = false;
            numericUpDown2.Visible = true;
            label13.Visible = true;
        }

        private void Annuler_Click(object sender, EventArgs e)
        {
            comboBox4.Enabled = true;
            comboBox4.SelectedIndex = -1;
            Precedant.Visible = true;
            Suivant.Visible = true;
            Last.Visible = true;
            button3.Visible = true;
            Enregistrer.Visible = false;
            button1.Enabled = false;
            textBox2.ReadOnly = true;
            textBox3.ReadOnly = true;
            textBox4.ReadOnly = true;
            comboBox2.Enabled = false;
            comboBox3.Enabled = false;
            textBox7.ReadOnly = true;
            comboBox1.Enabled = false;
            button1.Enabled = true;
            textBox9.ReadOnly = true;
            label10.Visible = false;
            Annuler.Visible = false;
            pictureBox3.Visible = false;
            pictureBox5.Visible = false;
            textBox9.Visible = true;
            numericUpDown1.Visible = false;
            label11.Visible = false;
            textBox4.Visible = true;
            numericUpDown2.Visible = false;
            label13.Visible = false;

        }

        private void Enregistrer_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && comboBox2.SelectedIndex != -1 && comboBox3.SelectedIndex != -1 && textBox7.Text != "" && textBox9.Text != "" )
            {
                o.conex();
                o.cmd = new SqlCommand("Update Voitures set Marque ='" + textBox2.Text + "', Matricule ='" + textBox3.Text + "', Capacite ='" +Convert.ToInt32(numericUpDown2.Value)+" Places" + "', Boite_Vitesse ='" + comboBox2.SelectedItem.ToString() + "', Carburant ='" + comboBox3.SelectedItem.ToString() + "', Couleur ='" + textBox7.Text + "', Disponibilite ='" + comboBox1.SelectedItem.ToString() + "', Prix_Par_Jour ='" + Convert.ToInt32(numericUpDown1.Value) + " DH"+"' where IdVoiture = '" + textBox1.Text + "'", o.cn);
                o.cmd.ExecuteNonQuery();
                MessageBox.Show("Voiture " + textBox1.Text + " Bien Modifie", "Modification Reussi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                o.Deconex();
                this.Hide();
                Voitures VA = new Voitures();
                VA.ShowDialog();
                this.Close();


            }
            else
            {
                MessageBox.Show("Soyez sure que tout les champs sont remplit "+"\n"+ "Avant de cliquer Enregistrer", "Modification echoue", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            
        }



        private void button2_Click(object sender, EventArgs e)
        {
            RechercherVoiture RV = new RechercherVoiture();
            RV.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            AjouterVoiture AV = new AjouterVoiture();
            AV.ShowDialog();
            this.Close();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox4_SelectionChangeCommitted(object sender, EventArgs e)
        {
            o.conex();
            o.cmd = new SqlCommand("Select * from Voitures where Idvoiture = '" + comboBox4.SelectedValue + "'", o.cn);
            o.dr = o.cmd.ExecuteReader();
            while (o.dr.Read())
            {
                textBox1.Text = o.dr[0].ToString();
                textBox2.Text = o.dr[2].ToString();
                textBox3.Text = o.dr[3].ToString();
                textBox4.Text = o.dr[4].ToString();
                comboBox2.Text = o.dr[5].ToString();
                comboBox3.Text = o.dr[6].ToString();
                textBox7.Text = o.dr[7].ToString();
                comboBox1.Text = o.dr[8].ToString();
                textBox9.Text = o.dr[9].ToString();
            }
            i = textBox4.Text.IndexOf(" ");
            hh = textBox4.Text.Substring(0, i);
            numericUpDown2.Value = Convert.ToInt32(hh);

            o.dr.Close();

        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Hide();
            AjouterVoiture AV = new AjouterVoiture();
            AV.ShowDialog();
            this.Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            RechercherVoiture RV = new RechercherVoiture();
            RV.ShowDialog();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

            h = textBox9.Text.IndexOf(" ");
            ii = textBox9.Text.Substring(0, h);
            numericUpDown1.Value = Convert.ToInt32(ii);
        }
    }
}

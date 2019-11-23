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
    public partial class Locateurs : Form
    {
        MyTools o = new MyTools();
        BindingSource bs = new BindingSource();
        public Locateurs()
        {
            InitializeComponent();
        }
        public void RemplirVoitures()
        {
            o.da = new SqlDataAdapter("Select * from Locateurs Order by Nomcomplete", o.cn);
            o.da.Fill(o.ds, "Loc");
            comboBox1.DataSource = o.ds.Tables["Loc"];
            comboBox1.DisplayMember = "NomComplete";
            comboBox1.ValueMember = "IdLocateur";
            comboBox1.SelectedIndex = -1;
        }
        private void button2_MouseEnter(object sender, EventArgs e)
        {
            pictureBox2.BackColor = System.Drawing.Color.LightSteelBlue;
            button2.BackColor = System.Drawing.Color.LightSteelBlue;
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            button2.BackColor = ColorTranslator.FromHtml("#BFCDDB");
            pictureBox2.BackColor = ColorTranslator.FromHtml("#BFCDDB");
        }
        private void button4_MouseEnter(object sender, EventArgs e)
        {
            pictureBox3.BackColor = System.Drawing.Color.LightSteelBlue;
            button4.BackColor = System.Drawing.Color.LightSteelBlue;

        }

        private void button4_MouseLeave(object sender, EventArgs e)
        {
            button4.BackColor = ColorTranslator.FromHtml("#BFCDDB");
            pictureBox3.BackColor = ColorTranslator.FromHtml("#BFCDDB");
        }
        private void buttonan_MouseEnter(object sender, EventArgs e)
        {
            pictureBox1.BackColor = System.Drawing.Color.LightSteelBlue;
            Annuler.BackColor = System.Drawing.Color.LightSteelBlue;

        }

        private void buttonan_MouseLeave(object sender, EventArgs e)
        {
           Annuler.BackColor = ColorTranslator.FromHtml("#BFCDDB");
            pictureBox1.BackColor = ColorTranslator.FromHtml("#BFCDDB");
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
        private void Locateurs_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            RemplirVoitures();
            o.conex();
            SqlCommand cmd = new SqlCommand("Select * from Locateurs Order by Nomcomplete ", o.cn);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            bs.DataSource = dt;

            Id.DataBindings.Add(new Binding("text", bs, "IdLocateur"));
            CIN.DataBindings.Add(new Binding("text", bs, "CIN"));
            Nom.DataBindings.Add(new Binding("text", bs, "NomComplete"));
            dateTimePicker1.DataBindings.Add(new Binding("text", bs, "DateDeNaissance"));
            Tele.DataBindings.Add(new Binding("text", bs, "Telephone"));
            Adresse.DataBindings.Add(new Binding("text", bs, "Adresse"));

            o.cn.Close();

        }
    
        private void button5_Click(object sender, EventArgs e)
        {
            o.conex();
            SqlCommand cmd = new SqlCommand("Select * from Locateurs Order by Nomcomplete ", o.cn);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            bs.DataSource = dt;
            o.Deconex();
            comboBox1.SelectedIndex = -1;
            bs.MoveLast();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            o.conex();
            SqlCommand cmd = new SqlCommand("Select * from Locateurs Order by Nomcomplete ", o.cn);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            bs.DataSource = dt;
            o.Deconex();
            comboBox1.SelectedIndex = -1;
            bs.MoveNext();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            o.conex();
            SqlCommand cmd = new SqlCommand("Select * from Locateurs Order by Nomcomplete ", o.cn);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            bs.DataSource = dt;
            o.Deconex();
            comboBox1.SelectedIndex = -1;
            bs.MovePrevious();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            o.conex();
            SqlCommand cmd = new SqlCommand("Select * from Locateurs Order by Nomcomplete ", o.cn);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            bs.DataSource = dt;
            o.Deconex();
            comboBox1.SelectedIndex = -1;
            bs.MoveFirst();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            comboBox1.Enabled = false;
            button8.Visible = false;
            button7.Visible = false;
            button5.Visible = false;
            button6.Visible = false;
            Enregistrer.Visible = true;
            Annuler.Visible = true;
            Adresse.ReadOnly = false;
            CIN.ReadOnly = false;
            Nom.ReadOnly = false;
            Tele.ReadOnly = false;
            dateTimePicker1.Enabled = true;
            label10.Visible = true;
            button1.Enabled = false;
            pictureBox1.Visible = true;
            pictureBox5.Visible = true;
              

        }

        private void Annuler_Click(object sender, EventArgs e)
        {
            comboBox1.Enabled = true;
            comboBox1.SelectedIndex = -1;
            button8.Visible = true;
            button7.Visible = true;
            button5.Visible = true;
            button6.Visible = true;
            Enregistrer.Visible = false;
            button1.Enabled = false;
            Adresse.ReadOnly = true;
            CIN.ReadOnly = true;
            Nom.ReadOnly = true;
            Tele.ReadOnly = true;
            dateTimePicker1.Enabled = false;
            button1.Enabled = true;
            label10.Visible = false;
            Annuler.Visible = false;
            pictureBox1.Visible = false;
            pictureBox5.Visible = false;
        }

        private void Enregistrer_Click(object sender, EventArgs e)
        {
            DataTable dta = new DataTable();
            if (CIN.Text != "" && Nom.Text != "" && Tele.Text != "" && Adresse.Text != "")
            {
                    o.conex();
                    o.cmd = new SqlCommand("Update Locateurs set CIN ='" + CIN.Text + "', NomComplete ='" + Nom.Text + "', DateDeNaissance ='" + dateTimePicker1.Text.ToString() + "', Telephone ='" + Tele.Text + "', Adresse ='" + Adresse.Text + "' where IdLocateur = '" + Id.Text + "'", o.cn);
                    o.cmd.ExecuteNonQuery();
                    MessageBox.Show("Locateur " + Id.Text + " Bien Modifie", "Modification Reussi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    o.Deconex();
                    this.Hide();
                    Locateurs L = new Locateurs();
                    L.ShowDialog();
                    this.Close();
            }
            else
            {
                MessageBox.Show("Soyez sure que tout les champs sont remplit " + "\n" + "Avant de cliquer Enregistrer", "Modification echoue", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            AjouterLocateur2 AC = new AjouterLocateur2();
            AC.ShowDialog();
            this.Close();
        }

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            o.conex();
            o.cmd = new SqlCommand("Select * from Locateurs where IdLocateur = '" + comboBox1.SelectedValue + "'", o.cn);
            o.dr = o.cmd.ExecuteReader();
            while (o.dr.Read())
            {
                Id.Text = o.dr[0].ToString();
                CIN.Text = o.dr[2].ToString();
                Nom.Text = o.dr[3].ToString();
                dateTimePicker1.Text = o.dr[4].ToString();
                Tele.Text = o.dr[5].ToString();
                Adresse.Text = o.dr[6].ToString();
            }
            o.dr.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            RechercherLocateurs RL = new RechercherLocateurs();
            RL.ShowDialog();
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Hide();
            AjouterLocateur AC = new AjouterLocateur();
            AC.ShowDialog();
            this.Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            RechercherLocateurs RL = new RechercherLocateurs();
            RL.ShowDialog();
        }
    }
}

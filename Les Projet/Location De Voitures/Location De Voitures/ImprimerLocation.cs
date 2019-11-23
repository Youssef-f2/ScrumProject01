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
using System.Globalization;

namespace Location_De_Voitures
{
    public partial class ImprimerLocation : Form
    {
        MyTools o = new MyTools();


        public ImprimerLocation()
        {
            InitializeComponent();
        }
        private void button3_MouseEnter(object sender, EventArgs e)
        {
            pictureBox2.BackColor = System.Drawing.Color.LightSteelBlue;
            button3.BackColor = System.Drawing.Color.LightSteelBlue;

        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {
            button3.BackColor = ColorTranslator.FromHtml("#BFCDDB");
            pictureBox2.BackColor = ColorTranslator.FromHtml("#BFCDDB");
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
        private void RechercherLocation_Load(object sender, EventArgs e)
        {

            o.conex();
            o.cmd = new SqlCommand("Select IdLocation,IdVoiture,IdLocateur,Marque,NomLocateur,DateLocation,DateSoumission,NombreDeJour,PrixTotal from Locations", o.cn);
            o.dr = o.cmd.ExecuteReader();
            o.dt = new DataTable();
            o.dt.Load(o.dr);
            dataGridView1.DataSource = o.dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            o.conex();
            o.cmd = new SqlCommand("Select IdLocation,IdVoiture,IdLocateur,Marque,NomLocateur,DateLocation,DateSoumission,NombreDeJour,PrixTotal from Locations", o.cn);
            o.dr = o.cmd.ExecuteReader();
            o.dt = new DataTable();
            o.dt.Load(o.dr);
            dataGridView1.DataSource = o.dt;
            Rechercher.Clear();
            Rechercher.Focus();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (Rechercher.Text == "")
            {
                MessageBox.Show("Le champs de Recherche est vide", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                o.conex();
                o.cmd = new SqlCommand("Select IdLocation,IdVoiture,IdLocateur,Marque,NomLocateur,DateLocation,DateSoumission,NombreDeJour,PrixTotal from Locations where IdVoiture like '%" + Rechercher.Text + "%' or IdLocateur like '%" + Rechercher.Text + "%' or Marque like '%" + Rechercher.Text + "%' or NomLocateur like '%" + Rechercher.Text + "%' or PrixTotal like '%" + Rechercher.Text + "%' or NombreDeJour like '%" + Rechercher.Text + "%'", o.cn);
                o.dr = o.cmd.ExecuteReader();
                o.dt = new DataTable();
                o.dt.Load(o.dr);
                if (o.dt.Rows.Count != 0)
                {
                    dataGridView1.DataSource = o.dt;
                }
                else
                {
                    MessageBox.Show("Aucun champ ne porte la valeur '" + Rechercher.Text + "' Dans la liste des Location", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Rechercher.Clear();
                }

            }

        }

        private void dateTimePicker1_Enter(object sender, EventArgs e)
        {

        }

        private void dateTimePicker2_Enter(object sender, EventArgs e)
        {

        }


        private void button4_Click(object sender, EventArgs e)
        {
            dateTimePicker1.Visible = true;
            button5.Visible = true;
            button6.Visible = true;
            button3.Enabled = false;
            Rechercher.Enabled = false;
            button12.Enabled = false;
            button9.Enabled = false;
            button4.Visible = false;
            pictureBox1.Enabled = false;
            pictureBox2.Enabled = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            dateTimePicker1.Visible = false;
            button5.Visible = false;
            button6.Visible = false;
            button3.Enabled = true;
            Rechercher.Enabled = true;
            button12.Enabled = true;
            button9.Enabled = true;
            button4.Visible = true;
            pictureBox1.Enabled = true;
            pictureBox2.Enabled = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DateTime d = Convert.ToDateTime(dateTimePicker1.Value.ToShortDateString());
            string sqlformat = d.Date.ToString("yyyy-MM-dd");
            o.conex();
            o.cmd = new SqlCommand("Select IdLocation,IdVoiture,IdLocateur,Marque,NomLocateur,DateLocation,DateSoumission,NombreDeJour,PrixTotal from Locations where DateSoumission = '" + sqlformat + "'", o.cn);
            o.dr = o.cmd.ExecuteReader();
            o.dt = new DataTable();
            o.dt.Load(o.dr);
            if (o.dt.Rows.Count == 0)
            {
                MessageBox.Show("Aucune Location a la date '" + dateTimePicker1.Value.ToShortDateString() + "' Comme date de Soumission", "Recherche vide", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                dataGridView1.DataSource = o.dt;
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            button9.Visible = false;
            button7.Visible = true;
            button8.Visible = true;
            dateTimePicker2.Visible = true;
            Rechercher.Enabled = false;
            button3.Enabled = false;
            button12.Enabled = false;
            button4.Enabled = false;
            pictureBox1.Enabled = false;
            pictureBox2.Enabled = false;

        }

        private void button7_Click(object sender, EventArgs e)
        {
            button9.Visible = true;
            button7.Visible = false;
            button8.Visible = false;
            dateTimePicker2.Visible = false;
            Rechercher.Enabled = true;
            button3.Enabled = true;
            button12.Enabled = true;
            button4.Enabled = true;
            pictureBox1.Enabled = true;
            pictureBox2.Enabled = true;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            DateTime d = Convert.ToDateTime(dateTimePicker2.Value.ToShortDateString());
            string sqlformat = d.Date.ToString("yyyy-MM-dd");
            o.conex();
            o.cmd = new SqlCommand("Select IdLocation,IdVoiture,IdLocateur,Marque,NomLocateur,DateLocation,DateSoumission,NombreDeJour,PrixTotal from Locations where DateLocation = '" + sqlformat + "'", o.cn);
            o.dr = o.cmd.ExecuteReader();
            o.dt = new DataTable();
            o.dt.Load(o.dr);
            if (o.dt.Rows.Count == 0)
            {
                MessageBox.Show("Aucune Location a la date '" + dateTimePicker2.Value.ToShortDateString() + "' Comme date de Location", "Recherche vide", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                dataGridView1.DataSource = o.dt;
            }

        }

        private void button12_Click(object sender, EventArgs e)
        {
            button12.Visible = false;
            button10.Visible = true;
            button11.Visible = true;
            dateTimePicker3.Visible = true;
            dateTimePicker4.Visible = true;
            label1.Visible = true;
            label2.Visible = true;
            button9.Enabled = false;
            button4.Enabled = false;
            Rechercher.Enabled = false;
            button3.Enabled = false;
            pictureBox1.Enabled = false;
            pictureBox2.Enabled = false;

        }

        private void button10_Click(object sender, EventArgs e)
        {
            button12.Visible = true;
            button10.Visible = false;
            button11.Visible = false;
            dateTimePicker3.Visible = false;
            dateTimePicker4.Visible = false;
            label1.Visible = false;
            label2.Visible = false;
            button9.Enabled = true;
            button4.Enabled = true;
            Rechercher.Enabled = true;
            button3.Enabled = true;
            pictureBox1.Enabled = true;
            pictureBox2.Enabled = true;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            DateTime d = Convert.ToDateTime(dateTimePicker3.Value.ToShortDateString());
            string sqlformat = d.Date.ToString("yyyy-MM-dd");
            DateTime d2 = Convert.ToDateTime(dateTimePicker4.Value.ToShortDateString());
            string sqlformat2 = d.Date.ToString("yyyy-MM-dd");
            o.conex();
            o.cmd = new SqlCommand("Select IdLocation,IdVoiture,IdLocateur,Marque,NomLocateur,DateLocation,DateSoumission,NombreDeJour,PrixTotal from Locations where DateLocation between '" + sqlformat + "' and '" + sqlformat2 + "'", o.cn);
            o.dr = o.cmd.ExecuteReader();
            o.dt = new DataTable();
            o.dt.Load(o.dr);
            if (o.dt.Rows.Count == 0)
            {
                MessageBox.Show("Aucune Location existe entre les date '" + dateTimePicker3.Value.ToShortDateString() + "' Et " + dateTimePicker4.Value.ToShortDateString() + "'", "Recherche vide", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                dataGridView1.DataSource = o.dt;
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            Test t = new Test(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            t.ShowDialog();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Test t = new Test(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            t.ShowDialog();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
    }                                                     
}

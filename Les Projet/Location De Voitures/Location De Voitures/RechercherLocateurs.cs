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
    public partial class RechercherLocateurs : Form
    {
        MyTools o = new MyTools();

        
        public RechercherLocateurs()
        {
            InitializeComponent();
            
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

        private void RechercherVoiture_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            o.conex();
            o.cmd = new SqlCommand("Select IdLocateur,CIN,NomComplete,DateDeNaissance,Telephone,Adresse from Locateurs ", o.cn);
            o.dr = o.cmd.ExecuteReader();
            dt.Load(o.dr);
            dataGridView1.DataSource = dt;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Rechercher.Text == "" )
            {
                MessageBox.Show("Le champs de Recherche est vide", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
             

                DataTable dt = new DataTable();
                o.conex();
                o.cmd = new SqlCommand("Select IdLocateur,CIN,NomComplete,DateDeNaissance,Telephone,Adresse from Locateurs where NomComplete like '%" + Rechercher.Text + "%' or CIN like '%" + Rechercher.Text + "%' or Telephone like '%" + Rechercher.Text + "%' or Adresse like '%" + Rechercher.Text + "%' or IdLocateur like '%" + Rechercher.Text + "%'", o.cn);
                o.dr = o.cmd.ExecuteReader();
                dt.Load(o.dr);
                if (dt.Rows.Count != 0)
                {
                    dataGridView1.DataSource = dt;
                }
                else
                {
                    MessageBox.Show("Aucun champ ne porte la valeur '" + Rechercher.Text + "' Dans la liste des Locateurs", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Rechercher.Clear();
                }
            }

        }
        private void Rechercher_Enter(object sender, EventArgs e)
        {

        }

        private void Rechercher_Leave(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            o.conex();
            o.cmd = new SqlCommand("Select IdLocateur,CIN,NomComplete,DateDeNaissance,Telephone,Adresse from Locateurs", o.cn);
            o.dr = o.cmd.ExecuteReader();
            dt.Load(o.dr);
            dataGridView1.DataSource = dt;
            o.Deconex();
            Rechercher.Clear();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (Rechercher.Text == "")
            {
                MessageBox.Show("Le champs de Recherche est vide", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {


                DataTable dt = new DataTable();
                o.conex();
                o.cmd = new SqlCommand("Select IdLocateur,CIN,NomComplete,DateDeNaissance,Telephone,Adresse from Locateurs where NomComplete like '%" + Rechercher.Text + "%' or CIN like '%" + Rechercher.Text + "%' or Telephone like '%" + Rechercher.Text + "%' or Adresse like '%" + Rechercher.Text + "%' or IdLocateur like '%" + Rechercher.Text + "%'", o.cn);
                o.dr = o.cmd.ExecuteReader();
                dt.Load(o.dr);
                if (dt.Rows.Count != 0)
                {
                    dataGridView1.DataSource = dt;
                }
                else
                {
                    MessageBox.Show("Aucun champ ne porte la valeur '" + Rechercher.Text + "' Dans la liste des Locateurs", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Rechercher.Clear();
                }
            }


        }
    }
}

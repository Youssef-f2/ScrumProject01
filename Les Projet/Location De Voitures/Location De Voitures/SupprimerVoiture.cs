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


    public partial class SupprimerVoiture : Form
    {
        MyTools o = new MyTools();
        BindingSource bs = new BindingSource();
        public SupprimerVoiture()
        {
            InitializeComponent();
        }
        private void button3_MouseEnter(object sender, EventArgs e)
        {
            pictureBox1.BackColor = System.Drawing.Color.IndianRed;
            button1.BackColor = System.Drawing.Color.IndianRed;
        }
        private void button3_MouseLeave(object sender, EventArgs e)
        {
            button1.BackColor = System.Drawing.Color.LightCoral;
            pictureBox1.BackColor = System.Drawing.Color.LightCoral;
        }
        private void SupprimerVoiture_Load(object sender, EventArgs e)
        {
            RemplirVoitures();
            o.conex();
            SqlCommand cmd = new SqlCommand("Select * from Voitures order by Marque ", o.cn);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            bs.DataSource = dt;

            textBox1.DataBindings.Add(new Binding("text", bs, "IdVoiture"));
            textBox2.DataBindings.Add(new Binding("text", bs, "Marque"));
            textBox3.DataBindings.Add(new Binding("text", bs, "Matricule"));
            textBox4.DataBindings.Add(new Binding("text", bs, "Capacite"));
            textBox6.DataBindings.Add(new Binding("text", bs, "Boite_Vitesse"));
            textBox8.DataBindings.Add(new Binding("text", bs, "Carburant"));
            textBox7.DataBindings.Add(new Binding("text", bs, "Couleur"));
            textBox5.DataBindings.Add(new Binding("text", bs, "Disponibilite"));
            textBox9.DataBindings.Add(new Binding("text", bs, "Prix_Par_Jour"));
            o.cn.Close();
        }

        private void Last_Click(object sender, EventArgs e)
        {
            o.conex();
            SqlCommand cmd = new SqlCommand("Select * from Voitures order by Marque ", o.cn);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            bs.DataSource = dt;
            o.Deconex();
            comboBox1.SelectedIndex = -1;
            bs.MoveLast();
        }

        private void Suivant_Click(object sender, EventArgs e)
        {
            o.conex();
            SqlCommand cmd = new SqlCommand("Select * from Voitures order by Marque ", o.cn);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            bs.DataSource = dt;
            o.Deconex();
            comboBox1.SelectedIndex = -1;
            bs.MoveNext();
        }

        private void Precedant_Click(object sender, EventArgs e)
        {
            o.conex();
            SqlCommand cmd = new SqlCommand("Select * from Voitures order by Marque ", o.cn);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            bs.DataSource = dt;
            o.Deconex();
            comboBox1.SelectedIndex = -1;
            bs.MovePrevious();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            o.conex();
            SqlCommand cmd = new SqlCommand("Select * from Voitures order by Marque ", o.cn);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            bs.DataSource = dt;
            o.Deconex();
            comboBox1.SelectedIndex = -1;
            bs.MoveFirst();
        }
        public void RemplirVoitures()
        {
            o.da = new SqlDataAdapter("Select * from Voitures order by Marque", o.cn);
            o.da.Fill(o.ds, "Voitures");
            comboBox1.DataSource = o.ds.Tables["Voitures"];
            comboBox1.DisplayMember = "Marque";
            comboBox1.ValueMember = "IdVoiture";
            comboBox1.SelectedIndex = -1;
        }
        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            o.conex();
            o.cmd = new SqlCommand("Select * from Voitures where Idvoiture = '" + comboBox1.SelectedValue + "'", o.cn);
            o.dr = o.cmd.ExecuteReader();
            while (o.dr.Read())
            {
                textBox1.Text = o.dr[0].ToString();
                textBox2.Text = o.dr[2].ToString();
                textBox3.Text = o.dr[3].ToString();
                textBox4.Text = o.dr[4].ToString();
                textBox6.Text = o.dr[5].ToString();
                textBox8.Text = o.dr[6].ToString();
                textBox7.Text = o.dr[7].ToString();
                textBox5.Text = o.dr[8].ToString();
                textBox9.Text = o.dr[9].ToString();
            }
            o.dr.Close();

        }



        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("En supprimant la Voiture '" + textBox2.Text + "' tous les Locations qont la concerne vont etre supprimer , Voulez-vous vraiment La supprimer ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)

            {
                o.conex();
                o.cmd = new SqlCommand("Delete from Voitures where IdVoiture = '" + textBox1.Text + "'", o.cn);
                o.cmd.ExecuteNonQuery();
                MessageBox.Show("Voiture bien supprime", "Supression avec succes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                o.Deconex();
                this.Hide();
                SupprimerVoiture SV = new SupprimerVoiture();
                SV.ShowDialog();
                this.Close();
            }


        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("En supprimant la Voiture '" + textBox2.Text + "' tous les Locations qont la concerne vont etre supprimer , Voulez-vous vraiment La supprimer ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)

            {
                o.conex();
                o.cmd = new SqlCommand("Delete from Voitures where IdVoiture = '" + textBox1.Text + "'", o.cn);
                o.cmd.ExecuteNonQuery();
                MessageBox.Show("Voiture bien supprime", "Supression avec succes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                o.Deconex();
                this.Hide();
                SupprimerVoiture SV = new SupprimerVoiture();
                SV.ShowDialog();
                this.Close();
            }
        }


    }
}

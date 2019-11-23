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
    public partial class SupprimerLocateur : Form
    {
        MyTools o = new MyTools();
        BindingSource bs = new BindingSource();
        public SupprimerLocateur()
        {
            InitializeComponent();
        }
        private void button1_MouseEnter(object sender, EventArgs e)
        {
            pictureBox1.BackColor = System.Drawing.Color.IndianRed;
            button1.BackColor = System.Drawing.Color.IndianRed;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackColor = System.Drawing.Color.LightCoral;
            pictureBox1.BackColor = System.Drawing.Color.LightCoral;
        }
        private void SupprimerVoiture_Load(object sender, EventArgs e)
        {
            RemplirLocateurs();
            o.conex();
            SqlCommand cmd = new SqlCommand("Select * from Locateurs order by NomComplete ", o.cn);
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

        private void Last_Click(object sender, EventArgs e)
        {
            o.conex();
            SqlCommand cmd = new SqlCommand("Select * from Locateurs order by NomComplete ", o.cn);
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
            SqlCommand cmd = new SqlCommand("Select * from Locateurs order by NomComplete ", o.cn);
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
            SqlCommand cmd = new SqlCommand("Select * from Locateurs order by NomComplete ", o.cn);
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
            SqlCommand cmd = new SqlCommand("Select * from Locateurs order by NomComplete ", o.cn);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            bs.DataSource = dt;
            o.Deconex();
            comboBox1.SelectedIndex = -1;
            bs.MoveFirst();
        }
        public void RemplirLocateurs()
        {
            o.da = new SqlDataAdapter("Select * from Locateurs order by NomComplete", o.cn);
            o.da.Fill(o.ds, "Voitures");
            comboBox1.DataSource = o.ds.Tables["Voitures"];
            comboBox1.DisplayMember = "NomComplete";
            comboBox1.ValueMember = "IdLocateur";
            comboBox1.SelectedIndex = -1;
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

        private void button1_Click(object sender, EventArgs e)
        {
                if (MessageBox.Show("En supprimant le Locateur '"+Nom.Text+"' tous les Locations qont lui concerne vont etre supprimer automatiquement, Voulez-vous vraiment Le supprimer ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                o.conex();
                o.cmd = new SqlCommand("Delete from Locateurs where IdLocateur = '" + Id.Text + "'", o.cn);
                o.cmd.ExecuteNonQuery();
                MessageBox.Show("Locateur bien supprime", "Supression avec succes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                o.Deconex();
                this.Hide();
                SupprimerLocateur SV = new SupprimerLocateur();
                SV.ShowDialog();
                this.Close();
            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("En supprimant le Locateur '" + Nom.Text + "' tous les Locations qont lui concerne vont etre supprimer automatiquement, Voulez-vous vraiment Le supprimer ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                o.conex();
                o.cmd = new SqlCommand("Delete from Locateurs where IdLocateur = '" + Id.Text + "'", o.cn);
                o.cmd.ExecuteNonQuery();
                MessageBox.Show("Locateur bien supprime", "Supression avec succes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                o.Deconex();
                this.Hide();
                SupprimerLocateur SV = new SupprimerLocateur();
                SV.ShowDialog();
                this.Close();
            }
        }
    }
}

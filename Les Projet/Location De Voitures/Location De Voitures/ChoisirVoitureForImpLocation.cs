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
    public partial class ChoisirVoitureForImpLocation : Form
    {
        MyTools o = new MyTools();
        public ChoisirVoitureForImpLocation()
        {
            InitializeComponent();
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
                textBox2.Text = o.dr[3].ToString();
                textBox3.Text = o.dr[4].ToString();
                textBox4.Text = o.dr[5].ToString();
                textBox5.Text = o.dr[6].ToString();
                textBox6.Text = o.dr[7].ToString();
                textBox7.Text = o.dr[8].ToString();
                textBox8.Text = "" + o.dr[9].ToString();
            }
            o.dr.Close();
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
        private void ChoisirVoitureForImpLocation_Load(object sender, EventArgs e)
        {
            RemplirVoitures();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex != -1)
            {
                o.conex();
                o.cmd = new SqlCommand("select * from Locations where IdVoiture = '" + textBox1.Text.ToString() + "'", o.cn);
                o.dr = o.cmd.ExecuteReader();
                if (o.dr.HasRows)
                {
                    this.Hide();
                    ImpVoitureForLocation i = new ImpVoitureForLocation(textBox1.Text.ToString());
                    i.ShowDialog();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("La Voiture '" + comboBox1.Text + "' ne appartient aucune Location dans le systeme", "Ereur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                o.dr.Close();
            }
            else
            {
                MessageBox.Show("Veuillez Selectionner une Voiture avant de Cliquer Imprimer", "Ereur", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
    }
}

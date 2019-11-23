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
    public partial class ChoisirLocateurForImpLocation : Form
    {
        MyTools o = new MyTools();
        public ChoisirLocateurForImpLocation()
        {
            InitializeComponent();
        }
        public void RemplirLocateurs()
        {
            o.da = new SqlDataAdapter("Select * from Locateurs order by NomComplete", o.cn);
            o.da.Fill(o.ds, "Locateurs");
            comboBox2.DataSource = o.ds.Tables["Locateurs"];
            comboBox2.DisplayMember = "NomComplete";
            comboBox2.ValueMember = "IdLocateur";
            comboBox2.SelectedIndex = -1;
        }

        private void comboBox2_SelectionChangeCommitted(object sender, EventArgs e)
        {
            o.conex();
            o.cmd = new SqlCommand("Select * from Locateurs where IdLocateur = '" + comboBox2.SelectedValue + "'", o.cn);
            o.dr = o.cmd.ExecuteReader();
            while (o.dr.Read())
            {
                textBox9.Text = o.dr[0].ToString();
                Locateur1.Text = o.dr[2].ToString();
                textBox10.Text = Convert.ToDateTime(o.dr[4].ToString()).ToLongDateString(); ;
                locateur2.Text = o.dr[5].ToString();
                Locateur3.Text = o.dr[6].ToString();
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
        private void ChoisirLocateurForImpLocation_Load(object sender, EventArgs e)
        {

            textBox9.Focus();
            RemplirLocateurs();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox2.SelectedIndex != -1)
            {
                o.conex();
                o.cmd = new SqlCommand("select * from Locations where IdLocateur = '" + textBox9.Text.ToString() + "'", o.cn);
                o.dr = o.cmd.ExecuteReader();
                if (o.dr.HasRows)
                {
                    this.Hide();
                    ImpLocateurForLocation i = new ImpLocateurForLocation(textBox9.Text.ToString());
                    i.ShowDialog();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Le Locateur '" + comboBox2.Text + "' ne appartient aucune Location dans le systeme", "Ereur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                o.dr.Close();
            }
            else
            {
                MessageBox.Show("Veuillez Selectionner un Locateur avant de Cliquer Imprimer", "Ereur", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }
    }
}

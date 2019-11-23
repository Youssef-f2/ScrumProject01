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
    public partial class ModifierDispoVoiture : Form
    {
        MyTools o = new MyTools();
        public ModifierDispoVoiture()
        {
            InitializeComponent();
        }
        public void RemplirVoitures()
        {
            o.da = new SqlDataAdapter("Select * from Voitures  order by Marque", o.cn);
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
                textBox8.Text = o.dr[9].ToString();
            }
            o.dr.Close();
            if(textBox7.Text=="Oui")
            {
                button3.Enabled = false;
                button3.BackColor = Color.Gray;
                button4.Enabled = true;
                button4.BackColor = ColorTranslator.FromHtml("#BFCDDB"); ;
                textBox7.Text = "Oui";
                textBox7.Focus();
            }
            else if (textBox7.Text == "Non")
            {
                button3.Enabled = true;
                button3.BackColor = ColorTranslator.FromHtml("#BFCDDB");
                button4.Enabled = false;
                button4.BackColor = Color.Gray;
            }
        }

        private void ChoisirVoitureForImpLocation_Load(object sender, EventArgs e)
        {
            RemplirVoitures();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {


            

        }

        private void button3_Click(object sender, EventArgs e)
        {

            button3.Enabled = false;
            button3.BackColor = Color.Gray;
            button4.Enabled = true;
            button4.BackColor = ColorTranslator.FromHtml("#BFCDDB"); ;
            textBox7.Text = "Oui";
            textBox7.Focus();
            o.conex();
            o.cmd = new SqlCommand("Update Voitures set Disponibilite = '" + textBox7.Text.ToString() + "' where IdVoiture = '" + textBox1.Text + "'", o.cn);
            o.cmd.ExecuteNonQuery();
            o.Deconex();
            MessageBox.Show("Modification Effectue", "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);


        }

        private void button4_Click(object sender, EventArgs e)
        {
            button3.Enabled = true;
            button3.BackColor = ColorTranslator.FromHtml("#BFCDDB");
            button4.Enabled = false;
            button4.BackColor = Color.Gray;
            textBox7.Text = "Non";
            textBox7.Focus();
            o.conex();
            o.cmd = new SqlCommand("Update Voitures set Disponibilite = '" + textBox7.Text.ToString() + "' where IdVoiture = '" + textBox1.Text + "'", o.cn);
            o.cmd.ExecuteNonQuery();
            o.Deconex();
            MessageBox.Show("Modification Effectue", "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
    }
}

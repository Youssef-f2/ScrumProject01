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
    public partial class LoginOublie : Form
    {
        MyTools o = new MyTools();
        public LoginOublie()
        {
            InitializeComponent();
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                o.conex();
                SqlCommand cmd = new SqlCommand("Select * from Identification where Email = '" + textBox1.Text.ToLower() + "'", o.cn);
                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                o.Deconex();
                if (dt.Rows.Count != 0)
                {

                    textBox2.Text = dt.Rows[0][6].ToString();
                }
                else
                {
                    MessageBox.Show("Le Email : '" + textBox1.Text + "' \n" + "Ne appartient a aucun untilisateur", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                MessageBox.Show("Veuillez saisir votre E-mail", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            o.conex();
            SqlCommand cmd = new SqlCommand("Select * from Identification where QuestionDeSecurite = '" + textBox2.Text + "' and Reponse = '" + textBox3.Text.ToUpper() + "'", o.cn);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            o.Deconex();
            if (dt.Rows.Count != 0)
            {
                label1.Visible = false;
                label2.Visible = false;
                label3.Visible = false;
                label4.Visible = true;
                label5.Visible = true;
                label6.Visible = true;
                textBox1.Clear();
                textBox1.Enabled = false;
                textBox1.Text = dt.Rows[0][0].ToString();
                textBox2.ReadOnly = false;
                textBox2.Clear();
                textBox3.Clear();
                button1.Visible = false;
                button2.Visible = true;
            }
            else
            {
                MessageBox.Show("Votre reponse au question a ete incorrct \nRessayer a nouveau", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                textBox3.Clear();
                textBox3.Focus();
            }
        }

        private void LoginOublie_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != textBox3.Text)
            {
                MessageBox.Show("Veuillez saisir le meme Mot de passe dans les deux champs", "Mod de passe incorrct", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox2.Clear();
                textBox3.Clear();
                textBox2.Focus();
            }
            else
            {
                o.conex();
                o.cmd = new SqlCommand("Update Identification set MotDePasse ='" + textBox2.Text + "' where Identifiant = '" + textBox1.Text + "'", o.cn);
                o.cmd.ExecuteNonQuery();
                MessageBox.Show("Votre mot de passe a ete bien change", "Changement effectue", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Application.Restart();
            }
        }
    }
}

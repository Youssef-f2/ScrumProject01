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
    public partial class AjouterUtilisateur : Form
    {
        MyTools o = new MyTools();
        public AjouterUtilisateur()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox6.Text == "" || textBox7.Text == "" || comboBox1.SelectedIndex==-1 || comboBox2.SelectedIndex==-1 )
            {
                MessageBox.Show("Veuillez remplir tout les champs avant de Ajouter", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                o.conex();
                o.cmd = new SqlCommand("Select * from Identification where Identifiant = '" + textBox3.Text + "'", o.cn);
                o.dr = o.cmd.ExecuteReader();
                
                if(o.dr.HasRows==true)
                {
                    MessageBox.Show("Le Identifiant "+textBox3.Text+" Appartient deja a un Utilisateur", "Ajoute echoue", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox3.Focus();

                }
                else
                {
                    o.dr.Close();
                    o.cmd = new SqlCommand("Insert into Identification values ('" + textBox3.Text + "','" + textBox7.Text + "','" + textBox1.Text + "', '" + textBox4.Text + "','" + comboBox2.Text + "','" + textBox2.Text + "', '" + comboBox1.Text + "','" + textBox6.Text.ToUpper() + "')", o.cn);
                    o.cmd.ExecuteNonQuery();
                    MessageBox.Show("Utilisateur bien ajoute", "Ajoute avec succes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    o.Deconex();
                    Utilisateurs U = new Utilisateurs();
                    U.ShowDialog();
                    this.Close();
                }
            }

        }



        private void AjouterUtilisateur_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Utilisateurs U = new Utilisateurs();
            U.ShowDialog();
            this.Close();
        }
        private void button1_MouseEnter(object sender, EventArgs e)
        {
            pictureBox2.BackColor = System.Drawing.Color.LightSteelBlue;
            button1.BackColor = System.Drawing.Color.LightSteelBlue;

        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackColor = ColorTranslator.FromHtml("#BFCDDB");
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

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

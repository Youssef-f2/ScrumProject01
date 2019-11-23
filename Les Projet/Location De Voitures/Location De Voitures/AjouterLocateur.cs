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
    public partial class AjouterLocateur : Form
    {
        MyTools o = new MyTools();
        public AjouterLocateur()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable dta = new DataTable();

            if (textBox1.Text == "" || textBox2.Text == "" || textBox7.Text == "" || textBox8.Text == "")
            {
                MessageBox.Show("Veuillez remplir tout les champs", "Ajoute Echouee", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else 
            {
                o.conex();
                o.cmd = new SqlCommand("Select * from Locateurs where CIN = '" + textBox2.Text + "' or NomComplete ='" + textBox7.Text + "'", o.cn);
                o.dr = o.cmd.ExecuteReader();
                dta.Load(o.dr);
                o.Deconex();

                if (dta.Rows.Count == 0)
                {
                    o.conex();
                    o.cmd = new SqlCommand("Insert into Locateurs values ('" + textBox2.Text + "','" + textBox7.Text + "','" + dateTimePicker1.Text.ToString() + "','" + textBox1.Text + "','" + textBox8.Text + "')", o.cn);
                    o.cmd.ExecuteNonQuery();
                    MessageBox.Show("Locateur Bien Ajoutee", "Ajoute Reussi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    o.Deconex();
                    this.Close();
                }
                else 
                {
                    MessageBox.Show("Le Nom ou Le CIN que vous avez saisie appartient deja a un Locateur ", "Ajoute Echouee", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
          }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Locateurs L = new Locateurs();
            L.ShowDialog();
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
        private void AjouterLocateurDansLocation_Load(object sender, EventArgs e)
        {

        }
    }
       
    }


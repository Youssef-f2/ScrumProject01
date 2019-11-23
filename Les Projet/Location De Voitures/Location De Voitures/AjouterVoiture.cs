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
    public partial class AjouterVoiture : Form
    {
        MyTools o = new MyTools();
        public AjouterVoiture()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {

            if (textBox2.Text == "" || textBox3.Text == "Ex : 0000|X|00" || comboBox3.SelectedIndex == -1 || comboBox2.SelectedIndex == -1 || textBox7.Text == "" )
            {
                MessageBox.Show("Soyez sure que tout les champs sont remplit " + "\n" + "Avant de cliquer Ajouter", "Ajoute echoue", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                o.conex();
                o.cmd = new SqlCommand("insert into Voitures values('" + textBox2.Text + "','" + textBox3.Text + "','" + Convert.ToInt32(numericUpDown2.Value)+" Places" + "','" + comboBox3.SelectedItem.ToString() + "','" + comboBox2.SelectedItem.ToString() + "','" + textBox7.Text + "','" + "Oui"+ "','" + Convert.ToInt32(numericUpDown1.Value) +" DH" + "')", o.cn);
                o.cmd.ExecuteNonQuery();
                MessageBox.Show("Voiture Bien Ajoutee", "Ajoute Reussi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                o.Deconex();
                this.Hide();
                Voitures VA = new Voitures();
                VA.ShowDialog();
                this.Close();
            }

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

        private void textBox3_Enter(object sender, EventArgs e)
        {
            if (textBox3.Text != "")
            {
                textBox3.Text = "";
                textBox3.ForeColor = Color.Black;
            }
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            if (textBox3.Text == "")
            {
                textBox3.Text = "Ex : 0000|X|00";
                textBox3.ForeColor = Color.Gray;
            }

        }

        private void AjouterVoiture_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Voitures V = new Voitures();
            V.ShowDialog();
            this.Close();
        }

        private void textBox8_Move(object sender, EventArgs e)
        {

        }


    }
    }


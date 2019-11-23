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
using System.Threading;

namespace Location_De_Voitures
{
    public partial class Login : Form
    {
        Thread th;
        MyTools o = new MyTools();
        string loged;
        public Login()
        {
            InitializeComponent();
        }

        private void userControl11_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        public void opemformAdmine(object obj)
        {
            Application.Run(new ADM(loged));
        }
        public void opemformUser(object obj)
        {
            Application.Run(new UserMenu(loged));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            o.conex();
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("Select * from Identification where Identifiant ='" + txtid.Text + "'and MotDePasse ='" + txtpassword.Text + "'", o.cn);
            SqlDataReader dr = cmd.ExecuteReader();
            dt.Load(dr);

            if (dt.Rows.Count != 0)
            {
                loged = dt.Rows[0][1].ToString() + " " + dt.Rows[0][2].ToString();

                if (dt.Rows[0][4].ToString() == "Admin")
                {
                    this.Close();
                    th = new Thread(opemformAdmine);
                    th.SetApartmentState(ApartmentState.STA);
                    th.Start();

                }
                else
                {
                    this.Close();
                    th = new Thread(opemformUser);
                    th.SetApartmentState(ApartmentState.STA);
                    th.Start();
                }
            }
            else
            {
                label4.Visible = true;
                txtpassword.Text = "";
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            LoginOublie LO = new LoginOublie();
            LO.ShowDialog();
            this.Close();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            txtpassword.UseSystemPasswordChar = true;
            label4.Visible = false;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                txtpassword.UseSystemPasswordChar = false;

            }
            else
                txtpassword.UseSystemPasswordChar = true;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            o.conex();
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("Select * from Identification where Identifiant ='" + txtid.Text + "'and MotDePasse ='" + txtpassword.Text + "'", o.cn);
            SqlDataReader dr = cmd.ExecuteReader();
            dt.Load(dr);

            if (dt.Rows.Count != 0)
            {
                loged = dt.Rows[0][1].ToString() + " " + dt.Rows[0][2].ToString();

                if (dt.Rows[0][4].ToString() == "Admin")
                {
                    this.Close();
                    th = new Thread(opemformAdmine);
                    th.SetApartmentState(ApartmentState.STA);
                    th.Start();

                }
                else
                {
                    this.Close();
                    th = new Thread(opemformUser);
                    th.SetApartmentState(ApartmentState.STA);
                    th.Start();
                }
            }
            else
            {
                label4.Visible = true;
                txtpassword.Text = "";
            }

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }
    }
}

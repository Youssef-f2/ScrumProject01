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
    public partial class ML2 : Form
    {
        MyTools o = new MyTools();
        string a, b, c, er ,f;
        DateTime D1, D2;
        public ML2(string IdLocation,string IdVoiture,string IdLocateur,string NbrJours, string Prix , DateTime DL , DateTime DS)
        {
            InitializeComponent();
            a = IdLocation;
            b = IdVoiture;
            c = IdLocateur;
            er = NbrJours;
            f = Prix;
            D1 = DL;
            D2 = DS;
        }
        public void Loc()
        {
            o.conex();
            o.cmd = new SqlCommand("Select * from Locateurs where IdLocateur = '" + c + "'", o.cn);
            o.dr = o.cmd.ExecuteReader();
            while (o.dr.Read())
            {
                textBox9.Text = o.dr[0].ToString();
                Locateur1.Text = o.dr[2].ToString();
                textBox11.Text = o.dr[3].ToString();
           
                textBox12.Text = Convert.ToDateTime(o.dr[4].ToString()).ToLongDateString() ;
                locateur2.Text = o.dr[5].ToString();
                Locateur3.Text = o.dr[6].ToString();
            }
            o.dr.Close();
        }
        public void Vo()
        {
            o.conex();
            o.cmd = new SqlCommand("Select * from Voitures where Idvoiture = '" + b + "'", o.cn);
            o.dr = o.cmd.ExecuteReader();
            while (o.dr.Read())
            {
                textBox1.Text = o.dr[0].ToString();
                textBox10.Text = o.dr[2].ToString();
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
        private void NouvelleLocation_Load(object sender, EventArgs e)
        {
            DateLocation.Text = D1.ToLongDateString() ;
            DateSoumission.MinDate = Convert.ToDateTime(D1.AddDays(1).ToShortDateString());
            DateSoumission.Text = D2.ToLongDateString();
            Jours.Text = er ;
            PT.Text = f;
            Loc();
            Vo();  
        }

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectionChangeCommitted(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            DateSoumission.Enabled = true;

        }

        private void DateSoumission_ValueChanged(object sender, EventArgs e)
        {
            DateTime a;
            DateTime b;
            a = DateSoumission.Value;
            b = DateLocation.Value;
            Jours.Text = (a - b).TotalDays.ToString()+" Jours";


        }

        private void Jours_TextChanged(object sender, EventArgs e)
        {
   

        }

        private void Jours_Click(object sender, EventArgs e)
        {

        }

        private void Jours_TextChanged_1(object sender, EventArgs e)
        {
            if ((!string.IsNullOrEmpty(Jours.Text)) && (!string.IsNullOrEmpty(textBox8.Text)))
            {
                int i = Jours.Text.IndexOf(" ");
                string hh = Jours.Text.Substring(0,i);
                int ii = textBox8.Text.IndexOf(" ");
                string hhhh = textBox8.Text.Substring(0, ii);


                PT.Text = Convert.ToString(Convert.ToInt32(hh) * Convert.ToInt32(hhhh)) + " DH";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            o.conex();
            o.cmd = new SqlCommand("Update Locations set DateSoumission = '" + DateSoumission.Text + "' , NombreDeJour = '" + Jours.Text + "', PrixTotal = '" + PT.Text + "' where IdLocation = '" + a + "'", o.cn);
            o.cmd.ExecuteNonQuery();
            o.Deconex();
            MessageBox.Show("Votre location a ete bien Modifier, La Fiche de Location est bientot pret", "Location Modifie", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Hide();
            ImpressionLocationModifie p = new ImpressionLocationModifie(a, b, c);
            p.ShowDialog();

            this.Close();

        }


    }
}

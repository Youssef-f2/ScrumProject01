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
    public partial class NouvelleLocation : Form
    {
        MyTools o = new MyTools();
        public NouvelleLocation()
        {
            InitializeComponent();
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }
        public void RemplirVoitures()
        {
            o.da = new SqlDataAdapter("Select * from Voitures Where Disponibilite = 'Oui' order by Marque", o.cn);
            o.da.Fill(o.ds, "Voitures");
            comboBox1.DataSource = o.ds.Tables["Voitures"];
            comboBox1.DisplayMember = "Marque";
            comboBox1.ValueMember = "IdVoiture";
            comboBox1.SelectedIndex = -1;
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
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
       
            comboBox2.Enabled = true;
            button1.Enabled = true;
            if ((!string.IsNullOrEmpty(Jours.Text)) && (!string.IsNullOrEmpty(textBox8.Text)))
            {
                int i = Jours.Text.IndexOf(" ");
                string hh = Jours.Text.Substring(0, i);
                int ii = textBox8.Text.IndexOf(" ");
                string hhhh = textBox8.Text.Substring(0, ii);

                PT.Text = Convert.ToString(Convert.ToInt32(hh) * Convert.ToInt32(hhhh))+" DH";
            }

        }
        private void NouvelleLocation_Load(object sender, EventArgs e)
        {
            RemplirVoitures();
            RemplirLocateurs();
            DateLocation.Text = DateTime.Now.ToLongDateString();
            DateSoumission.MinDate = Convert.ToDateTime(DateTime.Now.AddDays(1).ToShortDateString());
            comboBox2.Enabled = false;
            DateSoumission.Enabled = false;


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



        private void Jours_TextChanged_1(object sender, EventArgs e)
        {
            if ((!string.IsNullOrEmpty(Jours.Text)) && (!string.IsNullOrEmpty(textBox8.Text)))
            {
                int i = Jours.Text.IndexOf(" ");
                string hh = Jours.Text.Substring(0, i);
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
            if (comboBox1.SelectedIndex ==-1)
            {
                MessageBox.Show("Veuillez selectionner la voiture a louer", "Impossible de confirmer la location", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if(comboBox2.SelectedIndex==-1)
            {
                MessageBox.Show("Veuillez selectionner le locateur", "Impossible de confirmer la location", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DataTable dt = new DataTable();
                o.conex();
                o.cmd = new SqlCommand("Select * from Locations where IdVoiture = '" + textBox1.Text + "' and IdLocateur = '" + textBox9.Text + "' and DateLocation = '" +DateLocation.Text.ToString() + "'", o.cn);
                o.dr = o.cmd.ExecuteReader();
                dt.Load(o.dr);
                o.Deconex();
                if(dt.Rows.Count!=0)
                {
                    MessageBox.Show("Cette Location existe deja dans le systeme", "Impossible De Confirmer La Location", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    o.conex();
                    o.cmd = new SqlCommand("Insert into Locations values ('" + textBox1.Text + "','" + textBox9.Text + "','" + comboBox1.Text.ToString() + "','" + comboBox2.Text.ToString() + "','" + DateLocation.Text.ToString()+"','"+ DateSoumission.Text.ToString() + "','"+Jours.Text+"','"+PT.Text+"')", o.cn);
                    o.cmd.ExecuteNonQuery();

                    o.cmd2 = new SqlCommand("Update Voitures Set Disponibilite = 'Non' Where IdVoiture = '" + textBox1.Text + "'",o.cn);
                    o.cmd2.ExecuteNonQuery();
                    o.Deconex();
                    MessageBox.Show("Votre location a ete bien ajouter au systeme , La Fiche de Location est bientot pret", "Location Enregistere", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                    ImprimerLastLocation NL = new ImprimerLastLocation();
                    NL.ShowDialog();
                    this.Close();

                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            AjouterClient AC = new AjouterClient();
            AC.ShowDialog();
            this.Close();
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Veuillez selectionner la voiture a louer", "Impossible de confirmer la location", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (comboBox2.SelectedIndex == -1)
            {
                MessageBox.Show("Veuillez selectionner le locateur", "Impossible de confirmer la location", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DataTable dt = new DataTable();
                o.conex();
                o.cmd = new SqlCommand("Select * from Locations where IdVoiture = '" + textBox1.Text + "' and IdLocateur = '" + textBox9.Text + "' and DateLocation = '" + DateLocation.Text.ToString() + "'", o.cn);
                o.dr = o.cmd.ExecuteReader();
                dt.Load(o.dr);
                o.Deconex();
                if (dt.Rows.Count != 0)
                {
                    MessageBox.Show("Cette Location existe deja dans le systeme", "Impossible De Confirmer La Location", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    o.conex();
                    o.cmd = new SqlCommand("Insert into Locations values ('" + textBox1.Text + "','" + textBox9.Text + "','" + comboBox1.Text.ToString() + "','" + comboBox2.Text.ToString() + "','" + DateLocation.Text.ToString() + "','" + DateSoumission.Text.ToString() + "','" + Jours.Text + "','" + PT.Text + "')", o.cn);
                    o.cmd.ExecuteNonQuery();

                    o.cmd2 = new SqlCommand("Update Voitures Set Disponibilite = 'Non' Where IdVoiture = '" + textBox1.Text + "'", o.cn);
                    o.cmd2.ExecuteNonQuery();
                    o.Deconex();
                    MessageBox.Show("Votre location a ete bien ajouter au systeme , La Fiche de Location est bientot pret", "Location Enregistere", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                    ImprimerLastLocation NL = new ImprimerLastLocation();
                    NL.ShowDialog();
                    this.Close();

                }
            }

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
    }
}

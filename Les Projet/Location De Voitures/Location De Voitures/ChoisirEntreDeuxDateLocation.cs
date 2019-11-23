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
    public partial class ChoisirEntreDeuxDateLocation : Form
    {
        MyTools o = new MyTools();
        public ChoisirEntreDeuxDateLocation()
        {
            InitializeComponent();
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

        private void ChoisirParDateLocation_Load(object sender, EventArgs e)
        {
            
            dateTimePicker2.MinDate = DateTime.Now.AddDays(1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DateTime a = Convert.ToDateTime(dateTimePicker1.Value);
            string sqlformat = a.Date.ToString("yyyy-MM-dd");
            DateTime b = Convert.ToDateTime(dateTimePicker2.Value);
            string sqlformat2 = b.Date.ToString("yyyy-MM-dd");

            o.conex();
            o.cmd = new SqlCommand("Select * from Locations where DateLocation between '" + sqlformat + "' and '"+sqlformat2+"'", o.cn);
            o.dr = o.cmd.ExecuteReader();
            if (o.dr.HasRows)
            {
                this.Hide();
                ImpEntreDeuxDateLocation imp = new ImpEntreDeuxDateLocation(sqlformat,sqlformat2);
                imp.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Aucune Location est dans le systeme entre la date '" + sqlformat +"' Et '"+sqlformat2+"'", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            o.Deconex();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker2.MinDate = dateTimePicker1.Value.AddDays(1);
        }
    }
}

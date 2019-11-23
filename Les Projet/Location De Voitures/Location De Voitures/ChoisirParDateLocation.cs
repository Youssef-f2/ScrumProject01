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
    public partial class ChoisirParDateLocation : Form
    {
        MyTools o = new MyTools();
        public ChoisirParDateLocation()
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
            monthCalendar1.TodayDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DateTime a = Convert.ToDateTime(monthCalendar1.SelectionRange.Start.ToShortDateString());
            string sqlformat = a.Date.ToString("yyyy-MM-dd");

            o.conex();
            o.cmd = new SqlCommand("Select * from Locations where DateLocation = '" + sqlformat + "'", o.cn);
            o.dr = o.cmd.ExecuteReader();
            if (o.dr.HasRows)
            {
                this.Hide();
                ImpParDateLocation imp = new ImpParDateLocation(sqlformat);
                imp.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Aucune Location est dans le systeme a la date " + monthCalendar1.SelectionRange.Start.ToShortDateString(), "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            o.Deconex();
        }
    }
}

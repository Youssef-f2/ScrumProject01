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
    
    public partial class UserMenu : Form
    {
        string v;
        MyTools o = new MyTools();
        public UserMenu(string vv)
        {
            InitializeComponent();
            
            v = vv;
        }

        private void userToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void UserMenu_Load(object sender, EventArgs e)
        {
            label3.Text= "Loged in as : " + v.ToString() + " (User)";

        }



        private void pictureBox4_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Voulez-vous se deconneter ?","Confirmation",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
            {
                Application.Restart();
            }
        }

        private void ajouterUneVoitureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AjouterVoiture2 a = new AjouterVoiture2();
            a.ShowDialog();
        }

        private void locateursToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void ajouterUnLocateurToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AjouterLocateur a = new AjouterLocateur();
            a.ShowDialog();
        }

        private void rechercherUnLocateurToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RechercherLocateurs a = new RechercherLocateurs();
            a.ShowDialog();
        }

        private void modifierUneLocationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ModifierLocation a = new ModifierLocation();
            a.ShowDialog();
        }

        private void rechercherUneLocationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RechercherLocation a = new RechercherLocation();
            a.ShowDialog();
        }

        private void nouvelleLocationToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void nouvelleLocationToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            NouvelleLocation a = new NouvelleLocation();
            a.ShowDialog();
        }

        private void toutLesVoituresToolStripMenuItem_Click(object sender, EventArgs e)
        {

            o.conex();
            o.cmd = new SqlCommand("Select * from Voitures", o.cn);
            SqlDataReader dr = o.cmd.ExecuteReader();
            if (dr.HasRows)
            {
                ImpListeVoitures a = new ImpListeVoitures();
                a.ShowDialog();
            }
            else
            {
                MessageBox.Show("Aucune Voiture est en base actuellement", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.None);
            }
            dr.Close();
            o.Deconex();
            
        }

        private void voituresDisponibleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            o.conex();
            o.cmd = new SqlCommand("Select * from Voitures where Disponibilite = 'Oui'", o.cn);
            SqlDataReader dr = o.cmd.ExecuteReader();
            if (dr.HasRows)
            {
                ImpListeVoitures a = new ImpListeVoitures();
                a.ShowDialog();
            }
            else
            {
                MessageBox.Show("Aucune Voiture est Disponible actuellement", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.None);
            }
            dr.Close();
            o.Deconex();
        }

        private void listeDesLocateursToolStripMenuItem_Click(object sender, EventArgs e)
        {
            o.conex();
            o.cmd = new SqlCommand("Select * from Locateurs", o.cn);
            SqlDataReader dr = o.cmd.ExecuteReader();
            if (dr.HasRows)
            {
                ImpListeLocateurs a = new ImpListeLocateurs();
                a.ShowDialog();
            }
            else
            {
                MessageBox.Show("Aucun Locateur est en base actuellement", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.None);
            }
            dr.Close();
            o.Deconex();
        }

        private void voituresEnLocationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            o.conex();
            o.cmd = new SqlCommand("Select * from Voitures where Disponibilite = 'Non'", o.cn);
            SqlDataReader dr = o.cmd.ExecuteReader();
            if (dr.HasRows)
            {
                ImpListeVoitures a = new ImpListeVoitures();
                a.ShowDialog();
            }
            else
            {
                MessageBox.Show("Aucune Voiture est en Location actuellement", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.None);
            }
            dr.Close();
            o.Deconex();
        }

        private void locationsDuneVoitureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChoisirVoitureForImpLocation a = new ChoisirVoitureForImpLocation();
            a.ShowDialog();
        }

        private void locationsDunLocateurToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChoisirLocateurForImpLocation a = new ChoisirLocateurForImpLocation();
            a.ShowDialog();
        }

        private void ficheDeLocationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ImprimerLocation a = new ImprimerLocation();
            a.ShowDialog();

           
        }

        private void listeDesLocationsDuneDateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChoisirParDateLocation a = new ChoisirParDateLocation();
            a.ShowDialog();
        }

        private void listeDesLocationsEntreDeuxDatesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChoisirEntreDeuxDateLocation a = new ChoisirEntreDeuxDateLocation();
            a.ShowDialog();
        }

        private void menuVoituresToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Voitures v = new Voitures();
            v.ShowDialog();
        }

        private void menuVoituresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Locateurs a = new Locateurs();
            a.ShowDialog();
        }
    }
}

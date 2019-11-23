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
    
    public partial class ImpListeVoitures : Form
    {
        MyTools o = new MyTools();
        
        public ImpListeVoitures( )
        {
            InitializeComponent();
     
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            ListeVoiture i = new ListeVoiture();

            crystalReportViewer1.ReportSource = i;
            crystalReportViewer1.Refresh();
            o.Deconex();





            this.Cursor = Cursors.Default;

        }
    }
}

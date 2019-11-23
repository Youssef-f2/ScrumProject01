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
    
    public partial class ImpListeLocateurs : Form
    {
        MyTools o = new MyTools();
        
        public ImpListeLocateurs( )
        {
            InitializeComponent();
     
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

           ListeLocateurs i = new ListeLocateurs();

            crystalReportViewer1.ReportSource = i;
            crystalReportViewer1.Refresh();


            this.Cursor = Cursors.Default;

        }
    }
}

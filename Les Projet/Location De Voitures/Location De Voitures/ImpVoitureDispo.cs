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
    
    public partial class ImpVoitureDispo : Form
    {
        MyTools o = new MyTools();
        
        public ImpVoitureDispo()
        {
            InitializeComponent();
          
            
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            o.conex();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ImpVoitureDispo";
            cmd.Connection = o.cn;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt2 = new DataTable();
            da.Fill(dt2);

            
            VoitureDispo i = new VoitureDispo();
            i.SetDataSource(dt2);
            crystalReportViewer1.ReportSource = i;
            crystalReportViewer1.Refresh();
            o.Deconex();





            this.Cursor = Cursors.Default;

        }
    }
}

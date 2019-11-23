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
    
    public partial class ImpEntreDeuxDateLocation : Form
    {
        MyTools o = new MyTools();
        string x,y;
        public ImpEntreDeuxDateLocation(string a,string b)
        {
            InitializeComponent();
            x = a;
            y = b;
           
            
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            o.conex();
            SqlCommand cmd = new SqlCommand();
            SqlParameter[] par = new SqlParameter[2];
            par[0] = new SqlParameter("@d", SqlDbType.Date);
            par[0].Value = x;
            par[1] = new SqlParameter("@d2", SqlDbType.Date);
            par[1].Value = y;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ImpEntreDeuxDateLocation";
            cmd.Connection = o.cn;
            cmd.Parameters.Add(par[0]);
            cmd.Parameters.Add(par[1]);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt2 = new DataTable();
            da.Fill(dt2);
            LocationEntreDeuxDateLocation i = new LocationEntreDeuxDateLocation();
            i.SetDataSource(dt2);
            crystalReportViewer1.ReportSource = i;
            crystalReportViewer1.Refresh();
            o.Deconex();





            this.Cursor = Cursors.Default;

        }
    }
}

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
    
    public partial class Test : Form
    {
        MyTools o = new MyTools();
        string b;
        public Test( string a)
        {
            InitializeComponent();
            b = a;
            
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            o.conex();
            SqlCommand cmd = new SqlCommand();
            SqlParameter[] par = new SqlParameter[1];
            par[0] = new SqlParameter("@i", SqlDbType.VarChar, 50);
            par[0].Value = b;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ImpLoca";
            cmd.Connection = o.cn;
            cmd.Parameters.Add(par[0]);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt2 = new DataTable();
            da.Fill(dt2);
            imploc i = new imploc();
            i.SetDataSource(dt2);
            crystalReportViewer1.ReportSource = i;
            crystalReportViewer1.Refresh();
            o.Deconex();





            this.Cursor = Cursors.Default;

        }
    }
}

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
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace Location_De_Voitures
{
    public partial class ImpressionLocationModifie : Form
    {
        MyTools o = new MyTools();
        string a;
        public ImpressionLocationModifie(string IdLocation, string IdVoiture, string IdLocateur)
        {
            a = IdLocation;

            InitializeComponent();
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            o.conex();
            SqlCommand cmd = new SqlCommand();
            SqlParameter[] par = new SqlParameter[1];
            par[0] = new SqlParameter("@i", SqlDbType.VarChar, 50);
            par[0].Value = a;
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

        private void ImpressionLocationModifie_Load(object sender, EventArgs e)
        {

        }


    }
}

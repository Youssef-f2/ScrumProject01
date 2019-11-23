using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace Location_De_Voitures
{
    public partial class ImprimerLastLocation : Form
    {
        MyTools o = new MyTools();
        public ImprimerLastLocation()
        {
            InitializeComponent();
        }

        private void ImprimerLastLocation_Load(object sender, EventArgs e)
        {
           
   
            
            
            
        }
        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {
            o.conex();
            DataSet datas = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter("Select * from LastLocation ", o.cn);
            da.Fill(datas, "Loc");
            SqlDataAdapter da2 = new SqlDataAdapter("Select * from LastLocationVoiture ", o.cn);
            da2.Fill(datas, "V");
            SqlDataAdapter da3 = new SqlDataAdapter("Select * from LastLocationLocateur ", o.cn);
            da3.Fill(datas, "Loct");


            LastLoc LA = new LastLoc();
            LA.SetDataSource(datas);
            crystalReportViewer1.ReportSource = LA;
            crystalReportViewer1.Refresh();
            o.Deconex();




        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Location_De_Voitures
{
    class MyTools
    {
        public SqlConnection cn = new SqlConnection(@"Data source = DESKTOP-IE2CIBB; Initial Catalog = LocationDesVoitures ;Integrated Security = True ");
        public SqlCommand cmd = new SqlCommand();
        public SqlCommand cmd2 = new SqlCommand();
        public SqlDataReader dr;
        public SqlDataAdapter da;
        public DataSet ds = new DataSet();
        public DataTable dt = new DataTable();


        public void conex() 
        {
            if (cn.State == ConnectionState.Closed || cn.State == ConnectionState.Broken)
            {
                cn.Open();
            }
        }
        public void Deconex()
        {
            if (cn.State == ConnectionState.Open)
            {
                cn.Close();
            }
        }


    }
}

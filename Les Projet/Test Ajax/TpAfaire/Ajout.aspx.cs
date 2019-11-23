using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
namespace TpAfaire
{
    public partial class Ajout  : System.Web.UI.Page
    {
        SqlConnection cn  = new SqlConnection(@"Data Source=DESKTOP-T447BOK\YOUSSEF;Initial Catalog=TestAjax;Integrated Security=True");
        string cin, nom, prenom, op;
        protected void Page_Load(object sender, EventArgs e)
        {
            op = Request.QueryString["op"].ToString();
            if (op == "insert")
            {
                cn.Open();
                cin = Request.QueryString["CIN"].ToString();
                nom = Request.QueryString["NOM"].ToString();
                prenom = Request.QueryString["PRENOM"].ToString();
                SqlCommand cmd = new SqlCommand("insert into Personne values('" + cin.ToString() + "','" + nom.ToString() + "','" + prenom.ToString() + "')", cn);
               cmd.ExecuteNonQuery();
                cn.Close();
            }
            if (op == "afficher")
            {
                cn.Open();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter("select * from Personne", cn);
                da.Fill(dt);
                Response.Write("<table border='1'>");
                Response.Write("<tr>");
                Response.Write("<th width='130px'>"); Response.Write("CIN"); Response.Write("</th>");
                Response.Write("<th width='130px'>"); Response.Write("NOM"); Response.Write("</th>");
                Response.Write("<th width='130px'>"); Response.Write("PRENOM"); Response.Write("</th>");
                Response.Write("</tr>");

                foreach (DataRow dr in dt.Rows)
                {
                    Response.Write("<tr>");
                    Response.Write("<td>"); Response.Write(dr[0].ToString()); Response.Write("</td>");
                    Response.Write("<td>"); Response.Write(dr[1].ToString()); Response.Write("</td>");
                    Response.Write("<td>"); Response.Write(dr[2].ToString()); Response.Write("</td>");
                    Response.Write("</tr>");
                }
                Response.Write("</table>");
                cn.Close();
            }
            if(op == "rechercher")
            {
                //nom = Request.QueryString["rec"].ToString();
                cn.Open();
                SqlCommand cmd = cn.CreateCommand();
                cmd.CommandType = CommandType.Text;

                cmd.CommandText = "select* from Personne where cin ='" + cin+ "'";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                Response.Write("<table border='1'>");
                Response.Write("<tr>");
                Response.Write("<td> width='100px'>"); Response.Write("cn");
                Response.Write("<td> width='100px'>");
                Response.Write("<td> width='100px'>");

            }
            if (op == "supprimer")
            {
                cn.Open();
                SqlCommand cmd = cn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "delete from Personne where cin='" + cin + "'";
                cmd.Connection = cn;
                cmd.ExecuteNonQuery();
                DataTable   dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);

                Response.Write("<table border='1'>");
                Response.Write("<tr>");
                Response.Write("<th width='130px'>"); Response.Write("cin"); Response.Write("</th>");
                Response.Write("<th width='130px'>"); Response.Write("nom"); Response.Write("</th>");
                Response.Write("<th width='130px'>"); Response.Write("prenom"); Response.Write("</th>");
                Response.Write("</tr>");

                foreach (DataRow dr in dt.Rows)
                {

                    Response.Write("<tr>");
                    Response.Write("<td>"); Response.Write(dr[0].ToString()); Response.Write("</td>");
                    Response.Write("<td>"); Response.Write(dr[1].ToString()); Response.Write("</td>");
                    Response.Write("<td>"); Response.Write(dr[2].ToString()); Response.Write("</td>");
                    Response.Write("</tr>");
                }

                Response.Write("</table>");
                cn.Close();
            }

            if (op == "modifier")
            {
                cn.Open();
                 SqlCommand cmd = cn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "update Personne set nom='" + nom.ToString() + "',prenom='" + prenom.ToString() + "' where cin='" + cin.ToString() + "'";
                cmd.Connection = cn;
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                 SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);

                Response.Write("<table border='1'>");
                Response.Write("<tr>");
                Response.Write("<th width='130px'>"); Response.Write("cin"); Response.Write("</th>");
                Response.Write("<th width='130px'>"); Response.Write("nom"); Response.Write("</th>");
                Response.Write("<th width='130px'>"); Response.Write("prenom"); Response.Write("</th>");
                Response.Write("</tr>");

                foreach (DataRow dr in dt.Rows)
                {

                    Response.Write("<tr>");
                    Response.Write("<td>"); Response.Write(dr[0].ToString()); Response.Write("</td>");
                    Response.Write("<td>"); Response.Write(dr[1].ToString()); Response.Write("</td>");
                    Response.Write("<td>"); Response.Write(dr[2].ToString()); Response.Write("</td>");
                    Response.Write("</tr>");
                }

                Response.Write("</table>");
                cn.Close();
            }
        }
    }
}
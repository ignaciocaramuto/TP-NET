using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace UI.Web
{
    public partial class ReportePlanesViewer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Server=localhost;Database=academia;Trusted_Connection=True; User=sa; Password=123");
            SqlCommand cmd = new SqlCommand("select p.desc_plan, e.desc_especialidad from planes p inner join especialidades e on p.id_especialidad=e.id_especialidad", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sda.Fill(ds);

            ReportDocument crp = new ReportDocument();
            crp.Load(Server.MapPath("reporte/ReportePlanes.rpt"));
            crp.SetDataSource(ds.Tables["table"]);

            crvPlanes.ReportSource = crp;

            crp.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, "Reporte de cursos");
        }
    }
}
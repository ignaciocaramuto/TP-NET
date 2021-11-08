using Business.Entities;
using Business.Logic;
using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CrystalDecisions.Shared;

namespace UI.Web
{
    public partial class ReporteCursosViewer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Server=localhost;Database=academia;Trusted_Connection=True; User=sa; Password=123");
            SqlCommand cmd = new SqlCommand("select comi.desc_comision, m.desc_materia, c.anio_calendario from cursos c inner join materias m on c.id_materia = m.id_materia inner join comisiones comi on c.id_comision = comi.id_comision", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sda.Fill(ds);

            ReportDocument crp = new ReportDocument();
            crp.Load(Server.MapPath("reporte/ReporteCursos.rpt"));
            crp.SetDataSource(ds.Tables["table"]);

            crvCursos.ReportSource = crp;

            crp.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, "Reporte de cursos");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//using Microsoft.Reporting.WebForms;
using MaestroDetalleEntidad.Datos;

namespace MaestroDetalleEntidad
{
    public partial class WebVenta : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {

                //int id = int.Parse(Session["impreventa"].ToString());

                /*using (proyectoEntities db = new proyectoEntities())
                {
                    var lst = from d in db.DetalleVenta
                              join c1 in db.Venta on d.IdVenta equals c1.Id join z1 in db.producto on d.IdProducto equals z1.id join w1 in db.Cliente on c1.IdCliente equals w1.id
                              where d.IdVenta==id
                              orderby (d.Id) descending
                              select new { d.IdVenta, d.IdProducto,d.Cantidad,d.Precio,d.Monto,z1.nombre,c1.fecha,c1.glosa, NCliente = w1.nombre }; //SELECT * FROM CATEGORIA
                    
                

               
                
                */

                //ReportParameter[] p = new ReportParameter[1];
                //p[0] = new ReportParameter("empresa", "UPDS");




                //this.ReportViewer1.LocalReport.ReportEmbeddedResource = "MaestroDetalleEntidad.RVenta.rdlc";

                //this.ReportViewer1.LocalReport.DataSources.Clear();


                //ReportDataSource rp = new ReportDataSource("DataSet1", lst.ToList());
                //this.ReportViewer1.LocalReport.DataSources.Add(rp);
                //this.ReportViewer1.LocalReport.SetParameters(p);
                //this.ReportViewer1.LocalReport.Refresh();
               }
            }
        }
    }

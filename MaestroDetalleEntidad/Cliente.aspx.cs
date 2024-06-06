using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MaestroDetalleEntidad.Datos;

namespace MaestroDetalleEntidad
{
    public partial class Cliente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {



        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (this.TextBox1.Text == "")
                Response.Write("No Busco");
            else
            {
                using (proyectoEntities1 db = new proyectoEntities1())
                {

                    Datos.Cliente o = new Datos.Cliente();
                    o.id = int.Parse(this.TextBox1.Text);
                    o.nit = this.TextBox2.Text;
                    o.nombre = this.TextBox3.Text;
                    o.Fono = this.TextBox4.Text;
                    o.direccion = this.TextBox5.Text;

                    db.Cliente.Add(o);
                    db.SaveChanges();
                    string p = Session["Pagina"].ToString();
                    Response.Redirect(p);

                    
                }
            }
        }
    }
}
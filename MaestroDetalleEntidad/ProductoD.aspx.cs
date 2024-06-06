using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MaestroDetalleEntidad.Datos;

namespace MaestroDetalleEntidad
{
    public partial class ProductoD : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
// este es un medoto que actualiza

        public void refreshdata()
        {
            string t = this.TextBox1.Text;

            using (proyectoEntities db = new proyectoEntities())
            {
                var lst = from d in db.producto
                          where d.nombre.Contains(t)
                          select new { d.id, d.nombre, d.pventa, d.stock }; //SELECT * FROM CATEGORIA
                this.GridView1.DataSource = lst.ToList();
                this.GridView1.DataBind();
                //this.dataGridView1.Columns[2].Visible = false;
            }





        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            string cadena;
            if (this.TextBox1.Text != "")
            {
                //cadena = "select Producto.id,Producto.nombre,Producto.pventa,Producto.stock from Producto where nombre like '%" + this.TextBox1.Text + "%'";
                this.refreshdata();
            }
            else
                Response.Write("Error");
        }

        protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            this.TextBox2.Text = this.GridView1.Rows[e.NewSelectedIndex].Cells[1].Text;
            this.TextBox3.Text = this.GridView1.Rows[e.NewSelectedIndex].Cells[2].Text;
            this.TextBox5.Text = this.GridView1.Rows[e.NewSelectedIndex].Cells[3].Text;
            this.TextBox4.Focus();
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            if (this.TextBox1.Text != "" && this.TextBox4.Text != "")
            {
                double monto1 = double.Parse(this.TextBox4.Text) * double.Parse(this.TextBox5.Text);
                this.TextBox6.Text = monto1.ToString();
                string cadena;
                string id, nombre, cantidad, precio, monto;
                id = this.TextBox2.Text;
                nombre = this.TextBox3.Text;
                precio = this.TextBox5.Text;
                cantidad = this.TextBox4.Text;
                monto = this.TextBox6.Text;

                using (proyectoEntities db = new proyectoEntities())
                {

                    Datos.DetalleVentaTemporal o = new Datos.DetalleVentaTemporal();
                    o.IdProducto = int.Parse(id);
                    o.Nombre = nombre;
                    o.Precio = decimal.Parse(precio);
                    o.Cantidad = decimal.Parse(cantidad);
                    o.Monto = decimal.Parse(monto);
                    o.Usuario = Session["usuario"].ToString();
                    o.Maquina = Session["maquina"].ToString();

                    db.DetalleVentaTemporal.Add(o);
                    db.SaveChanges();
                    Session["Montot"] = (double.Parse(Session["Montot"].ToString()) + monto1).ToString();
                    Response.Redirect("Ventas.aspx");
                }





            }
            else
                Response.Write("Error Producto no Seleccionado");
        }
    }
}
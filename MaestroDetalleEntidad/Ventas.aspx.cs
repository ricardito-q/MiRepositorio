using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MaestroDetalleEntidad.Datos;

namespace MaestroDetalleEntidad
{
    public partial class Ventas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {

                CargarListBox();
                if (Session["usuario"] != null && Session["maquina"] != null)
                {
                    if (Session["IdVenta"] != null)
                    {
                        this.TextBox1.Text = Session["IdVenta"].ToString();
                        this.TextBox2.Text = Session["Fecha"].ToString();
                        this.TextBox3.Text = Session["Glosa"].ToString();
                        if (Session["IdCliente"] != null)
                            this.ListBox1.SelectedValue = Session["IdCliente"].ToString();
                    }
                    else
                        this.EliminarTemporal();



                    this.refreshdata();
                    if (Session["Montot"] != null)
                        this.Label6.Text = Session["Montot"].ToString();
                }

            }

        }

        private void EliminarTemporal()
        {
            string u = Session["usuario"].ToString();
            string m = Session["maquina"].ToString();

            using (proyectoEntities1 db = new proyectoEntities1())
            {


                var detallet = (from c in db.DetalleVentaTemporal
                                where c.Usuario == u && c.Maquina == m
                                select c).ToList();
                //List<DetalleVentaTemporal> listadetalle = new List<DetalleVentaTemporal>();
                //listadetalle = detallet.ToList();



                if (detallet.Count > 0)
                {
                    for (int i = 0; i < detallet.Count; i++)
                    {
                        DetalleVentaTemporal detalle = detallet[i];
                        db.DetalleVentaTemporal.Remove(detalle);
                    }
                    db.SaveChanges();
                }











            }



        }


        public void refreshdata()
        {

            string u = Session["usuario"].ToString();
            string m = Session["maquina"].ToString();

            this.GridView1.Columns[0].Visible = true;
            using (proyectoEntities1 db = new proyectoEntities1())
            {
                var lst = from d in db.DetalleVentaTemporal
                          where d.Usuario == u && d.Maquina == m
                          select new { d.Id, d.IdProducto, d.Nombre, d.Cantidad, d.Precio, d.Monto }; //SELECT * FROM CATEGORIA
                this.GridView1.DataSource = lst.ToList();
                this.GridView1.DataBind();
                this.GridView1.Columns[0].Visible = false;
            }



            this.GridView1.Columns[0].Visible = false;


        }

        private void CargarListBox()
        {

            using (proyectoEntities1 db = new proyectoEntities1())
            {
                var lst = from d in db.Cliente

                          orderby (d.nombre)
                          select new { d.id, d.nombre }; //SELECT * FROM CATEGORIA

                //this.ListBox1.Items.AddRange(lst.ToArray());

                this.ListBox1.DataSource = lst.ToList();
                this.ListBox1.DataTextField = "nombre";
                this.ListBox1.DataValueField = "Id";
                this.ListBox1.DataBind();
                //this.dataGridView1.Columns[2].Visible = false;
            }



        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string id;
            string monto;
            id = this.GridView1.Rows[e.RowIndex].Cells[1].Text;
            monto = this.GridView1.Rows[e.RowIndex].Cells[6].Text;

            using (proyectoEntities1 db = new proyectoEntities1())
            {
                Datos.DetalleVentaTemporal o = new Datos.DetalleVentaTemporal();
                o= db.DetalleVentaTemporal.Find(int.Parse(id));
                if (o == null)
                    Response.Write("Error no Existe");
                else
                {


                    db.DetalleVentaTemporal.Remove(o);
                    db.SaveChanges();
                    Session["Montot"] = (double.Parse(Session["Montot"].ToString()) - double.Parse(monto)).ToString();
                    this.Label6.Text = Session["Montot"].ToString();
                    refreshdata();
                }


            }


            
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            string cadena;
            string m = System.Net.Dns.GetHostName();
            // System.Net.h hostEntry = System.Net.Dns.GetHostName();

            Session["Idventa"] = this.TextBox1.Text;
            Session["Fecha"] = this.TextBox2.Text;
            Session["IdCliente"] = this.ListBox1.SelectedValue;
            Session["Glosa"] = this.TextBox3.Text;


            Session["montot"] = this.Label6.Text;
            Response.Redirect("ProductoD.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Session["Pagina"] = "Ventas.aspx";
            Response.Redirect("Cliente.aspx");
        }

        private bool Insertar()
        {
            bool sw = true;
            string idproducto;
            string cantidad;
            string precio;
            string monto;
            // string []detalle=new string[1000];
            string detalle1;
            string cabe;
            string id = this.TextBox1.Text;
            DateTime fecha = DateTime.Parse(this.TextBox2.Text);
            string idcliente = this.ListBox1.SelectedValue;
            string glosa = this.TextBox3.Text;

            using (proyectoEntities1 db = new proyectoEntities1())
            {

                Datos.Venta o = new Datos.Venta();
                o.Id = int.Parse(this.TextBox1.Text);
                o.fecha = fecha;
                o.IdCliente = int.Parse(idcliente);
                o.glosa = glosa;
               

                db.Venta.Add(o);
                //db.SaveChanges();

                for (int i = 0; i < this.GridView1.Rows.Count; i++)
                {
                    idproducto = this.GridView1.Rows[i].Cells[2].Text;
                    cantidad = this.GridView1.Rows[i].Cells[4].Text;
                    precio = this.GridView1.Rows[i].Cells[5].Text;
                    monto = this.GridView1.Rows[i].Cells[6].Text;

                    Datos.DetalleVenta odv = new Datos.DetalleVenta();
                    odv.IdVenta = int.Parse(this.TextBox1.Text);
                    odv.IdProducto = int.Parse(idproducto);
                    odv.Cantidad = decimal.Parse(cantidad);
                    odv.Precio = decimal.Parse(precio);
                    odv.Monto = decimal.Parse(monto);
                    db.DetalleVenta.Add(odv);
                    
                    
                }

                db.SaveChanges();
                this.EliminarTemporal();
                


            }

            return true;




            
        }



        protected void Button1_Click(object sender, EventArgs e)
        {
            if (this.TextBox1.Text == "")
            {
                Response.Write("No ingreso Código");
            }
            else
            {
                if (this.TextBox2.Text == "")
                {
                    Response.Write("No ingreso Fecha");
                }
                else
                {
                    if (this.ListBox1.SelectedIndex < 0)
                    {
                        Response.Write("No selecciono Cliente");
                    }
                    else
                    {
                        if (this.GridView1.Rows.Count == 0)
                        {
                            Response.Write("No adiciono Productos");
                        }
                        else
                        {
                            //insertar
                            if (this.Insertar() == true)
                            {
                                this.Label7.Text = "Dato Grabado";
                                this.Label7.Visible = true;
                                this.Button1.Enabled = false;
                                Session["Idventa"] = null;
                                Session["Fecha"] = null;
                                Session["IdCliente"] = null;
                                Session["Glosa"] = null;
                                Response.Redirect("BusVenta.aspx");
                                ;
                            }


                        }
                    }


                }

            }
        }

    }
}
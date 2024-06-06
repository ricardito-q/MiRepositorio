using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MaestroDetalleEntidad.Datos;

namespace MaestroDetalleEntidad
{
    public partial class ModificarVenta : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                this.CargarListBox();
                this.CargarVenta();

                //string cadena = "select Venta.Id,fecha,nombre as NCliente from venta inner join cliente on (venta.idcliente=cliente.id) order by Venta.id desc";
                //this.refreshdata(cadena);


            }

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

        public void refreshdata()
        {

            int idventa = int.Parse(this.TextBox1.Text); 
            

            this.GridView1.Columns[0].Visible = true;
            using (proyectoEntities1 db = new proyectoEntities1())
            {
                var lst = from d in db.DetalleVenta join p in db.producto on d.IdProducto equals p.id
                          where d.IdVenta ==idventa 
                          orderby(d.Id)
                          select new { d.Id, d.IdProducto, p.nombre, d.Cantidad, d.Precio, d.Monto }; //SELECT * FROM CATEGORIA
                this.GridView1.DataSource = lst.ToList();
                this.GridView1.DataBind();
                this.GridView1.Columns[0].Visible = false;
            }



            this.GridView1.Columns[0].Visible = false;


        }


        private void CargarVenta()
        {
            int idventa = int.Parse(Session["IdVenta"].ToString());
            using (proyectoEntities1 db = new proyectoEntities1())
            {
                Datos.Venta oventa = new Datos.Venta();
                oventa = db.Venta.Find(idventa);
                if (oventa == null)
                    Response.Write("Venta no Existe");
                else
                {
                    DateTime fecha = DateTime.Parse(oventa.fecha.ToString());
                    this.TextBox1.Text = oventa.Id.ToString();
                    this.TextBox2.Text = fecha.ToShortDateString();
                    this.ListBox1.SelectedValue = oventa.IdCliente.ToString();
                    this.TextBox3.Text = oventa.glosa;
                    this.refreshdata();

                    double total = 0;
                    for (int i = 0; i < this.GridView1.Rows.Count; i++)
                    {
                        total = total + double.Parse(this.GridView1.Rows[i].Cells[6].Text);

                    }

                    this.Label6.Text = total.ToString();
                    Session["Montot"] = total.ToString();


                }


            }



            

            



        }

        private bool Modificar()
        {
            bool sw = true;

            DateTime fecha = DateTime.Parse(this.TextBox2.Text);
            using (proyectoEntities1 db = new proyectoEntities1())
            {
                Datos.Venta  oventa = new Datos.Venta();
                oventa = db.Venta.Find(int.Parse(this.TextBox1.Text));
                if (oventa == null)
                    Response.Write("Venta no Existe");
                else
                {
                    oventa.Id = int.Parse(this.TextBox1.Text);
                    oventa.fecha = fecha;
                    oventa.IdCliente = int.Parse(this.ListBox1.SelectedValue);
                    oventa.glosa = this.TextBox3.Text;

                    db.SaveChanges();


                }


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
                            if (this.Modificar() == true)
                            {
                                this.Label7.Text = "Dato Grabado";
                                this.Label7.Visible = true;
                                this.Button1.Enabled = false;
                                Response.Redirect("BusVenta.aspx");
                            }


                        }
                    }


                }

            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Session["Idventa"] = this.TextBox1.Text;
            Session["Fecha"] = this.TextBox2.Text;
            Session["IdCliente"] = this.ListBox1.SelectedValue;
            Session["Glosa"] = this.TextBox3.Text;


            Session["montot"] = this.Label6.Text;
            Response.Redirect("ProductoModi.aspx");
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string id;
            string monto;
            id = this.GridView1.Rows[e.RowIndex].Cells[1].Text;
            monto = this.GridView1.Rows[e.RowIndex].Cells[6].Text;

            int id1 = int.Parse(id);
            using (proyectoEntities1 db = new proyectoEntities1())
            {
                Datos.DetalleVenta o = new Datos.DetalleVenta();
                var lst = (from d in db.DetalleVenta
                           where d.Id == id1
                           select d).FirstOrDefault();
                o = lst;
                if (o == null)
                    Response.Write("Error no Existe");
                else
                {


                    db.DetalleVenta.Remove(o);
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

        protected void Button2_Click(object sender, EventArgs e)
        {
            Session["Pagina"] = "ModificarVenta.aspx";
            Response.Redirect("Cliente.aspx");
        }
    }
}
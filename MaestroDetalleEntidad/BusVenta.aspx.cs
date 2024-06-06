using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MaestroDetalleEntidad.Datos;

namespace MaestroDetalleEntidad
{
    public partial class BusVenta : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {



                this.refreshdata();


            }

        }

        public void refreshdata()
        {

            using (proyectoEntities1 db = new proyectoEntities1())
            {
                var lst = from d in db.Venta
                          join c1 in db.Cliente on d.IdCliente equals c1.id
                          orderby (d.Id) descending
                          select new { d.Id, d.fecha, NCliente = c1.nombre }; //SELECT * FROM CATEGORIA
                this.GridView1.DataSource = lst.ToList();
                this.GridView1.DataBind();
                //this.dataGridView1.Columns[2].Visible = false;
            }





        }

        public void BuscarFechas()
        {
            DateTime t1 = DateTime.Parse(this.TextBox2.Text);
            DateTime t2 = DateTime.Parse(this.TextBox3.Text);

            using (proyectoEntities1 db = new proyectoEntities1())
            {
                var lst = from d in db.Venta
                          join c1 in db.Cliente on d.IdCliente equals c1.id
                          where d.fecha >= t1 && d.fecha <= t2
                          orderby (d.Id) descending

                          select new { d.Id, d.fecha, NCliente = c1.nombre }; //SELECT * FROM CATEGORIA
                this.GridView1.DataSource = lst.ToList();
                this.GridView1.DataBind();
                //this.dataGridView1.Columns[2].Visible = false;
            }





        }

        public void BuscarId()
        {
            int t = int.Parse(this.TextBox1.Text);
            using (proyectoEntities1 db = new proyectoEntities1())
            {
                var lst = from d in db.Venta
                          join c1 in db.Cliente on d.IdCliente equals c1.id
                          where d.Id == t
                          orderby (d.Id) descending

                          select new { d.Id, d.fecha, NCliente = c1.nombre }; //SELECT * FROM CATEGORIA
                this.GridView1.DataSource = lst.ToList();
                this.GridView1.DataBind();
                //this.dataGridView1.Columns[2].Visible = false;
            }





        }

        protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.RadioButtonList1.Items[0].Selected == true)
            {
                this.Label2.Visible = true;
                this.TextBox1.Visible = true;
                this.TextBox1.Text = "";

                this.Label3.Visible = false;
                this.Label4.Visible = false;
                this.TextBox2.Visible = false;
                this.TextBox3.Visible = false;

            }
            else
            {
                this.Label2.Visible = false;
                this.TextBox1.Visible = false;
                this.Label3.Visible = true;
                this.Label4.Visible = true;
                this.TextBox2.Visible = true;
                this.TextBox3.Visible = true;

                this.TextBox2.Text = "";
                this.TextBox3.Text = "";

            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {


            if (this.RadioButtonList1.Items[0].Selected == true)
            {
                if (this.TextBox1.Text == "")
                    Response.Write("Error introduzca el id");
                else
                {
                    //cadena = "select Venta.Id,fecha,nombre as NCliente from venta inner join cliente on (venta.idcliente=cliente.id) where Venta.id=" + this.TextBox1.Text;
                    this.BuscarId();
                }
            }
            else
            {
                if (this.TextBox2.Text == "" || this.TextBox3.Text == "")
                    Response.Write("Error introduzca la fecha inicial o la fecha final");
                else
                {
                    //cadena = "select Venta.Id,fecha,nombre as NCliente from venta inner join cliente on (venta.idcliente=cliente.id) where fecha>='" + this.TextBox2.Text + "' and fecha<='" + this.TextBox3.Text + "'";
                    this.BuscarFechas();
                }

            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            this.refreshdata();
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            string m = System.Net.Dns.GetHostName();
            Session["usuario"] = "adm";
            Session["maquina"] = m;

            Session["Idventa"] = null;
            Session["Fecha"] = null;
            Session["IdCliente"] = null;
            Session["Glosa"] = null;

            Response.Redirect("Ventas.aspx");
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            string id;
            id = this.GridView1.Rows[e.NewEditIndex].Cells[1].Text;
            Session["IdVenta"] = id;
            Response.Redirect("ModificarVenta.aspx");
        }

        protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            string id = this.GridView1.Rows[e.NewSelectedIndex].Cells[1].Text;
            Session["impreventa"] = id;
            Response.Redirect("WebVenta.aspx");
        }
    }
}
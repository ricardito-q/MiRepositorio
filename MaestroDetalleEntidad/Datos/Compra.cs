//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MaestroDetalleEntidad.Datos
{
    using System;
    using System.Collections.Generic;
    
    public partial class Compra
    {
        public Compra()
        {
            this.DetalleCompra = new HashSet<DetalleCompra>();
        }
    
        public int Id { get; set; }
        public Nullable<System.DateTime> fecha { get; set; }
        public string glosa { get; set; }
        public Nullable<int> IdProveedor { get; set; }
    
        public virtual Proveedor Proveedor { get; set; }
        public virtual ICollection<DetalleCompra> DetalleCompra { get; set; }
    }
}

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
    
    public partial class producto
    {
        public producto()
        {
            this.DetalleCompra = new HashSet<DetalleCompra>();
            this.DetalleVenta = new HashSet<DetalleVenta>();
        }
    
        public int id { get; set; }
        public string nombre { get; set; }
        public Nullable<decimal> pcosto { get; set; }
        public Nullable<decimal> pventa { get; set; }
        public Nullable<decimal> stock { get; set; }
        public Nullable<int> IdCategoria { get; set; }
    
        public virtual categoria categoria { get; set; }
        public virtual ICollection<DetalleCompra> DetalleCompra { get; set; }
        public virtual ICollection<DetalleVenta> DetalleVenta { get; set; }
    }
}
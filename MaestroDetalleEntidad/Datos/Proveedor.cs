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
    
    public partial class Proveedor
    {
        public Proveedor()
        {
            this.Compra = new HashSet<Compra>();
        }
    
        public int id { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Contacto { get; set; }
    
        public virtual ICollection<Compra> Compra { get; set; }
    }
}

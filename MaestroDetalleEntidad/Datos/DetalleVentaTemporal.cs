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
    
    public partial class DetalleVentaTemporal
    {
        public int Id { get; set; }
        public Nullable<int> IdProducto { get; set; }
        public string Nombre { get; set; }
        public Nullable<decimal> Cantidad { get; set; }
        public Nullable<decimal> Precio { get; set; }
        public Nullable<decimal> Monto { get; set; }
        public string Usuario { get; set; }
        public string Maquina { get; set; }
    }
}

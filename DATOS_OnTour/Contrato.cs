//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DATOS_OnTour
{
    using System;
    using System.Collections.Generic;
    
    public partial class Contrato
    {
        public string ID_Contrato { get; set; }
        public string Destino { get; set; }
        public string Valor_Contrato { get; set; }
        public Nullable<System.DateTime> Fecha_Salida { get; set; }
        public Nullable<System.DateTime> Fecha_llegada { get; set; }
        public string Escuela { get; set; }
        public int N_alumnos { get; set; }
        public string ID_seguro { get; set; }
        public string Run_Emp { get; set; }
    
        public virtual Empleados Empleados { get; set; }
        public virtual Seguro Seguro { get; set; }
    }
}

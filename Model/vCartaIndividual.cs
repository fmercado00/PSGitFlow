//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ImssAnalysis.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class vCartaIndividual
    {
        public int IdCartaIndividual { get; set; }
        public Nullable<int> IdRegistroPatronal { get; set; }
        public string RegistroPatronal { get; set; }
        public string NombreCompania { get; set; }
        public string FechaIngreso { get; set; }
        public string FechaEgreso { get; set; }
        public int IdSolicitud { get; set; }
        public Nullable<System.DateTime> DFechaIngreso { get; set; }
        public Nullable<System.DateTime> DFechaEgreso { get; set; }
    }
}

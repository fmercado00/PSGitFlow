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
    
    public partial class ReferenciasLaboralesD
    {
        public int IdReferenciaLaboralD { get; set; }
        public Nullable<int> IdReferenciaLaboral { get; set; }
        public string NombreEmpresa { get; set; }
        public string Sucursal { get; set; }
        public string Outsourcing { get; set; }
        public string MarcaAsignada { get; set; }
        public string GiroEmpresa { get; set; }
        public string DomicilioLaboral { get; set; }
        public string PuestoDesempeñado { get; set; }
        public Nullable<System.DateTime> FechaIngreso { get; set; }
        public Nullable<System.DateTime> FechaEgreso { get; set; }
        public string MotivoSalida { get; set; }
        public string CartaRecomendacion { get; set; }
        public string JefeInmediato { get; set; }
        public string Telefonos { get; set; }
        public string Observaciones { get; set; }
    
        public virtual ReferenciasLaborales ReferenciasLaborales { get; set; }
    }
}

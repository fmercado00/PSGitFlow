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
    
    public partial class ReferenciasLaborales
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ReferenciasLaborales()
        {
            this.ReferenciasLaboralesD = new HashSet<ReferenciasLaboralesD>();
        }
    
        public int IdReferenciaLaboral { get; set; }
        public string EstadoCivil { get; set; }
        public Nullable<System.DateTime> FechaAnteriorIngreso { get; set; }
        public string FamiliaenEmpresa { get; set; }
        public string Observaciones { get; set; }
        public Nullable<int> IdSolicitud { get; set; }
        public Nullable<System.DateTime> FechaAnteriorEgreso { get; set; }
        public string TrabajoAntesEmpresa { get; set; }
    
        public virtual Solicitudes Solicitudes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ReferenciasLaboralesD> ReferenciasLaboralesD { get; set; }
    }
}

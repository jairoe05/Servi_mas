//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Web_Page.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class TranferenciasSM
    {
        public int codtranferencia { get; set; }
        public Nullable<long> CodigoCuenta { get; set; }
        public int TelefonoAF { get; set; }
        public Nullable<decimal> MontoR { get; set; }
        public Nullable<int> TelefonoAR { get; set; }
        public Nullable<System.DateTime> Fecha { get; set; }
    
        public virtual Cuenta Cuenta { get; set; }
    }
}

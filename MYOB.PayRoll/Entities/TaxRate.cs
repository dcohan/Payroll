//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MYOB.PayRoll.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class TaxRate
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TaxRate()
        {
            this.Payrolls = new HashSet<Payroll>();
        }
    
        public int Id { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
        public int GrossIncomeBase { get; set; }
        public int GrossIncomeTop { get; set; }
        public int TaxRate1 { get; set; }
        public System.DateTimeOffset CreationDateTime { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Payroll> Payrolls { get; set; }
    }
}

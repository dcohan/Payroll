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
    using System.ComponentModel.DataAnnotations;

    public partial class Payroll
    {
        public int Id { get; set; }

        [Range(2010, 2020)]
        public int Year { get; set; }
        [Range(1, 12)]
        public int Month { get; set; }
        public Nullable<System.DateTimeOffset> PaidDate { get; set; }
        public int WorkedDays { get; set; }
        public System.DateTimeOffset CreationDateTime { get; set; }
        public int EmployeeIncomeId { get; set; }
        public int TaxRateId { get; set; }
    
        public virtual EmployeeIncome EmployeeIncome { get; set; }
        public virtual TaxRate TaxRate { get; set; }
    }
}

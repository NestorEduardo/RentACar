//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RentACar
{
    using System;
    using System.Collections.Generic;
    
    public partial class Rent
    {
        public int Id { get; set; }
        public Nullable<int> EmployeeId { get; set; }
        public Nullable<int> CarId { get; set; }
        public Nullable<int> CustomerId { get; set; }
        public Nullable<System.DateTime> RentalDate { get; set; }
        public Nullable<System.DateTime> ReturnDate { get; set; }
        public decimal AmountPerDay { get; set; }
        public int Days { get; set; }
        public string Comments { get; set; }
        public Nullable<int> RentStatusId { get; set; }
        public bool Status { get; set; }
    
        public virtual Car Car { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual RentStatu RentStatu { get; set; }
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace storeManager.DataAccess
{
    using System;
    using System.Collections.Generic;
    
    public partial class Purchase
    {
        public string InvoiceNumber { get; set; }
        public string SupplierID { get; set; }
        public decimal PurchaseAmount { get; set; }
        public System.DateTime PurchaseDate { get; set; }
        public Nullable<decimal> AmountPaid { get; set; }
        public Nullable<decimal> Balance { get; set; }
        public Nullable<int> StoreID { get; set; }
        public string PurchaseType { get; set; }
        public string EmployeeID { get; set; }
        public Nullable<int> PurchasetypeID { get; set; }
        public string DetailedAccountID { get; set; }
        public string BillState { get; set; }
        public Nullable<decimal> Discount { get; set; }
        public Nullable<decimal> Tax { get; set; }
        public Nullable<System.DateTime> PromisedDate { get; set; }
        public Nullable<System.DateTime> DateClosed { get; set; }
        public string PurchaseOrderNo { get; set; }
    }
}

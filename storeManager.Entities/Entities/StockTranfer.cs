//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace storeManager.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class StockTranfer
    {
        public int StockTranferID { get; set; }
        public Nullable<int> FromLocationID { get; set; }
        public Nullable<int> FromLocationQtyBeforeTranfer { get; set; }
        public Nullable<int> FromLocationQtyAfterTransfer { get; set; }
        public Nullable<int> ToLocationID { get; set; }
        public Nullable<int> ToLocationBeforeTransfer { get; set; }
        public Nullable<int> ToLocationAfterTranfer { get; set; }
        public Nullable<int> ProductID { get; set; }
        public Nullable<int> UserID { get; set; }
        public Nullable<System.DateTime> TransferDate { get; set; }
        public Nullable<int> TransferQty { get; set; }
    }
}

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
    
    public partial class AccessRight
    {
        public int Id { get; set; }
        public string FormID { get; set; }
        public Nullable<int> UserID { get; set; }
        public Nullable<bool> CanView { get; set; }
        public Nullable<bool> CanEdit { get; set; }
    }
}

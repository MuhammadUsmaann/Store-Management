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
    
    public partial class BackupDetail
    {
        public int BackupID { get; set; }
        public Nullable<System.DateTime> BackupDate { get; set; }
        public string BackupFolder { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public string Comments { get; set; }
        public short UserID { get; set; }
    }
}

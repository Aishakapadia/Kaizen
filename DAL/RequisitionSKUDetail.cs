//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace UFS_Application.DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class RequisitionSKUDetail
    {
        public int RequisitionSKUDetailId { get; set; }
        public Nullable<int> RequisitionId { get; set; }
        public string SKUCode { get; set; }
        public Nullable<bool> IsActive { get; set; }
    
        public virtual Requisition Requisition { get; set; }
    }
}

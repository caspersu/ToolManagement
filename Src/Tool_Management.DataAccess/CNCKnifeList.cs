//------------------------------------------------------------------------------
// <auto-generated>
//     這個程式碼是由範本產生。
//
//     對這個檔案進行手動變更可能導致您的應用程式產生未預期的行為。
//     如果重新產生程式碼，將會覆寫對這個檔案的手動變更。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Tool_Management.DataAccess
{
    using System;
    using System.Collections.Generic;
    
    public partial class CNCKnifeList
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CNCKnifeList()
        {
            this.ProductionPlans = new HashSet<ProductionPlan>();
        }
    
        public decimal CNCKnifeList_ID { get; set; }
        public string CNC_IP { get; set; }
        public string Car_No { get; set; }
        public string Good_ID { get; set; }
        public string Line_No { get; set; }
        public string WorkStation_No { get; set; }
        public string KnifeList_ID { get; set; }
        public System.DateTime CNCList_Create_DT { get; set; }
        public string CNCList_Create_ID { get; set; }
        public string CNCList_Modify_DT { get; set; }
        public string CNCList_Modify_ID { get; set; }
    
        public virtual CNC CNC { get; set; }
        public virtual Good Good { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductionPlan> ProductionPlans { get; set; }
    }
}

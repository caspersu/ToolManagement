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
    
    public partial class ExtRodMaster
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ExtRodMaster()
        {
            this.ExtRodDetails = new HashSet<ExtRodDetail>();
        }
    
        public string ExtensionRodMaster_ID { get; set; }
        public string ExtensionRod_Name { get; set; }
        public string ExtensionRod_Brand { get; set; }
        public string ExtensionRod_Spec { get; set; }
        public long ExtensionRod_Quality { get; set; }
        public string ExtensionRod_CabinID { get; set; }
        public string ExtensionRodMaster_Create_ID { get; set; }
        public Nullable<System.DateTime> ExtensionRodMaster_Create_DT { get; set; }
        public string ExtensionRodMaster_Modify_ID { get; set; }
        public Nullable<System.DateTime> ExtensionRodMaster_Modify_DT { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ExtRodDetail> ExtRodDetails { get; set; }
    }
}

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
    
    public partial class KnifeMaster
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KnifeMaster()
        {
            this.KnifeDetails = new HashSet<KnifeDetail>();
        }
    
        public string KnifeMaster_ID { get; set; }
        public string Knife_Name { get; set; }
        public string Knife_Brand { get; set; }
        public string Knife_Spec { get; set; }
        public string Knife_CabinID { get; set; }
        public long Knife_Quality { get; set; }
        public System.DateTime KnifeMaster_Create_DT { get; set; }
        public string KnifeMaster_Create_ID { get; set; }
        public System.DateTime KnifeMaster_Modify_DT { get; set; }
        public string KnifeMaster_Modify_ID { get; set; }
        public string Knife_Kind { get; set; }
        public string Knife_Model { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KnifeDetail> KnifeDetails { get; set; }
    }
}

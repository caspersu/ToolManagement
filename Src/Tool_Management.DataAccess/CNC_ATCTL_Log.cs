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
    
    public partial class CNC_ATCTL_Log
    {
        public decimal Sno { get; set; }
        public string CNC_IP { get; set; }
        public string Create_DT { get; set; }
        public string ATCTL_ID { get; set; }
        public string ATCTL_NAME { get; set; }
        public string ATCTL_DATA { get; set; }
        public string ATCTL_GRP { get; set; }
        public Nullable<long> ATCTL_TIME { get; set; }
        public string ATCTL_TYPE { get; set; }
        public string ATCTL_COLOR { get; set; }
        public string KnifeDetail_ID { get; set; }
    
        public virtual CNC CNC { get; set; }
        public virtual KnifeDetail KnifeDetail { get; set; }
    }
}

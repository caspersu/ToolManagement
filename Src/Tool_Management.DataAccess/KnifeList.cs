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
    
    public partial class KnifeList
    {
        public string KnifeList_ID { get; set; }
        public string ATC_ID { get; set; }
        public string WorkStation_No { get; set; }
        public string Model_ID { get; set; }
        public string KnifeDetail_ID { get; set; }
        public string HiltDetail_ID { get; set; }
        public string NailDetail_ID { get; set; }
        public string MeasureDetail_ID { get; set; }
        public string ExtRodDetail_ID { get; set; }
        public string NutDetail_ID { get; set; }
        public string Collet1Detail_ID { get; set; }
        public string Collet2Detail_ID { get; set; }
        public System.DateTime KnifeList_Create_DT { get; set; }
        public string KnifeList_Create_ID { get; set; }
        public Nullable<System.DateTime> KnifeList_Modify_DT { get; set; }
        public string KnifeList_Modify_ID { get; set; }
        public string Program_No { get; set; }
        public string D { get; set; }
        public string R { get; set; }
        public string L { get; set; }
        public string CL { get; set; }
        public string FL { get; set; }
        public string SZ { get; set; }
        public string EZ { get; set; }
        public string Reserved { get; set; }
        public string Deep { get; set; }
        public string Way { get; set; }
        public Nullable<int> Time { get; set; }
        public string Memo { get; set; }
    
        public virtual Collet1Detail Collet1Detail { get; set; }
        public virtual Collet2Detail Collet2Detail { get; set; }
        public virtual ExtRodDetail ExtRodDetail { get; set; }
        public virtual HiltDetail HiltDetail { get; set; }
        public virtual KnifeDetail KnifeDetail { get; set; }
        public virtual MeasureDetail MeasureDetail { get; set; }
        public virtual NailDetail NailDetail { get; set; }
        public virtual NutDetail NutDetail { get; set; }
        public virtual Model Model { get; set; }
    }
}

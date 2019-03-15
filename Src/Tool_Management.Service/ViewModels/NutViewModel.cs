using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tool_Management.Service.ViewModels
{
    public class NutMasterViewModel
    {
        [DisplayName("螺帽/刀頭編號")]
        [Required]
        public string NutMaster_ID { get; set;}
        [DisplayName("螺帽/刀頭名稱")]
        [Required]
        public string Nut_Name { get; set; }
        [DisplayName("螺帽/刀頭廠牌")]
        [Required]
        public string Nut_Brand { get; set; }
        [DisplayName("螺帽/刀頭規格")]
        [Required]
        public string Nut_Spec { get; set; }
        [DisplayName("倉位")]
        [Required]
        public string Nut_CabinID { get; set; }
        [DisplayName("目前庫存數量")]
        [Required]
        public long Nut_Quality { get; set; }
        [DisplayName("建立人員ID")]       
        public string NutMaster_Create_ID { get; set; }
        [DisplayName("建立時間")]
        public DateTime NutMaster_Create_DT { get; set; }
        [DisplayName("修改人員ID")]
        public string NutMaster_Modify_ID { get; set; }
        [DisplayName("修改時間")]
        public DateTime NutMaster_Modify_DT { get; set; }
        [DisplayName("建立人員")]
        public string NutMaster_Create_Name { get; set; }
        [DisplayName("修改人員")]
        public string NutMaster_Modify_Name { get; set; }
    }

    public class NutDetailViewModel
    {
        [DisplayName("螺帽/刀頭編號")]
        [Required]
        public string NutMaster_ID { get; set; }
        [DisplayName("螺帽/刀頭序號")]
        [Required]
        public string NutDetail_ID { get; set; }
        [DisplayName("新品")]
        [Required]
        public string IsNewNut { get; set; }
        [DisplayName("新品領料時間")]
        [Required]
        public System.DateTime NewEnter_DT { get; set; }
        [DisplayName("螺帽/刀頭狀態")]
        [Required]
        public string NutDetail_Status { get; set; }

        [DisplayName("建立人員ID")]
        public string NutDetail_Create_ID { get; set; }
        [DisplayName("建立時間")]
        public DateTime NutDetail_Create_DT { get; set; }
        [DisplayName("修改人員ID")]
        public string NutDetail_Modify_ID { get; set; }
        [DisplayName("修改時間")]
        public DateTime NutDetail_Modify_DT { get; set; }
        [DisplayName("建立人員")]
        public string NutDetail_Create_Name { get; set; }
        [DisplayName("修改人員")]
        public string NutDetail_Modify_Name { get; set; }
    }
}

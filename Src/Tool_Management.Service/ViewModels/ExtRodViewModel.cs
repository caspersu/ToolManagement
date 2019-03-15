using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tool_Management.Service.ViewModels
{
    public class ExtRodMasterViewModel
    {
        [DisplayName("延長桿料號")]
        [Required]
        public string ExtRodMaster_ID { get; set;}
        [DisplayName("延長桿名稱")]
        [Required]
        public string ExtRod_Name { get; set; }
        [DisplayName("延長桿廠牌")]
        [Required]
        public string ExtRod_Brand { get; set; }
        [DisplayName("延長桿規格")]
        [Required]
        public string ExtRod_Spec { get; set; }
        [DisplayName("倉位")]
        [Required]
        public string ExtRod_CabinID { get; set; }
        [DisplayName("目前庫存數量")]
        [Required]
        public long ExtRod_Quality { get; set; }
        [DisplayName("建立人員ID")]       
        public string ExtRodMaster_Create_ID { get; set; }
        [DisplayName("建立時間")]
        public DateTime ExtRodMaster_Create_DT { get; set; }
        [DisplayName("修改人員ID")]
        public string ExtRodMaster_Modify_ID { get; set; }
        [DisplayName("修改時間")]
        public DateTime ExtRodMaster_Modify_DT { get; set; }

        [DisplayName("建立人員")]
        public string ExtRodMaster_Create_Name { get; set; }
        [DisplayName("修改人員")]
        public string ExtRodMaster_Modify_Name { get; set; }
    }

    public class ExtRodDetailViewModel
    {
        [DisplayName("延長桿料號")]
        [Required]
        public string ExtRodMaster_ID { get; set; }
        [DisplayName("延長桿編號")]
        [Required]
        public string ExtRodDetail_ID { get; set; }
        [DisplayName("新品")]
        [Required]
        public string IsNewExtRod { get; set; }
        [DisplayName("新品領料時間")]
        [Required]
        public System.DateTime NewEnter_DT { get; set; }
        [DisplayName("延長桿狀態")]
        [Required]
        public string ExtRodDetail_Status { get; set; }

        [DisplayName("建立人員")]
        public string ExtRodDetail_Create_ID { get; set; }
        [DisplayName("建立時間")]
        public DateTime ExtRodDetail_Create_DT { get; set; }
        [DisplayName("修改人員")]
        public string ExtRodDetail_Modify_ID { get; set; }
        [DisplayName("修改時間")]
        public DateTime ExtRodDetail_Modify_DT { get; set; }
        [DisplayName("建立人員")]
        public string ExtRodDetail_Create_Name { get; set; }
        [DisplayName("修改人員")]
        public string ExtRodDetail_Modify_Name { get; set; }
    }
}

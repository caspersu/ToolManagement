using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tool_Management.Service.ViewModels
{
    public class HiltMasterViewModel
    {
        [DisplayName("刀把料號")]
        [Required]
        public string HiltMaster_ID { get; set;}
        [DisplayName("刀把名稱")]
        [Required]
        public string Hilt_Name { get; set; }
        [DisplayName("刀把廠牌")]
        [Required]
        public string Hilt_Brand { get; set; }
        [DisplayName("刀把規格")]
        [Required]
        public string Hilt_Spec { get; set; }
        [DisplayName("倉位")]
        [Required]
        public string Hilt_CabinID { get; set; }
        [DisplayName("目前庫存數量")]
        [Required]
        public long Hilt_Quality { get; set; }
        [DisplayName("建立人員ID")]       
        public string HiltMaster_Create_ID { get; set; }
        [DisplayName("建立時間")]
        public DateTime HiltMaster_Create_DT { get; set; }
        [DisplayName("修改人員ID")]
        public string HiltMaster_Modify_ID { get; set; }
        [DisplayName("修改時間")]
        public DateTime HiltMaster_Modify_DT { get; set; }
        [DisplayName("建立人員")]
        public string HiltMaster_Create_Name { get; set; }
        [DisplayName("修改人員")]
        public string HiltMaster_Modify_Name { get; set; }
    }

    public class HiltDetailViewModel
    {
        [DisplayName("刀把料號")]
        [Required]
        public string HiltMaster_ID { get; set; }
        [DisplayName("刀把編號")]
        [Required]
        public string HiltDetail_ID { get; set; }
        [DisplayName("新品")]
        [Required]
        public string IsNewHilt { get; set; }
        [DisplayName("新品領料時間")]
        [Required]
        public System.DateTime NewEnter_DT { get; set; }
        [DisplayName("刀把狀態")]
        [Required]
        public string HiltDetail_Status { get; set; }

        [DisplayName("建立人員ID")]
        public string HiltDetail_Create_ID { get; set; }
        [DisplayName("建立時間")]
        public DateTime HiltDetail_Create_DT { get; set; }
        [DisplayName("修改人員ID")]
        public string HiltDetail_Modify_ID { get; set; }
        [DisplayName("修改時間")]
        public DateTime HiltDetail_Modify_DT { get; set; }
        [DisplayName("建立人員")]
        public string HiltDetail_Create_Name { get; set; }
        [DisplayName("修改人員")]
        public string HiltDetail_Modify_Name { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tool_Management.Service.ViewModels
{
    public class KnifeMasterViewModel
    {
        [DisplayName("刀具料號")]
        [Required]
        public string KnifeMaster_ID {get; set;}
        [DisplayName("刀具名稱")]
        [Required]
        public string Knife_Name { get; set; }
        [DisplayName("刀具廠牌")]
        [Required]
        public string Knife_Brand { get; set; }
        [DisplayName("刀具規格")]
        [Required]
        public string Knife_Spec { get; set; }
        [DisplayName("倉位")]
        [Required]
        public string Knife_CabinID { get; set; }
        [DisplayName("適用機種")]
        [Required]
        public string Knife_Kind { get; set; }
        [DisplayName("使用機種")]
        [Required]
        public string Knife_Model { get; set; }
        [DisplayName("目前庫存數量")]
        [Required]
        public long Knife_Quality { get; set; }
        [DisplayName("建立人員ID")]       
        public string KnifeMaster_Create_ID { get; set; }
        [DisplayName("建立時間")]
        public DateTime KnifeMaster_Create_DT { get; set; }
        [DisplayName("修改人員ID")]
        public string KnifeMaster_Modify_ID { get; set; }
        [DisplayName("修改時間")]
        public DateTime KnifeMaster_Modify_DT { get; set; }
        [DisplayName("建立人員")]
        public string KnifeMaster_Create_Name { get; set; }
        [DisplayName("修改人員")]
        public string KnifeMaster_Modify_Name { get; set; }
    }

    public class KnifeDetailViewModel
    {
        [DisplayName("刀具料號")]
        [Required]
        public string KnifeMaster_ID { get; set; }
        [DisplayName("刀具編號")]
        [Required]
        public string KnifeDetail_ID { get; set; }
        [DisplayName("新品")]
        [Required]
        public string IsNewKnife { get; set; }
        [DisplayName("新品領料時間")]
        [Required]
        public System.DateTime NewEnter_DT { get; set; }
        [DisplayName("刀具狀態")]
        [Required]
        public string KnifeDetail_Status { get; set; }

        [DisplayName("建立人員")]
        public string KnifeDetail_Create_ID { get; set; }
        [DisplayName("建立時間")]
        public DateTime KnifeDetail_Create_DT { get; set; }
        [DisplayName("修改人員")]
        public string KnifeDetail_Modify_ID { get; set; }
        [DisplayName("修改時間")]
        public DateTime KnifeDetail_Modify_DT { get; set; }
        [DisplayName("建立人員")]
        public string KnifeDetail_Create_Name { get; set; }
        [DisplayName("修改人員")]
        public string KnifeDetail_Modify_Name { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tool_Management.Service.ViewModels
{
    public class NailMasterViewModel
    {
        [DisplayName("拉丁料號")]
        [Required]
        public string NailMaster_ID { get; set;}
        [DisplayName("拉丁名稱")]
        [Required]
        public string Nail_Name { get; set; }
        [DisplayName("拉丁廠牌")]
        [Required]
        public string Nail_Brand { get; set; }
        [DisplayName("拉丁規格")]
        [Required]
        public string Nail_Spec { get; set; }
        [DisplayName("倉位")]
        [Required]
        public string Nail_CabinID { get; set; }
        [DisplayName("目前庫存數量")]
        [Required]
        public long Nail_Quality { get; set; }
        
        [DisplayName("建立人員ID")]       
        public string NailMaster_Create_ID { get; set; }
        [DisplayName("建立時間")]
        public DateTime NailMaster_Create_DT { get; set; }
        [DisplayName("修改人員ID")]
        public string NailMaster_Modify_ID { get; set; }
        [DisplayName("修改時間")]
        public DateTime NailMaster_Modify_DT { get; set; }
        [DisplayName("建立人員")]
        public string NailMaster_Create_Name { get; set; }
        [DisplayName("修改人員")]
        public string NailMaster_Modify_Name { get; set; }
    }

    public class NailDetailViewModel
    {
        [DisplayName("拉丁料號")]
        [Required]
        public string NailMaster_ID { get; set; }
        [DisplayName("拉丁編號")]
        [Required]
        public string NailDetail_ID { get; set; }
        [DisplayName("拉丁狀態")]
        [Required]
        public string NailDetail_Status { get; set; }
        [DisplayName("建立人員")]
        public string NailDetail_Create_ID { get; set; }
        [DisplayName("建立時間")]
        public DateTime NailDetail_Create_DT { get; set; }
        [DisplayName("修改人員")]
        public string NailDetail_Modify_ID { get; set; }
        [DisplayName("修改時間")]
        public DateTime NailDetail_Modify_DT { get; set; }
        [DisplayName("建立人員")]
        public string NailDetail_Create_Name { get; set; }
        [DisplayName("修改人員")]
        public string NailDetail_Modify_Name { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tool_Management.Service.ViewModels
{
    public class Collet2MasterViewModel
    {
        [DisplayName("筒夾2料號")]
        [Required]
        public string Collet2Master_ID { get; set;}
        [DisplayName("筒夾2名稱")]
        [Required]
        public string Collet2_Name { get; set; }
        [DisplayName("筒夾2廠牌")]
        [Required]
        public string Collet2_Brand { get; set; }
        [DisplayName("筒夾2規格")]
        [Required]
        public string Collet2_Spec { get; set; }
        [DisplayName("倉位")]
        [Required]
        public string Collet2_CabinID { get; set; }
        [DisplayName("目前庫存數量")]
        [Required]
        public long Collet2_Quality { get; set; }
        [DisplayName("建立人員ID")]       
        public string Collet2Master_Create_ID { get; set; }
        [DisplayName("建立時間")]
        public DateTime Collet2Master_Create_DT { get; set; }
        [DisplayName("修改人員ID")]
        public string Collet2Master_Modify_ID { get; set; }
        [DisplayName("修改時間")]
        public DateTime Collet2Master_Modify_DT { get; set; }
        [DisplayName("建立人員")]
        public string Collet2Master_Create_Name { get; set; }
        [DisplayName("修改人員")]
        public string Collet2Master_Modify_Name { get; set; }
    }

    public class Collet2DetailViewModel
    {
        [DisplayName("筒夾2料號")]
        [Required]
        public string Collet2Master_ID { get; set; }
        [DisplayName("筒夾2編號")]
        [Required]
        public string Collet2Detail_ID { get; set; }
        [DisplayName("新品")]
        [Required]
        public string IsNewCollet2 { get; set; }
        [DisplayName("新品領料時間")]
        [Required]
        public System.DateTime NewEnter_DT { get; set; }
        [DisplayName("筒夾2狀態")]
        [Required]
        public string Collet2Detail_Status { get; set; }

        [DisplayName("建立人員ID")]
        public string Collet2Detail_Create_ID { get; set; }
        [DisplayName("建立時間")]
        public DateTime Collet2Detail_Create_DT { get; set; }
        [DisplayName("修改人員ID")]
        public string Collet2Detail_Modify_ID { get; set; }
        [DisplayName("修改時間")]
        public DateTime Collet2Detail_Modify_DT { get; set; }
        [DisplayName("建立人員")]
        public string Collet2Detail_Create_Name { get; set; }
        [DisplayName("修改人員")]
        public string Collet2Detail_Modify_Name { get; set; }
    }
}

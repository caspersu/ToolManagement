using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tool_Management.Service.ViewModels
{
    public class Collet1MasterViewModel
    {
        [DisplayName("筒夾1料號")]
        [Required]
        public string Collet1Master_ID { get; set;}
        [DisplayName("筒夾1名稱")]
        [Required]
        public string Collet1_Name { get; set; }
        [DisplayName("筒夾1廠牌")]
        [Required]
        public string Collet1_Brand { get; set; }
        [DisplayName("筒夾1規格")]
        [Required]
        public string Collet1_Spec { get; set; }
        [DisplayName("倉位")]
        [Required]
        public string Collet1_CabinID { get; set; }
        [DisplayName("目前庫存數量")]
        [Required]
        public long Collet1_Quality { get; set; }
        [DisplayName("建立人員ID")]       
        public string Collet1Master_Create_ID { get; set; }
        [DisplayName("建立時間")]
        public DateTime Collet1Master_Create_DT { get; set; }
        [DisplayName("修改人員ID")]
        public string Collet1Master_Modify_ID { get; set; }
        [DisplayName("修改時間")]
        public DateTime Collet1Master_Modify_DT { get; set; }
        [DisplayName("建立人員")]
        public string Collet1Master_Create_Name { get; set; }
        [DisplayName("修改人員")]
        public string Collet1Master_Modify_Name { get; set; }
    }

    public class Collet1DetailViewModel
    {
        [DisplayName("筒夾1料號")]
        [Required]
        public string Collet1Master_ID { get; set; }
        [DisplayName("筒夾1編號")]
        [Required]
        public string Collet1Detail_ID { get; set; }
        [DisplayName("新品")]
        [Required]
        public string IsNewCollet1 { get; set; }
        [DisplayName("新品領料時間")]
        [Required]
        public System.DateTime NewEnter_DT { get; set; }
        [DisplayName("筒夾1狀態")]
        [Required]
        public string Collet1Detail_Status { get; set; }

        [DisplayName("建立人員ID")]
        public string Collet1Detail_Create_ID { get; set; }
        [DisplayName("建立時間")]
        public DateTime Collet1Detail_Create_DT { get; set; }
        [DisplayName("修改人員ID")]
        public string Collet1Detail_Modify_ID { get; set; }
        [DisplayName("修改時間")]
        public DateTime Collet1Detail_Modify_DT { get; set; }
        [DisplayName("建立人員")]
        public string Collet1Detail_Create_Name { get; set; }
        [DisplayName("修改人員")]
        public string Collet1Detail_Modify_Name { get; set; }
    }
}

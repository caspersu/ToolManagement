using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tool_Management.Service.ViewModels
{
    public class InFormViewModel
    {

        [DisplayName("入庫編號")]
        [Required]
        public string InForm_ID { get; set; }

        [DisplayName("入庫日期")]
        [Required]
        public string In_DT { get; set; }

        [DisplayName("入庫人員")]
        [Required]
        public string In_EmpID { get; set; }

        [DisplayName("倉庫人員")]
        [Required]
        public string Confirm_EmpID { get; set; }

        [DisplayName("入庫物品編號")]
        [Required]
        public string Detail_ID { get; set; }

        [DisplayName("入庫料號")]
        [Required]
        public string Master_ID { get; set;}

        [DisplayName("入庫種類")]
        [Required]
        public string DetailID_Type { get; set; }

        [DisplayName("物品入庫狀態")]
        [Required]
        public string DetailID_Status { get; set; }

        [DisplayName("物品使用時間")]
        [Required]
        public string DetailID_UseTime { get; set; }

        [DisplayName("備註")]
        [Required]
        public string Memo { get; set; }

        [DisplayName("建立時間")]
        public string OutForm_Create_DT { get; set; }
        [DisplayName("建立人員ID")]
        public string OutForm_Create_ID { get; set; }
        [DisplayName("建立人員")]
        public string OutForm_Create_Name { get; set; }
        [DisplayName("修改時間")]
        public System.DateTime OutForm_Modify_DT { get; set; }
        [DisplayName("修改人員ID")]
        public string OutForm_Modify_ID { get; set; }
        [DisplayName("修改人員")]
        public string OutForm_Modify_Name { get; set; }


    }


}

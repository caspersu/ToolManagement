using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tool_Management.Service.ViewModels
{
    public class OutFormViewModel
    {

        [DisplayName("領用編號")]
        [Required]
        public string OutForm_ID { get; set; }

        [DisplayName("領用日期")]
        [Required]
        public string Out_DT { get; set; }

        [DisplayName("領用人員")]
        [Required]
        public string Out_EmpID { get; set; }

        [DisplayName("領用人員班別")]
        [Required]
        public string Out_EmpClass { get; set; }

        [DisplayName("倉庫人員")]
        [Required]
        public string Confirm_EmpID { get; set; }

        [DisplayName("領用物品編號")]
        [Required]
        public string Detail_ID { get; set; }

        [DisplayName("領用料號")]
        [Required]
        public string Master_ID { get; set;}

        [DisplayName("領用種類")]
        [Required]
        public string DetailID_Type { get; set; }

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

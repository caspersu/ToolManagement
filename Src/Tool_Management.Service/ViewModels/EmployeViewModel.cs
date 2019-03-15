using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tool_Management.Service.ViewModels
{
    public class EmployeViewModel
    {
        [DisplayName("人員編號")]
        [Required]
        public string Emp_ID { get; set; }
        [DisplayName("人員名稱")]
        [Required]
        public string Emp_Name { get; set; }
        [DisplayName("人員狀態")]
        [Required]
        public string Emp_Status { get; set; }

        public System.DateTime Emp_Create_DT { get; set; }
        [DisplayName("建立人員ID")]
        public string Emp_Create_ID { get; set; }
        [DisplayName("建立人員")]
        public string Emp_Create_Name { get; set; }
        [DisplayName("修改時間")]
        public System.DateTime Emp_Modify_DT { get; set; }
        [DisplayName("修改人員ID")]
        public string Emp_Modify_ID { get; set; }
        [DisplayName("修改人員")]
        public string Emp_Modify_Name { get; set; }


    }


}

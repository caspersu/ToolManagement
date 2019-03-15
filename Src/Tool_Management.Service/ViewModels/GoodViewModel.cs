using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tool_Management.Service.ViewModels
{
    public class GoodViewModel
    {
        [DisplayName("品名編號")]
        [Required]
        public string Good_ID {get; set;}
        [DisplayName("品名名稱")]
        [Required]
        public string Good_Name { get; set; }
        [DisplayName("建立人員ID")]       
        public string Good_Create_ID { get; set; }
        [DisplayName("建立人員")]
        public string Good_Create_Name { get; set; }
        [DisplayName("建立時間")]
        public DateTime Good_Create_DT { get; set; }
        [DisplayName("修改人員ID")]
        public string Good_Modify_ID { get; set; }
        [DisplayName("修改人員")]
        public string Good_Modify_Name { get; set; }
        [DisplayName("修改時間")]
        public DateTime Good_Modify_DT { get; set; }
    }
}

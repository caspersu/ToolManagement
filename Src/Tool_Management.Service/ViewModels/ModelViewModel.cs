using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tool_Management.Service.ViewModels
{
    public class ModelViewModel
    {
        [DisplayName("機種編號")]
        [Required]
        public string Model_ID {get; set;}
        [DisplayName("機種名稱")]
        [Required]
        public string Model_Name { get; set; }
        [DisplayName("建立人員ID")]       
        public string Model_Create_ID { get; set; }
        [DisplayName("建立人員")]
        public string Model_Create_Name { get; set; }
        [DisplayName("建立時間")]
        public DateTime Model_Create_DT { get; set; }
        [DisplayName("修改人員ID")]
        public string Model_Modify_ID { get; set; }
        [DisplayName("修改人員")]
        public string Model_Modify_Name { get; set; }
        [DisplayName("修改時間")]
        public DateTime Model_Modify_DT { get; set; }
    }
}

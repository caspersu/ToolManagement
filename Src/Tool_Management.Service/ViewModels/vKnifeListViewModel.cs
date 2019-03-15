using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tool_Management.Service.ViewModels
{
    public class vKnifeListViewModel
    {
        [DisplayName("刀具配置編號")]
        [Required]
        public string KnifeList_ID { get; set; }

        [DisplayName("機種編號")]
        [Required]
        public string Model_ID {get; set;}

        [DisplayName("機種名稱")]
        [Required]
        public string Model_Name { get; set; }

        [DisplayName("品名編號")]
        [Required]
        public string Good_ID { get; set; }

        [DisplayName("品名")]
        [Required]
        public string Good_Name { get; set; }

        [DisplayName("工站別")]
        [Required]
        public string WorkStation_No { get; set; }

        [DisplayName("建立人員")]       
        public string KnifeList_Create_Name { get; set; }
        [DisplayName("建立時間")]
        public DateTime KnifeList_Create_DT { get; set; }
        [DisplayName("修改人員")]
        public string KnifeList_Modify_Name { get; set; }
        [DisplayName("修改時間")]
        public DateTime KnifeList_Modify_DT { get; set; }

        [DisplayName("建立人員ID")]
        public string KnifeList_Create_ID { get; set; }
        [DisplayName("修改人員ID")]
        public string KnifeList_Modify_ID { get; set; }
    }
}

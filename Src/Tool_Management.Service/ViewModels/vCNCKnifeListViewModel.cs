using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tool_Management.Service.ViewModels
{
    public class vCNCKnifeListViewModel
    {
        [DisplayName("機台刀具配置編號")]
        [ScaffoldColumn(false)]
        public decimal CNCKnifeList_ID { get; set; }

        [DisplayName("機台編號")]
        [Required]
        public string CNC_ID { get; set;}

        [DisplayName("機台IP")]
        [Required]
        public string CNC_IP { get; set; }

        [DisplayName("生產車間")]
        [Required]
        public string Car_No { get; set; }


        [DisplayName("生產線別")]
        [Required]
        public string Line_No { get; set; }

        [DisplayName("刀具配置編號")]
        [Required]
        [ScaffoldColumn(false)]
        public string KnifeList_ID { get; set; }

        [DisplayName("機種編號")]
        [Required]
        [ScaffoldColumn(false)]
        public string Model_ID { get; set; }

        [DisplayName("機種名稱")]
        [Required]
        [ScaffoldColumn(false)]
        public string Model_Name { get; set; }

        [DisplayName("品名")]
        [Required]
        [ScaffoldColumn(false)]
        public string Good_Name { get; set; }

        [DisplayName("品名")]
        [Required]
        [ScaffoldColumn(false)]
        public string Good_ID { get; set; }

        [DisplayName("工站別")]
        [Required]
        public string WorkStation_No { get; set; }

        [DisplayName("機種- 品名-工站別")]
        [UIHint("ModelGoodWk")]
        [Required]
        public string ModelGoodWk { get; set; }


        [DisplayName("建立人員ID")]       
        public string CNCList_Create_ID { get; set; }
        [DisplayName("建立時間")]
        public DateTime CNCList_Create_DT { get; set; }
        [DisplayName("修改人員ID")]
        public string CNCList_Modify_ID { get; set; }
        [DisplayName("修改時間")]
        public DateTime CNCList_Modify_DT { get; set; }
        [DisplayName("建立人員")]
        public string CNCList_Create_Name { get; set; }
        [DisplayName("修改人員")]
        public string CNCList_Modify_Name { get; set; }
    }


}

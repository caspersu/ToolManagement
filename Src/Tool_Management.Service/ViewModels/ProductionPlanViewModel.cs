using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tool_Management.Service.ViewModels
{
    public class ProductionPlanViewModel
    {
        [DisplayName("生產計劃編號")]
        [Required]
        [ScaffoldColumn(false)]
        public decimal Planning_ID { get; set; }

        [DisplayName("機台刀具配置編號")]
        [ScaffoldColumn(false)]
        public Nullable<decimal> CNCKnifeList_ID { get; set;}


        [DisplayName("刀具配置編號")]
        [Required]
        [ScaffoldColumn(false)]
        public string KnifeList_ID { get; set; }

        [DisplayName("班別")]
        [Required]
        public string Class_Type { get; set; }

        [DisplayName("技術人員編號")]
        [Required]
        public string Class_EmpID { get; set; }

        [DisplayName("標準人數")]
        [Required]
        public int Class_StandardPerson { get; set; }

        [DisplayName("實際人數")]
        [Required]
        public int Class_RealPerson { get; set; }

        [DisplayName("機種- 品名-工站別")]
        [Required]
        public string ModelGoodWk { get; set; }


        [DisplayName("建立人員ID")]
        public string Planning_Create_ID { get; set; }
        [DisplayName("修改人員ID")]
        public string Planning_Modify_ID { get; set; }
        [DisplayName("建立時間")]
        public DateTime Planning_Create_DT { get; set; }
        [DisplayName("修改時間")]
        public DateTime Planning_Modify_DT { get; set; }
        [DisplayName("建立人員")]
        public string Planning_Create_Name { get; set; }
        [DisplayName("修改人員")]
        public string Planning_Modify_Name { get; set; }
    }


}

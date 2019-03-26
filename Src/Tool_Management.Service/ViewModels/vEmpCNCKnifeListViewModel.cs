using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tool_Management.Service.ViewModels
{
    public class vEmpCNCKnifeListViewModel
    {

        [DisplayName("機台編號")]
        [Required]
        public string CNC_ID { get; set; }

        [DisplayName("機台IP")]
        [Required]
        public string CNC_IP { get; set; }

        [DisplayName("技術人員編號")]
        public string Class_EmpID { get; set; }
        [DisplayName("班別")]
        public string Class_Type { get; set; }
        [DisplayName("機台刀具配置編號")]
        public Nullable<decimal> CNCKnifeList_ID { get; set; }
        [DisplayName("技術人員")]
        public string Emp_Name { get; set; }
        [DisplayName("刀具配置編號")]
        public string KnifeList_ID { get; set; }
        [DisplayName("生產計劃編號")]
        public decimal Planning_ID { get; set; }
        [DisplayName("生產品名")]
        public string Good_Name { get; set; }
        [DisplayName("生產機種")]
        public string Model_Name { get; set; }
        [DisplayName("生產工程別")]
        public string WorkStation_No { get; set; }
        [DisplayName("生產機種編號")]
        public string Model_ID { get; set; }
        [DisplayName("生產車間")]
        public string  Car_No { get; set; }
        [DisplayName("生產線別")]
        public string Line_No { get; set; }
        [DisplayName("機台型號")]
        public string CNC_Model { get; set; }
        [DisplayName("機台廠牌")]
        public string CNC_Brand { get; set; }
    }


}

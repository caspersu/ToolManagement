using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tool_Management.Service.ViewModels
{
    public class vCNC_MonitorViewModel
    {
        [DisplayName("機台編號")]
        [Required]
        public string CNC_ID { get; set;}
        [DisplayName("機台名稱")]
        [Required]
        public string CNC_Name { get; set; }
        [DisplayName("機台廠牌")]
        [Required]
        public string CNC_Brand { get; set; }
        [DisplayName("CNC IP")]
        [Required]
        public string CNC_IP { get; set; }
        [DisplayName("CNC 軟體版本")]
        public string CNC_Ver { get; set; }
        [DisplayName("CNC 機型")]
        public string CNC_Model { get; set; }
        [DisplayName("CNC 狀態")]
        public string CNC_Current_Status { get; set; }
        [DisplayName("CNC 當前產出")]
        public string CNC_Current_ProductionAmount { get; set; }
        [DisplayName("CNC 同步時間")]
        public string CNC_Current_StatusDT { get; set; }
        
        public string Create_DT { get; set; }

    }


}

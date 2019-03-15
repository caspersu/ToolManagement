using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tool_Management.Service.ViewModels
{
    public class vCNCViewModel
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
        public string CNC_Status { get; set; }
        [DisplayName("建立人員ID")]       
        public string CNC_Create_ID { get; set; }
        [DisplayName("建立時間")]
        public DateTime CNC_Create_DT { get; set; }
        [DisplayName("修改人員ID")]
        public string CNC_Modify_ID { get; set; }
        [DisplayName("修改時間")]
        public DateTime CNC_Modify_DT { get; set; }
        [DisplayName("建立人員")]
        public string CNC_Create_Name { get; set; }
        [DisplayName("修改人員")]
        public string CNC_Modify_Name { get; set; }
    }


}

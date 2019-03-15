using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tool_Management.Service.ViewModels
{
    public class MeasureMasterViewModel
    {
        [DisplayName("機上量測料號")]
        [Required]
        public string MeasureMaster_ID { get; set;}
        [DisplayName("機上量測名稱")]
        [Required]
        public string Measure_Name { get; set; }
        [DisplayName("機上量測廠牌")]
        [Required]
        public string Measure_Brand { get; set; }
        [DisplayName("機上量測規格")]
        [Required]
        public string Measure_Spec { get; set; }
        [DisplayName("倉位")]
        [Required]
        public string Measure_CabinID { get; set; }
        [DisplayName("目前庫存數量")]
        [Required]
        public long Measure_Quality { get; set; }
        [DisplayName("建立人員ID")]       
        public string MeasureMaster_Create_ID { get; set; }
        [DisplayName("建立時間")]
        public DateTime MeasureMaster_Create_DT { get; set; }
        [DisplayName("修改人員ID")]
        public string MeasureMaster_Modify_ID { get; set; }
        [DisplayName("修改時間")]
        public DateTime MeasureMaster_Modify_DT { get; set; }
        [DisplayName("建立人員")]
        public string MeasureMaster_Create_Name { get; set; }
        [DisplayName("修改人員")]
        public string MeasureMaster_Modify_Name { get; set; }
    }

    public class MeasureDetailViewModel
    {
        [DisplayName("機上量測料號")]
        [Required]
        public string MeasureMaster_ID { get; set; }
        [DisplayName("機上量測編號")]
        [Required]
        public string MeasureDetail_ID { get; set; }
        [DisplayName("新品")]
        [Required]
        public string IsNewMeasure { get; set; }
        [DisplayName("新品領料時間")]
        [Required]
        public System.DateTime NewEnter_DT { get; set; }
        [DisplayName("機上量測狀態")]
        [Required]
        public string MeasureDetail_Status { get; set; }

        [DisplayName("建立人員ID")]
        public string MeasureDetail_Create_ID { get; set; }
        [DisplayName("建立時間")]
        public DateTime MeasureDetail_Create_DT { get; set; }
        [DisplayName("修改人員ID")]
        public string MeasureDetail_Modify_ID { get; set; }
        [DisplayName("修改時間")]
        public DateTime MeasureDetail_Modify_DT { get; set; }
        [DisplayName("建立人員")]
        public string MeasureDetail_Create_Name { get; set; }
        [DisplayName("修改人員")]
        public string MeasureDetail_Modify_Name { get; set; }
    }
}

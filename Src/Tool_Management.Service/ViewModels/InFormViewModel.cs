using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tool_Management.Service.ViewModels
{
    public class InFormViewModel
    {

        [DisplayName("入庫編號")]
        [Required]
        public string InForm_ID { get; set; }

        [DisplayName("入庫日期")]
        [Required]
        public string In_DT { get; set; }

        [DisplayName("入庫人員")]
        [Required]
        public string In_EmpID { get; set; }

        [DisplayName("倉庫人員")]
        [Required]
        public string Confirm_EmpID { get; set; }

        [DisplayName("入庫物品編號")]
        [Required]
        public string Detail_ID { get; set; }

        [DisplayName("入庫料號")]
        [Required]
        public string Master_ID { get; set;}

        [DisplayName("入庫種類")]
        [Required]
        public string DetailID_Type { get; set; }

        [DisplayName("物品入庫狀態")]
        [Required]
        public string DetailID_Status { get; set; }

        [DisplayName("物品使用時間")]
        [Required]
        public string DetailID_UseTime { get; set; }

        [DisplayName("備註")]
        [Required]
        public string Memo { get; set; }

        [DisplayName("建立時間")]
        public DateTime InForm_Create_DT { get; set; }
        [DisplayName("建立人員ID")]
        public string InForm_Create_ID { get; set; }
        [DisplayName("建立人員")]
        public string InForm_Create_Name { get; set; }
        [DisplayName("修改時間")]
        public System.DateTime InForm_Modify_DT { get; set; }
        [DisplayName("修改人員ID")]
        public string InForm_Modify_ID { get; set; }
        [DisplayName("修改人員")]
        public string InForm_Modify_Name { get; set; }


    }

    public class KnifeInFormViewModel
    {
        [DisplayName("入庫編號")]
        //[Required]
        [ScaffoldColumn(false)]
        public string InForm_ID { get; set; }

        [DisplayName("入庫人員")]
        //[Required]
        [ScaffoldColumn(false)]
        public string In_EmpID { get; set; }

        [DisplayName("倉庫人員")]
        //[Required]
        [ScaffoldColumn(false)]
        public string Confirm_EmpID { get; set; }

        [DisplayName("刀具料號")]
        [Required]
        public string Master_ID { get; set; }

        [DisplayName("入庫數量")]
        [Required]
        public Int64 InForm_Quality { get; set; }

        [DisplayName("入庫日期")]
        //[Required]
        [ScaffoldColumn(false)]
        public string In_DT { get; set; }

        [DisplayName("物品入庫狀態")]
        [Required]
        public string DetailID_Status { get; set; }

        [DisplayName("物品使用時間(分鐘)")]
        [Required]
        public string DetailID_UseTime { get; set; }

        [DisplayName("備註")]
        public string Memo { get; set; }

        [DisplayName("建立時間")]
        [ScaffoldColumn(false)]
        public DateTime InForm_Create_DT { get; set; }
        [DisplayName("建立人員ID")]
        [ScaffoldColumn(false)]
        public string InForm_Create_ID { get; set; }
        [DisplayName("建立人員")]
        [ScaffoldColumn(false)]
        public string InForm_Create_Name { get; set; }
        [DisplayName("修改時間")]
        [ScaffoldColumn(false)]
        public System.DateTime InForm_Modify_DT { get; set; }
        [DisplayName("修改人員ID")]
        [ScaffoldColumn(false)]
        public string InForm_Modify_ID { get; set; }
        [DisplayName("修改人員")]
        [ScaffoldColumn(false)]
        public string InForm_Modify_Name { get; set; }

        [DisplayName("單位")]
        public string Unit { get; set; }

        [DisplayName("刀具名稱")]
        public string Knife_Name { get; set; }
    }

    public class HiltInFormViewModel
    {
        [DisplayName("入庫編號")]
        //[Required]
        [ScaffoldColumn(false)]
        public string InForm_ID { get; set; }

        [DisplayName("入庫人員")]
        //[Required]
        [ScaffoldColumn(false)]
        public string In_EmpID { get; set; }

        [DisplayName("倉庫人員")]
        //[Required]
        [ScaffoldColumn(false)]
        public string Confirm_EmpID { get; set; }

        [DisplayName("刀把料號")]
        [Required]
        public string Master_ID { get; set; }

        [DisplayName("入庫數量")]
        [Required]
        public Int64 InForm_Quality { get; set; }

        [DisplayName("入庫日期")]
        //[Required]
        [ScaffoldColumn(false)]
        public string In_DT { get; set; }

        [DisplayName("物品入庫狀態")]
        [Required]
        public string DetailID_Status { get; set; }

        [DisplayName("物品使用時間(分鐘)")]
        [Required]
        public string DetailID_UseTime { get; set; }

        [DisplayName("備註")]
        public string Memo { get; set; }

        [DisplayName("建立時間")]
        [ScaffoldColumn(false)]
        public DateTime InForm_Create_DT { get; set; }
        [DisplayName("建立人員ID")]
        [ScaffoldColumn(false)]
        public string InForm_Create_ID { get; set; }
        [DisplayName("建立人員")]
        [ScaffoldColumn(false)]
        public string InForm_Create_Name { get; set; }
        [DisplayName("修改時間")]
        [ScaffoldColumn(false)]
        public System.DateTime InForm_Modify_DT { get; set; }
        [DisplayName("修改人員ID")]
        [ScaffoldColumn(false)]
        public string InForm_Modify_ID { get; set; }
        [DisplayName("修改人員")]
        [ScaffoldColumn(false)]
        public string InForm_Modify_Name { get; set; }

        [DisplayName("單位")]
        public string Unit { get; set; }

        [DisplayName("刀把名稱")]
        public string Hilt_Name { get; set; }
    }

    public class NailInFormViewModel
    {
        [DisplayName("入庫編號")]
        //[Required]
        [ScaffoldColumn(false)]
        public string InForm_ID { get; set; }

        [DisplayName("入庫人員")]
        //[Required]
        [ScaffoldColumn(false)]
        public string In_EmpID { get; set; }

        [DisplayName("倉庫人員")]
        //[Required]
        [ScaffoldColumn(false)]
        public string Confirm_EmpID { get; set; }

        [DisplayName("拉丁料號")]
        [Required]
        public string Master_ID { get; set; }

        [DisplayName("入庫數量")]
        [Required]
        public Int64 InForm_Quality { get; set; }

        [DisplayName("入庫日期")]
        //[Required]
        [ScaffoldColumn(false)]
        public string In_DT { get; set; }

        [DisplayName("物品入庫狀態")]
        [Required]
        public string DetailID_Status { get; set; }

        [DisplayName("物品使用時間(分鐘)")]
        [Required]
        public string DetailID_UseTime { get; set; }

        [DisplayName("備註")]
        public string Memo { get; set; }

        [DisplayName("建立時間")]
        [ScaffoldColumn(false)]
        public DateTime InForm_Create_DT { get; set; }
        [DisplayName("建立人員ID")]
        [ScaffoldColumn(false)]
        public string InForm_Create_ID { get; set; }
        [DisplayName("建立人員")]
        [ScaffoldColumn(false)]
        public string InForm_Create_Name { get; set; }
        [DisplayName("修改時間")]
        [ScaffoldColumn(false)]
        public System.DateTime InForm_Modify_DT { get; set; }
        [DisplayName("修改人員ID")]
        [ScaffoldColumn(false)]
        public string InForm_Modify_ID { get; set; }
        [DisplayName("修改人員")]
        [ScaffoldColumn(false)]
        public string InForm_Modify_Name { get; set; }

        [DisplayName("單位")]
        public string Unit { get; set; }

        [DisplayName("拉丁名稱")]
        public string Nail_Name { get; set; }
    }

    public class MeasureInFormViewModel
    {
        [DisplayName("入庫編號")]
        //[Required]
        [ScaffoldColumn(false)]
        public string InForm_ID { get; set; }

        [DisplayName("入庫人員")]
        //[Required]
        [ScaffoldColumn(false)]
        public string In_EmpID { get; set; }

        [DisplayName("倉庫人員")]
        //[Required]
        [ScaffoldColumn(false)]
        public string Confirm_EmpID { get; set; }

        [DisplayName("機上量測料號")]
        [Required]
        public string Master_ID { get; set; }

        [DisplayName("入庫數量")]
        [Required]
        public Int64 InForm_Quality { get; set; }

        [DisplayName("入庫日期")]
        //[Required]
        [ScaffoldColumn(false)]
        public string In_DT { get; set; }

        [DisplayName("物品入庫狀態")]
        [Required]
        public string DetailID_Status { get; set; }

        [DisplayName("物品使用時間(分鐘)")]
        [Required]
        public string DetailID_UseTime { get; set; }

        [DisplayName("備註")]
        public string Memo { get; set; }

        [DisplayName("建立時間")]
        [ScaffoldColumn(false)]
        public DateTime InForm_Create_DT { get; set; }
        [DisplayName("建立人員ID")]
        [ScaffoldColumn(false)]
        public string InForm_Create_ID { get; set; }
        [DisplayName("建立人員")]
        [ScaffoldColumn(false)]
        public string InForm_Create_Name { get; set; }
        [DisplayName("修改時間")]
        [ScaffoldColumn(false)]
        public System.DateTime InForm_Modify_DT { get; set; }
        [DisplayName("修改人員ID")]
        [ScaffoldColumn(false)]
        public string InForm_Modify_ID { get; set; }
        [DisplayName("修改人員")]
        [ScaffoldColumn(false)]
        public string InForm_Modify_Name { get; set; }

        [DisplayName("單位")]
        public string Unit { get; set; }

        [DisplayName("機上量測名稱")]
        public string Measure_Name { get; set; }
    }

    public class ExtRodInFormViewModel
    {
        [DisplayName("入庫編號")]
        //[Required]
        [ScaffoldColumn(false)]
        public string InForm_ID { get; set; }

        [DisplayName("入庫人員")]
        //[Required]
        [ScaffoldColumn(false)]
        public string In_EmpID { get; set; }

        [DisplayName("倉庫人員")]
        //[Required]
        [ScaffoldColumn(false)]
        public string Confirm_EmpID { get; set; }

        [DisplayName("延長桿料號")]
        [Required]
        public string Master_ID { get; set; }

        [DisplayName("入庫數量")]
        [Required]
        public Int64 InForm_Quality { get; set; }

        [DisplayName("入庫日期")]
        //[Required]
        [ScaffoldColumn(false)]
        public string In_DT { get; set; }

        [DisplayName("物品入庫狀態")]
        [Required]
        public string DetailID_Status { get; set; }

        [DisplayName("物品使用時間(分鐘)")]
        [Required]
        public string DetailID_UseTime { get; set; }

        [DisplayName("備註")]
        public string Memo { get; set; }

        [DisplayName("建立時間")]
        [ScaffoldColumn(false)]
        public DateTime InForm_Create_DT { get; set; }
        [DisplayName("建立人員ID")]
        [ScaffoldColumn(false)]
        public string InForm_Create_ID { get; set; }
        [DisplayName("建立人員")]
        [ScaffoldColumn(false)]
        public string InForm_Create_Name { get; set; }
        [DisplayName("修改時間")]
        [ScaffoldColumn(false)]
        public System.DateTime InForm_Modify_DT { get; set; }
        [DisplayName("修改人員ID")]
        [ScaffoldColumn(false)]
        public string InForm_Modify_ID { get; set; }
        [DisplayName("修改人員")]
        [ScaffoldColumn(false)]
        public string InForm_Modify_Name { get; set; }

        [DisplayName("單位")]
        public string Unit { get; set; }

        [DisplayName("延長桿名稱")]
        public string ExtRod_Name { get; set; }
    }

    public class Collet1InFormViewModel
    {
        [DisplayName("入庫編號")]
        //[Required]
        [ScaffoldColumn(false)]
        public string InForm_ID { get; set; }

        [DisplayName("入庫人員")]
        //[Required]
        [ScaffoldColumn(false)]
        public string In_EmpID { get; set; }

        [DisplayName("倉庫人員")]
        //[Required]
        [ScaffoldColumn(false)]
        public string Confirm_EmpID { get; set; }

        [DisplayName("筒夾1料號")]
        [Required]
        public string Master_ID { get; set; }

        [DisplayName("入庫數量")]
        [Required]
        public Int64 InForm_Quality { get; set; }

        [DisplayName("入庫日期")]
        //[Required]
        [ScaffoldColumn(false)]
        public string In_DT { get; set; }

        [DisplayName("物品入庫狀態")]
        [Required]
        public string DetailID_Status { get; set; }

        [DisplayName("物品使用時間(分鐘)")]
        [Required]
        public string DetailID_UseTime { get; set; }

        [DisplayName("備註")]
        public string Memo { get; set; }

        [DisplayName("建立時間")]
        [ScaffoldColumn(false)]
        public DateTime InForm_Create_DT { get; set; }
        [DisplayName("建立人員ID")]
        [ScaffoldColumn(false)]
        public string InForm_Create_ID { get; set; }
        [DisplayName("建立人員")]
        [ScaffoldColumn(false)]
        public string InForm_Create_Name { get; set; }
        [DisplayName("修改時間")]
        [ScaffoldColumn(false)]
        public System.DateTime InForm_Modify_DT { get; set; }
        [DisplayName("修改人員ID")]
        [ScaffoldColumn(false)]
        public string InForm_Modify_ID { get; set; }
        [DisplayName("修改人員")]
        [ScaffoldColumn(false)]
        public string InForm_Modify_Name { get; set; }

        [DisplayName("單位")]
        public string Unit { get; set; }

        [DisplayName("筒夾1名稱")]
        public string Collet1_Name { get; set; }
    }

    public class Collet2InFormViewModel
    {
        [DisplayName("入庫編號")]
        //[Required]
        [ScaffoldColumn(false)]
        public string InForm_ID { get; set; }

        [DisplayName("入庫人員")]
        //[Required]
        [ScaffoldColumn(false)]
        public string In_EmpID { get; set; }

        [DisplayName("倉庫人員")]
        //[Required]
        [ScaffoldColumn(false)]
        public string Confirm_EmpID { get; set; }

        [DisplayName("筒夾2料號")]
        [Required]
        public string Master_ID { get; set; }

        [DisplayName("入庫數量")]
        [Required]
        public Int64 InForm_Quality { get; set; }

        [DisplayName("入庫日期")]
        //[Required]
        [ScaffoldColumn(false)]
        public string In_DT { get; set; }

        [DisplayName("物品入庫狀態")]
        [Required]
        public string DetailID_Status { get; set; }

        [DisplayName("物品使用時間(分鐘)")]
        [Required]
        public string DetailID_UseTime { get; set; }

        [DisplayName("備註")]
        public string Memo { get; set; }

        [DisplayName("建立時間")]
        [ScaffoldColumn(false)]
        public DateTime InForm_Create_DT { get; set; }
        [DisplayName("建立人員ID")]
        [ScaffoldColumn(false)]
        public string InForm_Create_ID { get; set; }
        [DisplayName("建立人員")]
        [ScaffoldColumn(false)]
        public string InForm_Create_Name { get; set; }
        [DisplayName("修改時間")]
        [ScaffoldColumn(false)]
        public System.DateTime InForm_Modify_DT { get; set; }
        [DisplayName("修改人員ID")]
        [ScaffoldColumn(false)]
        public string InForm_Modify_ID { get; set; }
        [DisplayName("修改人員")]
        [ScaffoldColumn(false)]
        public string InForm_Modify_Name { get; set; }

        [DisplayName("單位")]
        public string Unit { get; set; }

        [DisplayName("筒夾2名稱")]
        public string Collet2_Name { get; set; }
    }

    public class NutInFormViewModel
    {
        [DisplayName("入庫編號")]
        //[Required]
        [ScaffoldColumn(false)]
        public string InForm_ID { get; set; }

        [DisplayName("入庫人員")]
        //[Required]
        [ScaffoldColumn(false)]
        public string In_EmpID { get; set; }

        [DisplayName("倉庫人員")]
        //[Required]
        [ScaffoldColumn(false)]
        public string Confirm_EmpID { get; set; }

        [DisplayName("螺帽/刀頭料號")]
        [Required]
        public string Master_ID { get; set; }

        [DisplayName("入庫數量")]
        [Required]
        public Int64 InForm_Quality { get; set; }

        [DisplayName("入庫日期")]
        //[Required]
        [ScaffoldColumn(false)]
        public string In_DT { get; set; }

        [DisplayName("物品入庫狀態")]
        [Required]
        public string DetailID_Status { get; set; }

        [DisplayName("物品使用時間(分鐘)")]
        [Required]
        public string DetailID_UseTime { get; set; }

        [DisplayName("備註")]
        public string Memo { get; set; }

        [DisplayName("建立時間")]
        [ScaffoldColumn(false)]
        public DateTime InForm_Create_DT { get; set; }
        [DisplayName("建立人員ID")]
        [ScaffoldColumn(false)]
        public string InForm_Create_ID { get; set; }
        [DisplayName("建立人員")]
        [ScaffoldColumn(false)]
        public string InForm_Create_Name { get; set; }
        [DisplayName("修改時間")]
        [ScaffoldColumn(false)]
        public System.DateTime InForm_Modify_DT { get; set; }
        [DisplayName("修改人員ID")]
        [ScaffoldColumn(false)]
        public string InForm_Modify_ID { get; set; }
        [DisplayName("修改人員")]
        [ScaffoldColumn(false)]
        public string InForm_Modify_Name { get; set; }

        [DisplayName("單位")]
        public string Unit { get; set; }

        [DisplayName("螺帽/刀頭名稱")]
        public string Nut_Name { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tool_Management.Service.ViewModels
{
    public class KnifeListViewModel
    {
        [DisplayName("刀具配置編號")]
        [Required]
        [ScaffoldColumn(false)]
        public string KnifeList_ID { get; set; }

        [DisplayName("刀位編號")]
        [Required]
        public string ATC_ID { get; set; }

        [DisplayName("機種編號")]
        [Required]
        [ScaffoldColumn(false)]
        public string Model_ID {get; set;}

        [DisplayName("品名編號")]
        [Required]
        [ScaffoldColumn(false)]
        public string Good_ID { get; set; }

        [DisplayName("品名")]
        [Required]
        [ScaffoldColumn(false)]
        public string Good_Name { get; set; }

        [DisplayName("工站別")]
        [Required]
        [ScaffoldColumn(false)]
        public string WorkStation_No { get; set; }

        [DisplayName("機種名稱")]
        [Required]
        [ScaffoldColumn(false)]
        public string Model_Name { get; set; }

        [DisplayName("刀具編號")]
        [Required]
        [ScaffoldColumn(false)]
        public string KnifeDetail_ID { get; set; }
        [DisplayName("刀具料號")]
        [Required]
        public string KnifeMaster_ID { get; set; }

        [DisplayName("刀把料號")]
        [Required]
        public string HiltMaster_ID { get; set; }

        [DisplayName("刀把編號")]
        [Required]
        [ScaffoldColumn(false)]
        public string HiltDetail_ID { get; set; }

        [DisplayName("拉丁料號")]
        [Required]
        public string NailMaster_ID { get; set; }
        [DisplayName("拉丁編號")]
        [Required]
        [ScaffoldColumn(false)]
        public string NailDetail_ID { get; set; }

        [DisplayName("延長桿料號")]
        [Required]
        public string ExtRodMaster_ID { get; set; }
        [DisplayName("延長桿編號")]
        [Required]
        [ScaffoldColumn(false)]
        public string ExtRodDetail_ID { get; set; }

        [DisplayName("螺帽/刀頭編號")]
        [Required]
        public string NutMaster_ID { get; set; }
        [DisplayName("螺帽/刀頭序號")]
        [Required]
        [ScaffoldColumn(false)]
        public string NutDetail_ID { get; set; }

        [DisplayName("筒夾1料號")]
        [Required]
        public string Collet1Master_ID { get; set; }
        [DisplayName("筒夾1編號")]
        [Required]
        [ScaffoldColumn(false)]
        public string Collet1Detail_ID { get; set; }

        [DisplayName("筒夾2料號")]
        [Required]
        public string Collet2Master_ID { get; set; }
        [DisplayName("筒夾2編號")]
        [Required]
        [ScaffoldColumn(false)]
        public string Collet2Detail_ID { get; set; }


        [DisplayName("程序名稱")]
        //[Required]
        public string Program_No { get; set; }

        [DisplayName("刀徑")]
        //[Required]
        public string D { get; set; }

        [DisplayName("角R")]
        //[Required]
        public string R { get; set; }

        [DisplayName("刃長")]
        //[Required]
        public string L { get; set; }

        [DisplayName("有效長")]
        //[Required]
        public string CL { get; set; }

        [DisplayName("刀長")]
        //[Required]
        public string FL { get; set; }

        [DisplayName("預留")]
        //[Required]
        public string Reserved { get; set; }

        [DisplayName("每層深度")]
        //[Required]
        public string Deep { get; set; }

        [DisplayName("起始Z")]
        //[Required]
        public string SZ { get; set; }

        [DisplayName("終止Z")]
        //[Required]
        public string EZ { get; set; }

        [DisplayName("加工方法")]
        //[Required]
        public string Way { get; set; }

        [DisplayName("加工時間")]
        //[Required]
        public string Time { get; set; }

        [DisplayName("備註")]
        //[Required]
        public string Memo { get; set; }


        [DisplayName("建立人員ID")]       
        public string KnifeList_Create_ID { get; set; }
        [DisplayName("建立人員")]
        public string KnifeList_Create_Name { get; set; }
        [DisplayName("建立時間")]
        public DateTime KnifeList_Create_DT { get; set; }
        [DisplayName("修改人員")]
        public string KnifeList_Modify_ID { get; set; }
        [DisplayName("修改時間")]
        public DateTime KnifeList_Modify_DT { get; set; }
        [DisplayName("修改時間")]
        public string KnifeList_Modify_Name { get; set; }
    }
}

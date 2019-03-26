using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tool_Management.Service.ViewModels
{
    public class StockDetailViewModel
    {

        [DisplayName("料號/編號")]
        [Required]
        public string Master_ID { get; set;}

        [DisplayName("序號")]
        [Required]
        public string Detail_ID { get; set; }

        [DisplayName("料號/編號種類")]
        [Required]
        public string MasterID_Type { get; set; }

        [DisplayName("出庫/入庫/報廢")]
        [Required]
        public long Bound_Type { get; set; }

        [DisplayName("備註")]
        public string Memo { get; set; }

        [DisplayName("建立人員ID")]       
        public string StockDetail_Create_ID { get; set; }

        [DisplayName("建立時間")]
        public DateTime StockDetail_Create_DT { get; set; }

        [DisplayName("建立人員")]
        public string StockDetail_Create_Name { get; set; }

    }

    public class StockViewModel
    {

        [DisplayName("料號/編號")]
        [Required]
        public string Master_ID { get; set; }


        [DisplayName("料號/編號種類")]
        [Required]
        public string MasterID_Type { get; set; }


        [DisplayName("入庫數量")]
        public long InBound { get; set; }

        [DisplayName("出庫數量")]
        public long OutBound { get; set; }

        [DisplayName("報廢數量")]
        public long ScrapBound { get; set; }

        [DisplayName("備註")]
        public string Memo { get; set; }


        [DisplayName("建立時間")]
        public DateTime Create_DT { get; set; }






    }


}

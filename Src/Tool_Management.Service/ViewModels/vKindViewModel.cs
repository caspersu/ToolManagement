using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tool_Management.Service.ViewModels
{
    public class vKindViewModel
    {
        [DisplayName("類別")]
        [Required]
        public string Kind { get; set; }

        [DisplayName("料號/編號")]
        [Required]
        public string ID { get; set; }

        [DisplayName("名稱")]
        [Required]
        public string Name {get; set;}

       
    }
}

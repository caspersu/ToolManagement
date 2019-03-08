using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNC_Transfer
{
    class LOG
    {
        public string CNC_IP { get; set; }
        public string CNC_ALARM_CODE { get; set; }
        public string CNC_ALARM_MSG { get; set; }
        public string CNC_ALARM_DT { get; set; }
        public string CNC_LineNo { get; set; }

        public string CNC_OperationNo { get; set; }

        public string CNC__Coordinate_X { get; set; } //座標x
        public string CNC_ATCTL_ID { get; set; } //主軸刀具
        public string CNC_RunProgramBank { get; set; } //執行程序塊

    }
}

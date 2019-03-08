using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNC_Transfer
{
    class StatusHistory
    {
        public string CNC_IP { get; set; }
        public string Create_DT { get; set; }
        public string CNC_CalcDT { get; set; }
        public string CNC_CloseTime { get; set; } //1->關閉時間
        public string CNC_StayTime { get; set; } //2->待機時間
        public string CNC_RunTime { get; set; } //3->運行時間
        public string CNC_StopTime { get; set; } //4->停止時間
        public string CNC_ErrTime { get; set; } //5->錯誤時間
        
    }
}

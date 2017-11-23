using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DCSB
{
    public class NBDataModel
    {
        public string DateTime { get; set; }
        public string TimeStamp { get; set; }
        
        public string MSG_ERR_CFG_OVERRIDE { get; set; }
        public string MSG_ERR_NOT_PROVISIONED { get; set; } 
        
        /// <summary>
        /// 原始EEG数据
        /// </summary>
        public string Raw { get; set; }        
        /// <summary>
        /// 性能区域
        /// </summary>
        public string Zone { get; set; }
        /// <summary>
        /// Noise 等于0其他数据才有效
        /// </summary>
        public string PoorSignal { get; set; }
        /// <summary>
        /// 专注度
        /// </summary>
        public string Attention { get; set; }
        /// <summary>
        /// 冥想度
        /// </summary>
        public string Meditation { get; set; }                
        /// <summary>
        /// 眨眼
        /// </summary>
        public string BlinkStrength { get; set; } //if (setBlinkDetectionEnabled(true))
        /// <summary>
        /// 脑力劳动
        /// </summary>
        public string MentalEffort { get; set; } // if (setMentalEffortEnable(true))    算法连续运行 if (setMentalEffortRunContinuous(true))
        /// <summary>
        /// 熟练度
        /// </summary>
        public string TaskFamiliarity { get; set; } //if (setTaskFamiliarityEnable(true)) setTaskFamiliarityRunContinuous(true)

        //积极性:目前这个功能还不可用
        //public string Positivity { get; set; } //*        

        //其他可能用到的数据
        public string EegPowerDelta { get; set; }
        public string EegPowerTheta { get; set; }
        public string EegPowerAlpha1 { get; set; }
        public string EegPowerAlpha2 { get; set; }
        public string EegPowerBeta1 { get; set; }
        public string EegPowerBeta2 { get; set; }
        public string EegPowerGamma1 { get; set; }
        public string EegPowerGamma2 { get; set; }

    }

  

    public class DCDataModel
    {        
        /// <summary>
        /// 0代表未收录,1代表模糊,2代表生词,3代表熟悉
        /// </summary>
        public int CK { get; set; }
        
        public string English { get; set; }
        
        public string Chinese { get; set; }
    }

}

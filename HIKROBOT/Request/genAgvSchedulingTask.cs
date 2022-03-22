using HIKROBOT.Common;
using System.Collections.Generic;

namespace HIKROBOT.Request
{
    public class genAgvSchedulingTask
    {
        public string reqCode { get; set; }
        public string reqTime { get; set; }
        public string clientCode { get; set; }
        public string tokenCode { get; set; }
        public string taskTyp { get; set; }
        public string sceneTyp { get; set; }
        public string ctnrTyp { get; set; }
        public string ctnrCode { get; set; }
        public string wbCode { get; set; }
        public List<positionCodePath> positionCodePath { get; set; }
        public string podCode { get; set; }
        public string podDir { get; set; }
        public string podTyp { get; set; }
        public string materialLot { get; set; }
        public string priority { get; set; }
        public string agvCode { get; set; }
        public string taskCode { get; set; }
        public string data { get; set; }
    }
}

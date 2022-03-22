using System.Collections.Generic;


namespace XmlReaderSampleCode.Models
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class NeighbInfo
    {
        public object id { get; set; }
        public object distance { get; set; }
        public object Rever { get; set; }
        public object Speed { get; set; }
        public object Ultrasonic { get; set; }
        public object LeftWidth { get; set; }
        public object RightWidth { get; set; }
        public object robottype { get; set; }
        public object PodDir { get; set; }
    }

    public class PointInfo
    {
        public string id { get; set; }
        public string xpos { get; set; }
        public string ypos { get; set; }
        public string width { get; set; }
        public string height { get; set; }
        public string value { get; set; }
        public string RoadProperty { get; set; }
        public string Rot { get; set; }
        public string alldirRot { get; set; }
        public string Dir { get; set; }
        public string allDir { get; set; }
        public string RotUnderPod { get; set; }
        public string TranZoneType { get; set; }
        public NeighbInfo NeighbInfo { get; set; }
    }

    public class MapCfg
    {
        public string MapName { get; set; }
        public string MapType { get; set; }
        public string MapQRCode { get; set; }
        public string Row { get; set; }
        public string Col { get; set; }
        public string Width { get; set; }
        public string Height { get; set; }
        public List<PointInfo> PointInfo { get; set; }
        public string PodPosTrust { get; set; }
        public string ActUnderPod { get; set; }
        public string XOffset { get; set; }
        public string YOffset { get; set; }
    }

    public class Root
    {
        public MapCfg MapCfg { get; set; }
    }


}

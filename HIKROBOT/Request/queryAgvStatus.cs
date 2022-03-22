namespace HIKROBOT.Request
{
    public class queryAgvStatus
    {
        /// <summary>
        /// 請求編號
        /// </summary>
        public string reqCode { get; set; }
        public string reqTime { get; set; }
        public string clientCode { get; set; }
        public string tokenCode { get; set; }
        public string mapShortName { get; set; }
    }
}

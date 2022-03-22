namespace HIKROBOT.Reponse
{
    public class QueryAgvStatusRep
    {
        /// <summary>
        /// 返回碼
        /// </summary>
        public string code { get; set; }
        /// <summary>
        /// 所有機器人資料
        /// </summary>
        public QueryAgvStatusData[] data { get; set; }
        /// <summary>
        /// 返回消息
        /// </summary>
        public string message { get; set; }
        /// <summary>
        /// 請求編號
        /// </summary>
        public string reqCode { get; set; }
    }
}

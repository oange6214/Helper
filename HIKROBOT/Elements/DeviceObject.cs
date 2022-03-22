namespace HIKROBOT.Elements
{
    public class DeviceObject
    {
        /// <summary>
        /// 設備 IP
        /// </summary>
        public string DeviceIP { get; set; }

        /// <summary>
        /// 設備名稱
        /// </summary>
        public string DeviceName { get; set; }

        /// <summary>
        /// 當前位置
        /// </summary>
        public string CurrentPosition { get; set; }

        /// <summary>
        /// 設備方向
        /// </summary>
        public string DeivceDirection { get; set; }

        /// <summary>
        /// 是否可用
        /// </summary>
        public string IsUsable { get; set; }

        /// <summary>
        /// 執行狀態
        /// </summary>
        public string ExecutionStatus { get; set; }

        /// <summary>
        /// 貨價編號
        /// </summary>
        public string ShelfNumber { get; set; }

        /// <summary>
        /// 目標位置
        /// </summary>
        public string TargetPosition { get; set; }

        /// <summary>
        /// 貨架方向
        /// </summary>
        public string ShelfDirection { get; set; }

        /// <summary>
        /// 任務編號
        /// </summary>
        public string TaskNumber { get; set; }
    }
}

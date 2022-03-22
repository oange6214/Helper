using System;
using System.Collections.Generic;

namespace HIKROBOT.Reponse
{
    public class QueryAgvStatusData : EventArgs
    {
        /// <summary>
        /// 機器人編號
        /// </summary>
        public string robotCode { get; set; }
        /// <summary>
        /// 機器人方向
        /// </summary>
        public string robotDir { get; set; }
        /// <summary>
        /// 機器人 IP
        /// </summary>
        public string robotIp { get; set; }
        /// <summary>
        /// 機器人電量，範圍：0~100
        /// </summary>
        public string battery { get; set; }
        /// <summary>
        /// 機器人 X 座標，單位：毫米
        /// </summary>
        public string posX { get; set; }
        /// <summary>
        /// 機器人 Y 座標，單位：毫米
        /// </summary>
        public string posY { get; set; }
        /// <summary>
        /// 機器人所在地圖
        /// </summary>
        public string mapCode { get; set; }
        /// <summary>
        /// 機器人當前速度，單位：mm/s
        /// </summary>
        public string speed { get; set; }
        /// <summary>
        /// 機器人狀態
        /// </summary>
        public string status { get; set; }
        /// <summary>
        /// 是否已被排除，被排除後不接受新任務（1：排除，0：正常）
        /// </summary>
        public string exclType { get; set; }
        /// <summary>
        /// 是否暫停（0：否，1：是）
        /// </summary>
        public string stop { get; set; }
        /// <summary>
        /// 背貨架的編號
        /// </summary>
        public string podCode { get; set; }
        /// <summary>
        /// 背貨架的方向
        /// </summary>
        public string podDir { get; set; }
        /// <summary>
        /// 執行路徑，單位是毫米，格式 X 軸、Y軸、方向
        /// 範例：[ "[x, y, dir]", "[x, y, dir]", "[x, y, dir]" ]
        /// </summary>
        public Dictionary<string, string>[] path { get; set; }

    }
}

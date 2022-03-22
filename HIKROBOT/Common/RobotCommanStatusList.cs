namespace HIKROBOT.Common
{
    public enum RobotStatusList
    {
        /// <summary>
        /// 任務完成
        /// </summary>
        TaskCompleted = 1,
        /// <summary>
        /// 任務執行中
        /// </summary>
        ExecutingTask = 2,
        /// <summary>
        /// 任務異常
        /// </summary>
        AbnormalTask = 3,
        /// <summary>
        /// 任務空閒
        /// </summary>
        IdleTask = 4,
        /// <summary>
        /// 機器人暫停
        /// </summary>
        RobotStopped = 5,
        /// <summary>
        /// 舉升貨架狀態
        /// </summary>
        LiftingShelfStatus = 6,
        /// <summary>
        /// 充電狀態
        /// </summary>
        ChargingStatus = 7,
        /// <summary>
        /// 弧線行走中
        /// </summary>
        BatteryArcingInProgress = 8,
        /// <summary>
        /// 充滿維護
        /// </summary>
        FullyCharged = 9,
        /// <summary>
        /// 背貨未識別
        /// </summary>
        CarriedItemNotRecognized = 11,
        /// <summary>
        /// 貨架偏角過大
        /// </summary>
        ExcessiveShelfAngleDivergence = 12,
        /// <summary>
        /// 運動庫異常
        /// </summary>
        MotionLibradryException = 13,
        /// <summary>
        /// 貨碼無法識別
        /// </summary>
        UnableToRecogniseProductCode = 14,
        /// <summary>
        /// 貨碼不匹配
        /// </summary>
        ProductCodeMismaatch = 15,
        /// <summary>
        /// 舉升異常
        /// </summary>
        LiftAbnormal = 16,
        /// <summary>
        /// 充電樁異常
        /// </summary>
        ChargingPostAAbnormal = 17,
        /// <summary>
        /// 電量無增加
        /// </summary>
        NoIncreaseInCurrent = 18,
        /// <summary>
        /// 通電指令角度錯誤
        /// </summary>
        AngleErrorInChargingDirective = 20,
        /// <summary>
        /// 平台下發指令錯誤
        /// </summary>
        PlatformDecentralisationDirectiveError = 21,
        /// <summary>
        /// 外力下放
        /// </summary>
        ExternalForceUnLoading = 23,
        /// <summary>
        /// 貨架位置偏移
        /// </summary>
        MisalignedShelf = 24,
        /// <summary>
        /// 小車不在鎖定區
        /// </summary>
        TrolleyNotInDesignatedZone = 25,
        /// <summary>
        /// 下放重試失敗
        /// </summary>
        DecentralisationFailed = 26,
        /// <summary>
        /// 貨架擺歪
        /// </summary>
        UnevenShelf = 27,
        /// <summary>
        /// 舉升電池電量太低
        /// </summary>
        LiftBatteryCurrentTooLow = 28,
        /// <summary>
        /// 後退角度偏大
        /// </summary>
        WideReversingAngle = 29,
        /// <summary>
        /// 未背貨架舉升
        /// </summary>
        NoRackDetected = 30,
        /// <summary>
        /// 區域鎖定失敗
        /// </summary>
        FailedToLockZone = 31,
        /// <summary>
        /// 旋轉申請暫時失敗
        /// </summary>
        RotationRequestTemporarilyFailed = 33,
        /// <summary>
        /// 地圖切換點地碼未標示
        /// </summary>
        UnableToRecogniseCoordinatesToSwitchMaps = 34
    }
}

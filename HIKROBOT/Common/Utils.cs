using System;
using System.Windows;

namespace HIKROBOT.Common
{
    #region Enum
    public enum CoordinateUnit
    {
        mm = 0,
        cm = 1,
        m = 2,
        km = 3
    }
    #endregion


    public static class Common
    {
        #region
        /// <summary>
        /// 以寬度為準，縮放物件尺寸
        /// </summary>
        /// <param name="imgWidth">寬</param>
        /// <param name="imgHeight">高</param>
        /// <param name="targetSize">目標尺寸</param>
        /// <returns></returns>
        public static Size ReScaleValue(double imgWidth, double imgHeight, int targetSize)
        {
            double scale = 1 - Math.Abs(imgWidth - targetSize) / imgWidth;

            return new Size(imgWidth * scale, imgHeight * scale);
        }

        /// <summary>
        /// 取得座標轉換後的值
        /// </summary>
        /// <param name="data">原始資料</param>
        /// <param name="ConversionType">座標單位</param>
        /// <returns></returns>
        public static double ConvertToCoordinate<T>(this T data, CoordinateUnit ConversionType = CoordinateUnit.m)
        {
            var d = double.Parse(data.ToString());

            switch (ConversionType)
            {
                case CoordinateUnit.cm:
                    return d / 10;
                case CoordinateUnit.m:
                    return d / 10 / 100;
                case CoordinateUnit.km:
                    return d / 10 / 100 / 1000;
                default:
                    return d;
            }
        }
        #endregion
    }
}

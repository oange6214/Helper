using HIKROBOT.Common;
using HIKROBOT.Elements;
using HIKROBOT.Reponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace HIKROBOT.Robots
{
    public class AGV : RobotObject
    {
        public AGV()
        {
            // 初始化
            //AgvStatusData = agvStatusData;

            //SourceImage = @"Assets\img\AGV.png";

            //SetPosistion(AgvStatusData.posX, AgvStatusData.posY);

            timer = new DispatcherTimer { Interval = TimeSpan.FromMilliseconds(33) };

            timer.Tick += (s, e) =>
            {
                //Position = new Vector(Position.X + 100, Position.Y);
                //this.Translate(Position.X, Position.Y);
                this.X += _speed;
            };

            timer.Start();

        }

        public DispatcherTimer timer;

        private QueryAgvStatusData _agvStatusData;
        /// <summary>
        /// 物件狀態
        /// </summary>
        public QueryAgvStatusData AgvStatusData
        {
            get { return _agvStatusData; }
            set
            {
                _agvStatusData = value;
                X = _agvStatusData.posY.ConvertToCoordinate<string>();
                Y = _agvStatusData.posY.ConvertToCoordinate<string>();
            }
        }

        private DeviceObject _deviceObject;

        public DeviceObject AgvStatusPanel
        {
            get { return _deviceObject; }
            set { _deviceObject = value; }
        }

        private double _speed = 10;

        public double Speed
        {
            get { return _speed; }
            set { _speed = value; }
        }

    }
}

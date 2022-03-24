using Common;
using HIKROBOT.Common;
using HIKROBOT.Elements;
using HIKROBOT.Reponse;
using System;
using System.Diagnostics;
using System.Windows.Threading;

namespace HIKROBOT.Robots
{
    public class AGV : PointObject
    {
        public AGV()
        {

        }
        public AGV(int MoveStage) : base()
        {
            switch (MoveStage)
            {
                case 0:
                    // 每秒 60 frame，移動速度 10 pixel/frame
                    timer = new DispatcherTimer { Interval = TimeSpan.FromMilliseconds(1000 / 60) };

                    timer.Tick += (s, e) =>
                    {
                        this.X += 1.0f * _speed;

                        Console.WriteLine(1.0f * _speed);
                    };

                    timer.Start();
                    break;
                case 1:
                    // 隨著 WPF frame Render，動態變更 移動速度 （pixel/frame）
                    stopWatch.Start();
                    CompositionTargetEx.Rendering += Rendering;
                    break;
            }


        }

        private Stopwatch stopWatch = new Stopwatch();
        private double DeltaTime;
        private double Secondframe;


        private void Rendering(object sender, EventArgs e)
        {
            TimeSpan ts = stopWatch.Elapsed;
            double FirstFrame = ts.TotalMilliseconds;

            DeltaTime = FirstFrame - Secondframe;

            Console.WriteLine(1.0f * _speed * DeltaTime / 1000 * 60);

            this.X += 1.0f * _speed * DeltaTime / 1000 * 60;

            Secondframe = ts.TotalMilliseconds;
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

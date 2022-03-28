using Common;
using CreateMapSample.Models;
using HIKROBOT.Elements;
using HIKROBOT.Reponse;
using HIKROBOT.Request;
using HIKROBOT.Robots;
using HTTP;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Configuration;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Data;
using XML;

namespace CreateMapSample.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public MainViewModel()
        {
            MapDirSearch(@"D:\C#\DrawSampleCode\XmlReaderSampleCode\CreateMapSample\Assets\");



            StageCollection.Add(new CollectionContainer() { Collection= StageAGVs });
            StageCollection.Add(new CollectionContainer() { Collection = StageCharginPiles });
        }


        #region -- Properties -- 
        public int MoveState { get; set; } = 0;

        /// <summary>
        /// 地圖寬度
        /// </summary>
        private double _mapWidth;
        public double MapWidth
        {
            get { return _mapWidth; }
            set { _mapWidth = value; NotifyPropertyChanged(); }
        }

        /// <summary>
        /// 地圖高度
        /// </summary>
        private double _mapHeight;
        public double MapHeight
        {
            get { return _mapHeight; }
            set { _mapHeight = value; NotifyPropertyChanged(); }
        }

        private double _xOffset;

        public double XOffset
        {
            get { return _xOffset; }
            set { _xOffset = value; }
        }

        private double _yOffset;

        public double YOffset
        {
            get { return _yOffset; }
            set { _yOffset = value; }
        }


        /// <summary>
        /// 現在地圖(由下拉選擇)
        /// </summary>
        private string _mapSelect;
        public string MapSelect
        {
            get { return _mapSelect; }
            set
            {
                _mapSelect = value;
                MapInfo = GetMapInfomation(MapQueueDict[MapSelect]);
            }
        }

        /// <summary>
        /// 地圖資訊
        /// </summary>
        private MapCfg _mapInfo;
        public MapCfg MapInfo
        {
            get { return _mapInfo; }
            set
            {
                _mapInfo = value;
                SetMap(value);
            }
        }

        public CompositeCollection StageCollection { get; set; } = new CompositeCollection();

        /// <summary>
        /// 舞台上 AGV
        /// </summary>
        public ObservableCollection<AGV> StageAGVs { get; private set; } = new ObservableCollection<AGV>();
        public ObservableCollection<PointObject> StageCharginPiles { get; private set; } = new ObservableCollection<PointObject>();

        /// <summary>
        /// 地圖列表名稱
        /// </summary>
        public Dictionary<string, string> MapQueueDict { get; private set; } = new Dictionary<string, string>();

        #endregion


        #region -- Commands -- 

        /// <summary>
        /// （測試用）查詢 AGV 狀態命令
        /// </summary>
        public RelayCommand QueryAgvStatusCommand
        {
            get
            {
                return new RelayCommand(BuildAgvStatusAsync);
            }
        }

        /// <summary>
        /// (測試用)查詢 Normal AGV 狀態命令
        /// </summary>
        public RelayCommand QueryNormalAgvStatusCommand
        {
            get
            {
                return new RelayCommand(BuildNormalAgvStatusAsync);
            }
        }

        /// <summary>
        /// (測試用)查詢 Normal AGV 狀態命令
        /// </summary>
        public RelayCommand QueryAnimationAgvStatusCommand
        {
            get
            {
                return new RelayCommand(BuildAnimationAgvStatusAsync);
            }
        }

        #endregion


        #region -- Private Methods-- 

        /// <summary>
        /// 取得地圖詳細資訊
        /// </summary>
        /// <param name="filePath">目標檔案路徑</param>
        private MapCfg GetMapInfomation(string filePath)
        {
            string xmlStr = XMLHelper.XmlToXmlStream(filePath, false);  // XML 解析
            string jsonStr = XMLHelper.XmlToJson(xmlStr);               // XML To JSON

            return JsonConvert.DeserializeObject<Root>(jsonStr).MapCfg;  // JSON To Object（Root）
        }

        private void SetMap(MapCfg mapCfg)
        {
            StageCharginPiles.Clear();

            XOffset = double.Parse(mapCfg.XOffset);
            YOffset = double.Parse(mapCfg.YOffset);
            MapWidth = double.Parse(mapCfg.Width);
            MapHeight = double.Parse(mapCfg.Height);

            foreach (var pointInfo in mapCfg.PointInfo)
            {
                PointObject point = null;
                pointInfo.xpos = ((double.Parse(pointInfo.xpos) - 100) * 100 + 100 + 20).ToString();
                pointInfo.ypos = ((double.Parse(pointInfo.ypos) - 100) * 100 + 100 + 20).ToString();
                pointInfo.width = (double.Parse(pointInfo.width) * 100).ToString();
                pointInfo.height = (double.Parse(pointInfo.height) * 100).ToString();

                switch (pointInfo.value)
                {
                    case "10":
                        point = new ChargingPile()
                        {
                            X = double.Parse(pointInfo.xpos),
                            Y = double.Parse(pointInfo.ypos),
                            Width = double.Parse(pointInfo.width),
                            Height = double.Parse(pointInfo.height),
                            SourceImage = @".\Images\WMS.png"
                        };
                        break;
                    case "11":
                        point = new ChargingPile()
                        {
                            X = double.Parse(pointInfo.xpos),
                            Y = double.Parse(pointInfo.ypos),
                            Width = double.Parse(pointInfo.width),
                            Height = double.Parse(pointInfo.height),
                            SourceImage = @".\Images\ChargingPile.png"
                        };
                        break;
                    case "16":
                        point = new ChargingPile()
                        {
                            X = double.Parse(pointInfo.xpos),
                            Y = double.Parse(pointInfo.ypos),
                            Width = double.Parse(pointInfo.width),
                            Height = double.Parse(pointInfo.height),
                            SourceImage = @".\Images\Point.png"
                        };
                        break;
                    case "19":
                        point = new ChargingPile()
                        {
                            X = double.Parse(pointInfo.xpos),
                            Y = double.Parse(pointInfo.ypos),
                            Width = double.Parse(pointInfo.width),
                            Height = double.Parse(pointInfo.height),
                            SourceImage = @".\Images\Park.png"
                        };
                        break;
                }

                StageCharginPiles.Add(point);
            }
        }



        /// <summary>
        /// 所有地圖查詢
        /// </summary>
        /// <param name="sDir"></param>
        private void MapDirSearch(string sDir)
        {
            try
            {
                // 對目前目錄的檔案做處理
                foreach (string fname in Directory.GetFiles(sDir))
                {
                    string xmlStr = XMLHelper.XmlToXmlStream(fname, false);  // XML 解析
                    //string jsonStr = XMLHelper.XmlToJson(xmlStr);               // XML To JSON

                    MapQueueDict.Add(XMLHelper.XmlGetNode(xmlStr, "MapName"), fname);
                    if (MapQueueDict.Count == 1) MapSelect = XMLHelper.XmlGetNode(xmlStr, "MapName");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// 查詢 AGV 狀態（Method Body）
        /// </summary> 
        private async void BuildAnimationAgvStatusAsync()
        {
            QueryAgvStatusRep queryAgvStatusRep = await QueryAgvStatusAsync<QueryAgvStatusRep, queryAgvStatus>(new queryAgvStatus
            {
                reqCode = "468513",
                reqTime = "",
                clientCode = "SAA",
                tokenCode = "RCSTest",     // 令牌號，由調度系統頒發。如果填寫， 需先在 RCS 系統配置，上層系統呼叫時進行填寫。
                mapShortName = "map001"
            });

            if (queryAgvStatusRep == null) return;

            foreach (QueryAgvStatusData agvStatusData in queryAgvStatusRep.data)
            {
                StageAGVs.Add(new AGV(0)
                {
                    AgvStatusData = agvStatusData,
                    Width = 50,
                    Height = 50,
                    SourceImage = @".\Images\AGV.png"
                });
            }
        }

        /// <summary>
        /// 查詢 AGV 狀態（Method Body）
        /// </summary> 
        private async void BuildNormalAgvStatusAsync()
        {
            QueryAgvStatusRep queryAgvStatusRep = await QueryAgvStatusAsync<QueryAgvStatusRep, queryAgvStatus>(new queryAgvStatus
            {
                reqCode = "468513",
                reqTime = "",
                clientCode = "SAA",
                tokenCode = "RCSTest",     // 令牌號，由調度系統頒發。如果填寫， 需先在 RCS 系統配置，上層系統呼叫時進行填寫。
                mapShortName = "map001"
            });

            if (queryAgvStatusRep == null) return;

            foreach (QueryAgvStatusData agvStatusData in queryAgvStatusRep.data)
            {
                StageAGVs.Add(new AGV(0)
                {
                    AgvStatusData = agvStatusData,
                    Width = 50,
                    Height = 50,
                    SourceImage = @".\Images\AGV.png"
                });
            }
        }

        /// <summary>
        /// 查詢 AGV 狀態（Method Body）
        /// </summary> 
        private async void BuildAgvStatusAsync()
        {
            QueryAgvStatusRep queryAgvStatusRep = await QueryAgvStatusAsync<QueryAgvStatusRep, queryAgvStatus>(new queryAgvStatus
            {
                reqCode = "468513",
                reqTime = "",
                clientCode = "SAA",
                tokenCode = "RCSTest",     // 令牌號，由調度系統頒發。如果填寫， 需先在 RCS 系統配置，上層系統呼叫時進行填寫。
                mapShortName = "map001"
            });

            if (queryAgvStatusRep == null) return;

            foreach (QueryAgvStatusData agvStatusData in queryAgvStatusRep.data)
            {
                //AGV agv = StageAGVs.FirstOrDefault(x => x.AgvStatusData.robotCode == agvStatusData.robotCode);
                //MonitorAgvPanel mAgv = MonitorAgvPanels.FirstOrDefault(x => x.RobotCode == agvStatusData.robotCode);

                //if (agv == null && mAgv == null)
                {
                    StageAGVs.Add(new AGV(1)
                    {
                        AgvStatusData = agvStatusData,
                        Width = 50,
                        Height = 50,
                        SourceImage = @".\Images\AGV.png"
                    });
                }
                //else
                {
                    //MonitorAgv targetMAgv = MonitorAgvPanels.FirstOrDefault(x => x.Name == agvStatusData.robotCode);

                    //targetMAgv.RobotCode = agvStatusData.robotCode;
                    //targetMAgv.RobotConnectStatus = string.IsNullOrEmpty(agvStatusData.battery) ? "離線" : "線上";
                    //targetMAgv.RobotDir = agvStatusData.robotDir;
                    //targetMAgv.Battery = agvStatusData.battery;
                    //targetMAgv.PosX = agvStatusData.posX;
                    //targetMAgv.PosY = agvStatusData.posY;
                    //targetMAgv.CurrentStatus = "init";

                    //AGV targetSAgv = StageAGVs.FirstOrDefault(x => x.AgvStatusData.robotCode == agvStatusData.robotCode);
                    //targetSAgv.AgvStatusData = agvStatusData;
                }
            }

            //MonitorAgvStatusNum[0] = MonitorAgvPanels.Count;
            //MonitorAgvStatusNum[1] = MonitorAgvPanels.Count;
        }

        /// <summary>
        /// 查詢方法
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        private async Task<TResult> QueryAgvStatusAsync<TResult, TData>(TData data)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            string uri = $"http://{config.AppSettings.Settings["Server"].Value}/rcms-dps/rest/queryAgvStatus";

            HttpHelper httpHelper = new HttpHelper(uri);

            return JsonToObject<TResult>(await httpHelper.HttpClientPostAsync(data));
        }

        /// <summary>
        /// JSON To 指定物件
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        private T JsonToObject<T>(string data)
        {
            try
            {
                return JsonConvert.DeserializeObject<T>(data);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion


        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}

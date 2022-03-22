using Common;
using HIKROBOT.Reponse;
using HIKROBOT.Request;
using HIKROBOT.Robots;
using HTTP;
using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace CreateMapSample.ViewModels
{
    public class MainViewModel
    {
        public double MapWidth { get; set; } = 500;
        public double MapHeight { get; set; } = 500;
        /// <summary>
        /// 舞台上 AGV
        /// </summary>
        public ObservableCollection<AGV> StageAGVs { get; private set; } = new ObservableCollection<AGV>();

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
        /// 查詢 AGV 狀態（Method Body）
        /// </summary> 
        public async void BuildAgvStatusAsync()
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
                    AddAGV(agvStatusData);
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
        /// 顯示於舞台、面板
        /// </summary>
        /// <param name="agvStatusData"></param>
        private void AddAGV(QueryAgvStatusData agvStatusData)
        {
            // 動態建立 AGV 到舞台上
            StageAGVs.Add(new AGV
            {
                AgvStatusData = agvStatusData,
                Width = 50,
                Height = 50,
                SourceImage = @".\Images\AGV.png"
            });
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
    }
}

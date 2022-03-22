using Log4NetHelper;
using Newtonsoft.Json;
using System;
using XML;
using XmlReaderSampleCode.Models;

namespace XmlReaderSampleCode
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 第一種記錄用法
            // （1）Program 是類別名稱
            // （2）第二個參數是字串訊息
            //LogHelper.WriteLog(typeof(Program), "測試 Log4Net 日誌是否寫入");


            //string filePath = @"D:\C#\DrawSampleCode\HelperSample\HelperSample\Source\username.csv";
            string filePath = @"D:\C#\DrawSampleCode\XmlReaderSampleCode\XmlReaderSampleCode\Assets\xmlFile.xml";

            //var dt = CsvHelper.GetDatatTableFromCsv(strFilePath);

            var xmlStream = XMLHelper.XmlToXmlStream(filePath, false);
            var json = XMLHelper.XmlToJson(xmlStream);

            //xml.Deserialize<Root>();

            var demo = JsonConvert.DeserializeObject<Root>(json);


            //var x = XmlHelper.JsonToDataTable<Root>(xml);

            //var str = XmlHelper.XmlToJsonString(filePath);

            //List<Root> mapCfgs = JsonConvert.DeserializeObject<List<Root>>(jsonString);


            Console.ReadKey();
        }
    }
}

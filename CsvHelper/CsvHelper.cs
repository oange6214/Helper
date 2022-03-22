using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace CsvHelper
{
    public class CsvHelper
    {
        /// <summary>
        /// 從 Csv 取得資料，並轉換成 DataTable
        /// </summary>
        /// <param name="strFilePath">Csv 檔案路徑</param>
        /// <param name="delimiter">分隔符</param>
        /// <returns>傳回 DataTable</returns>
        public static DataTable CsvToDataTable(string csvFile, char delimiter = ',')
        {
            using (StreamReader sr = new StreamReader(csvFile))
            {
                string[] headers = sr.ReadLine().Split(';');
                DataTable dt = new DataTable();
                foreach (string header in headers)
                {
                    dt.Columns.Add(header);
                }

                while (!sr.EndOfStream)
                {
                    string pattern = $"{delimiter}(?=(?:[^\"]*\"[^\"]*\")*[^\"]*$)";
                    string[] rows = Regex.Split(sr.ReadLine(), pattern);

                    if (rows.Count() < headers.Length) continue;

                    DataRow dr = dt.NewRow();
                    for (int i = 0; i < headers.Length; i++)
                    {
                        try
                        {
                            dr[i] = rows[i];
                        }
                        catch (Exception ex) { }
                    }
                    dt.Rows.Add(dr);
                }
                sr.Dispose();
                return dt;
            }
        }

        public static DataTable TxtToDataTable(string txtFile, char delimiter = ',')
        {
            DataTable dt = new DataTable();

            return dt;
        }
    }
}

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace XML
{
    public static class XMLHelper
    {
        #region Enum
        public enum XMLType
        {
            Stream,
            File
        }
        #endregion


        public static string Serialize(object obj)
        {
            XmlSerializerNamespaces xmlSN = new XmlSerializerNamespaces();
            xmlSN.Add("", "");
            XmlSerializer XmlS = new XmlSerializer(obj.GetType());
            MemoryStream ms = new MemoryStream();
            StreamWriter sw = new StreamWriter(ms);
            XmlS.Serialize(sw, obj, xmlSN);
            return Encoding.UTF8.GetString(ms.ToArray(), 0, (int)ms.Length);
        }

        public static T Deserialize<T>(string str)
        {
            XmlDocument xDoc = new XmlDocument();

            try
            {
                xDoc.LoadXml(str);
                XmlNodeReader reader = new XmlNodeReader(xDoc.DocumentElement);
                XmlSerializer serial = new XmlSerializer(typeof(T));
                object obj = serial.Deserialize(reader);
                return (T)obj;
            }
            catch (Exception)
            {
                return default;
            }
        }

        public static object Deserialize(Type type, string xmlFile)
        {
            try
            {
                using (StringReader sr = new StringReader(xmlFile))
                {
                    XmlSerializer serial = new XmlSerializer(type);
                    return serial.Deserialize(sr);
                }
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        /// <summary>
        /// 讀取 Xml 檔案，並轉換成 DataTable
        /// </summary>
        /// <param name="xmlPath">Xml 路徑</param>
        /// <returns>傳回 DataTable</returns>
        public static DataTable XmlToDataTable(string xmlFile)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(xmlFile);
            XmlReader xmlReader = XmlReader.Create(new System.IO.StringReader(xmlDoc.OuterXml));
            DataSet ds = new DataSet();
            ds.ReadXml(xmlReader);
            DataTable dt = ds.Tables[0];
            return dt;
        }

        public static DataTable JsonToDataTable<T>(this IList<T> data)
        {
            PropertyDescriptorCollection props = TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            for (int i = 0; i < props.Count; i++)
            {
                PropertyDescriptor prop = props[i];
                table.Columns.Add(prop.Name, prop.PropertyType);
            }
            object[] values = new object[props.Count];
            foreach (T item in data)
            {
                for (int i = 0; i < values.Length; i++)
                {
                    values[i] = props[i].GetValue(item);
                }
                table.Rows.Add(values);
            }
            return table;
        }

        /// <summary>
        /// XML String 或 XML File 轉 Json
        /// </summary>
        /// <param name="strXml">XML String or XML File</param>
        /// <param name="xmlType">XML Type</param>
        /// <returns>Return Json Formatter</returns>
        public static string XmlToJson(string strXml, XMLType xmlType = XMLType.Stream)
        {
            XmlDocument xmlDoc = new XmlDocument();

            switch (xmlType)
            {
                case XMLType.Stream:
                    xmlDoc.LoadXml(strXml);
                    break;
                case XMLType.File:
                    xmlDoc.Load(strXml);
                    break;
            }

            return JsonConvert.SerializeXmlNode(xmlDoc);
        }


        /// <summary>
        /// 讀取 XML 轉成 XML string
        /// </summary>
        /// <param name="xmlFile">Xml 檔路徑</param>
        /// <returns>傳回 Xml string</returns>
        public static string XmlToXmlStream(string xmlFile, bool keepHeader = true)
        {
            XmlReaderSettings settings = new XmlReaderSettings();
            settings.ConformanceLevel = ConformanceLevel.Fragment;
            settings.IgnoreWhitespace = true;
            settings.IgnoreComments = true;
            XmlReader reader = XmlReader.Create(xmlFile, settings);

            StringBuilder sb = new StringBuilder();

            while (reader.Read())
            {
                switch (reader.NodeType)
                {
                    case XmlNodeType.Element:
                        sb.AppendFormat("<{0}>", reader.Name);
                        break;
                    case XmlNodeType.Text:
                        sb.Append(reader.Value);
                        break;
                    case XmlNodeType.CDATA:
                        sb.AppendFormat("<![CDATA[{0}]]>", reader.Value);
                        break;
                    case XmlNodeType.ProcessingInstruction:
                        sb.AppendFormat("<?{0} {1}?>", reader.Name, reader.Value);
                        break;
                    case XmlNodeType.Comment:
                        sb.AppendFormat("<!--{0}-->", reader.Value);
                        break;
                    case XmlNodeType.XmlDeclaration:
                        if (keepHeader) sb.AppendFormat("<?xml version='1.0'?>");
                        break;
                    case XmlNodeType.Document:
                        break;
                    case XmlNodeType.DocumentType:
                        sb.AppendFormat("<!DOCTYPE {0} [{1}]", reader.Name, reader.Value);
                        break;
                    case XmlNodeType.EntityReference:
                        sb.Append(reader.Name);
                        break;
                    case XmlNodeType.EndElement:
                        sb.AppendFormat("</{0}>", reader.Name);
                        break;
                }
            }

            return sb.ToString();
        }

        public static string XmlGetNode(string xmlFile, string nodeName)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(xmlFile);
            XmlNodeList xmlNodeList = xmlDoc.SelectNodes("MapCfg/MapName", null);

            return xmlNodeList[0].InnerText;
        }
    }
}

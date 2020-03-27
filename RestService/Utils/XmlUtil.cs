using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace RestService.Util
{
    public class XmlUtil
    {
        public static string getXmlNode(string xml)
        {
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.LoadXml(xml);
            string result = getLastNode(xmlDocument.FirstChild).Value;
            return result;
        }        
                 
        private static XmlNode getLastNode(XmlNode xmlNode)
        {
            if (xmlNode.HasChildNodes)
            {
                xmlNode = getLastNode(xmlNode.FirstChild);
            }
            return xmlNode;
        }

        public static string getXmlUrlValue(string urlWayNode)
        {
            XmlDocument xmlDocument = new XmlDocument();
            try
            {
                xmlDocument.Load("Resources/setting.xml");
            } catch(Exception e)
            {
                LogHelper.Error("Failed to read xml file correctly", e);
            }
            
            XmlNodeList xmlNodeList = xmlDocument.GetElementsByTagName(urlWayNode);
            XmlNode xmlNode = xmlNodeList.Item(0);
            string result = xmlNode.FirstChild.Value;
            return result;
        }

        public static string getXmlDBValue(string dbNode)
        {
            XmlDocument xmlDocument = new XmlDocument();

            try
            {
                xmlDocument.Load("Resources/setting.xml");
            }
            catch (Exception e)
            {
                LogHelper.Error("Failed to read xml file correctly", e);
            }

            XmlNodeList xmlNodeList = xmlDocument.GetElementsByTagName(dbNode);
            XmlNode xmlNode = xmlNodeList.Item(0);
            string result = xmlNode.FirstChild.Value;
            return result;
        }
    }
}

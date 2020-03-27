using RestService.Util;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace RestService.RequestAPI
{
    public class RequestServices : IRequestServices
    {
        private static RequestServices requestServices = null;
        private static readonly Uri BASE_ZD_URL = new Uri(XmlUtil.getXmlUrlValue("ZDUrl"));
        private const string LT_REQUEST_HEAD_PREFIX = "<soapenv:Envelope xmlns:soapenv='http://schemas.xmlsoap.org/soap/envelope/' xmlns:ser='Serva.OperationControl.serva.com'><soapenv:Body>";
        private const string LT_REQUEST_HEAD_SUFFIX = "</soapenv:Body></soapenv:Envelope>";
      

        public struct Result
        {
            public string content;
            public string status;
            public string exception;
        }

        public static RequestServices Instance
        {
            get
            {
                if (requestServices == null)
                {
                    requestServices = new RequestServices();
                }
                return requestServices;
            }
            set
            {
            }
        }

        public Result RequestLTAPI(string content, WebRequest webRequest)
        {
            Result result;
            StringBuilder xmlContent = new StringBuilder();
            xmlContent.Append(LT_REQUEST_HEAD_PREFIX);
            xmlContent.Append(content);
            xmlContent.Append(LT_REQUEST_HEAD_SUFFIX);

            try
            {
                using (Stream requestStream = webRequest.GetRequestStream())
            {
                byte[] paramBytes = Encoding.UTF8.GetBytes(xmlContent.ToString());
                requestStream.Write(paramBytes, 0, paramBytes.Length);
            }
           
                WebResponse webResponse = webRequest.GetResponse();
                
                using (StreamReader myStreamReader = new StreamReader(webResponse.GetResponseStream(), Encoding.UTF8))
                {
                    result.content = XmlUtil.getXmlNode(myStreamReader.ReadToEnd());
                    result.status = "success";
                    result.exception = null;
                    return result;
                }
            }
            catch (Exception e)
            {
                LogHelper.Error("request is failed", e);
                result.content = null;
                result.status = "fail";
                result.exception = e.Message;
                return result;
            }
        }

        public string RequestZDAPI(string urlSuffix)
        {
            HttpContent httpContent = new StringContent("'body': {'ticketId':'1111', 'vtsId':'2'，'taskCode':'xian'}");
            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            HttpClient httpClient = new HttpClient();
            LogHelper.Info("Request url:" + BASE_ZD_URL + urlSuffix);

            HttpResponseMessage response = httpClient.PostAsync(BASE_ZD_URL + urlSuffix, httpContent).Result;

            if (response.IsSuccessStatusCode)
            {
                Task<string> t = response.Content.ReadAsStringAsync();
                LogHelper.Info(t.Result);
                return t.Result;
            }
            return string.Empty;
        }

    }
}

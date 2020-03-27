using System;
using System.ServiceModel.Web;
using System.ServiceModel;
using RestService.RestAPI;
using RestService.DataServices;


namespace RestService
{
    public class RestServiceApplication
    {

        public static RestServices restServices = RestServices.Instance;

        static void Main(string[] args)
        {
            try
            {                
                WebServiceHost _serviceHost = new WebServiceHost(restServices, new Uri($"http://localhost:8000/RestService"));
                //设置信息传输大小
                WebHttpBinding binding = new WebHttpBinding
                {
                    TransferMode = TransferMode.Buffered,
                    MaxBufferSize = 2147483647,
                    MaxReceivedMessageSize = 2147483647,
                    MaxBufferPoolSize = 2147483647,
                    ReaderQuotas = System.Xml.XmlDictionaryReaderQuotas.Max,
                    Security = { Mode = WebHttpSecurityMode.None }
                };
                LogHelper.Info("Service started success");
                //_serviceHost.Open();
                Console.ReadLine();
                //Console.ReadLine();
                //Console.ReadLine();
                _serviceHost.Close();
                //LogHelper.Info("Service closed success");
            } catch(Exception e)
            {
                LogHelper.Error("Service stared failure", e);
            }

            //MysqlServices mysqlConnect = new MysqlServices();
            //mysqlConnect.Insert();
            


        }

    }
}
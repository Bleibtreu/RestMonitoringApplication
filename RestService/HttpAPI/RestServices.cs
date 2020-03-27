using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Net;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using RestService.RequestAPI;
using RestService.Util;
using static RestService.RequestAPI.RequestServices;

public delegate void RestListen(string id, string direction, string url, string attribution, DateTime occurrence_time, string status);
namespace RestService.RestAPI
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, ConcurrencyMode = ConcurrencyMode.Single, IncludeExceptionDetailInFaults = true)]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class RestServices : IRestServices
    {
        private static RestServices restServices;
        private static readonly Uri BASE_LT_URL = new Uri(XmlUtil.getXmlUrlValue("LTUrl") + "/webservices/MobileAppService/MobileAppService");
        public event RestListen RestEvent;

        public static RestServices Instance
        {
            get
            {
                if (restServices == null)
                    restServices = new RestServices();
                return restServices;
            }
            set
            {

            }
        }

        private static WebRequest webRequest_Intance
        {
            get
            {
                WebRequest webRequest = WebRequest.Create(BASE_LT_URL);
                webRequest.ContentType = "text/xml; charset=utf-8";
                webRequest.Method = "POST";
                return webRequest;
            }
            set {}
        }

        public void Init()
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
                _serviceHost.Open();
            }
            catch (Exception e)
            {
                LogHelper.Error("Service stared failure", e);
            }
        }


        public void LTInventoryInfo(string Id)
        {
            LogHelper.Info("LTInventoryInfo");            
            RestEvent(Id, "in", "/lt/in/inventoryInfo/{id}", "丽亭", DateTime.Now, "success");
        }

        public void LTMobileParking(string Id)
        {
            LogHelper.Info("LTMobileParking");
            RestEvent(Id, "in", "/lt/in/mobileParking/{id}", "丽亭", DateTime.Now, "success");
        }

        public void LTVehicleInfo(string Id)
        {
            LogHelper.Info("LTVehicleInfo");
            RestEvent(Id, "in", "/lt/in/vehicleInfo/{id}", "丽亭", DateTime.Now, "success");
        }

        public void LTVehicleOutbound(string Id)
        {
            LogHelper.Info("LTVehicleOutbound");
            RestEvent(Id, "in", "/lt/in/vehicleOutbound/{id}", "丽亭", DateTime.Now, "success");
        }

        public void LTBasicMapInformation(string Id)
        {
            LogHelper.Info("LTBasicMapInformation");
            RestEvent(Id, "in", "/lt/in/basicMapInformation/{id}", "丽亭", DateTime.Now, "success");
        }

        // =======================================================================================================
        public string ZDInGetInventoryInfo()
        {
            WebRequest webRequest = webRequest_Intance;
            LogHelper.Info("ZDInGetInventoryInfo");            
            webRequest.Headers.Add("SOAPAction", "Serva.OperationControl.serva.com/IMobileAppService/GetInventoryInformation");
            Result result = RequestServices.Instance.RequestLTAPI("<ser:GetInventoryInformation/>", webRequest);       
            RestEvent("无", "in", "/zd/in/getInventoryInfo/{id}", "中都物流", DateTime.Now, result.status);
            LogHelper.Info("Get Inventory Info :" + result.content);
            return result.content;
        }

        public string ZDInMobileParking(string ticketID, string stallWayPointId)
        {
            WebRequest webRequest = webRequest_Intance;
            LogHelper.Info("ZDInMobileParking: ticketID = " + ticketID + " , stallWayPointId = " + stallWayPointId);
            webRequest.Headers.Add("SOAPAction", "Serva.OperationControl.serva.com/IMobileAppService/CreateRelocationJob");
            Result result = RequestServices.Instance.RequestLTAPI("<ser:CreateRelocationJob><ser:ticketID>" + ticketID + "</ser:ticketID><ser:stallWayPointId>" + stallWayPointId + "</ser:stallWayPointId></ser:CreateRelocationJob>", webRequest);
            RestEvent(ticketID + ":" + stallWayPointId, "in", "/zd/in/mobileParking/", "中都物流", DateTime.Now, result.status);
            return result.content;
        }

        public string ZDInGetVehicleInfo(string ticketId)
        {
            WebRequest webRequest = webRequest_Intance;
            LogHelper.Info("ZDInGetVehicleInfo");            
            webRequest.Headers.Add("SOAPAction", "Serva.OperationControl.serva.com/IMobileAppService/GetCarInformation");
            Result result = RequestServices.Instance.RequestLTAPI("<ser:GetCarInformation><ser:ticketId>" + ticketId + "</ser:ticketId></ser:GetCarInformation>", webRequest);
            RestEvent(ticketId, "in", "/ZD/in/getVehicleInfo/{id}", "中都物流", DateTime.Now, result.status);
            LogHelper.Info("Get Vehicle Info :" + result.content);
            return result.content;
        }

        public string ZDInVehicleOutbound(string ticketID, string VTS_ID)
        {
            WebRequest webRequest = webRequest_Intance;
            LogHelper.Info("ZDInVehicleOutbound: ticketID = " + ticketID + " , VTS_ID = " + VTS_ID);
            webRequest.Headers.Add("SOAPAction", "Serva.OperationControl.serva.com/IMobileAppService/CreateOutboundJob");
            Result result = RequestServices.Instance.RequestLTAPI("<ser:CreateOutboundJob><ser:ticketID>" + ticketID + "</ser:ticketID><ser:VTS_ID>" + VTS_ID + "</ser:VTS_ID></ser:CreateOutboundJob>", webRequest);
            RestEvent(ticketID + ":" + VTS_ID, "in", "/zd/in/vehicleOutbound/", "中都物流", DateTime.Now, result.status);
            return result.content;
        }

        public string ZDInGetBasicMapInfo()
        {
            WebRequest webRequest = webRequest_Intance;
            LogHelper.Info("ZDInGetBasicMapInfo");
            webRequest.Headers.Add("SOAPAction", "Serva.OperationControl.serva.com/IMobileAppService/GetMapInformation");
            Result result = RequestServices.Instance.RequestLTAPI("<ser:GetMapInformation/>", webRequest);
            RestEvent("无", "in", "/zd/in/getBasicMapInfo/", "中都物流", DateTime.Now, result.status);
            LogHelper.Info("Get Map Info :" + result.content);
            return result.content;
        }

        public string ZDInGetAGVInfo(string AGV_ID)
        {
            WebRequest webRequest = webRequest_Intance;
            LogHelper.Info("ZDInGetAGVInfo");           
            webRequest.Headers.Add("SOAPAction", "Serva.OperationControl.serva.com/IMobileAppService/GetAGVStatusInformation");
            Result result = RequestServices.Instance.RequestLTAPI("<ser:GetAGVStatusInformation><ser:agvId>" + AGV_ID + "</ser:agvId></ser:GetAGVStatusInformation>", webRequest);
            RestEvent(AGV_ID, "in", "/zd/in/getAGVInfo/", "中都物流", DateTime.Now, result.status);
            LogHelper.Info("Get Map Info :" + result.content);
            return result.content;

        }

        public string ZDInGetVTSInfo(string VTS_ID)
        {
            WebRequest webRequest = webRequest_Intance;
            LogHelper.Info("ZDInGetVTSInfo");
            
            webRequest.Headers.Add("SOAPAction", "Serva.OperationControl.serva.com/IMobileAppService/GetVTSStatus");
            Result result = RequestServices.Instance.RequestLTAPI("<ser:GetVTSStatus><ser:VTS_ID>" + VTS_ID + "</ser:VTS_ID></ser:GetVTSStatus>", webRequest);
            RestEvent(VTS_ID, "in", "/zd/in/getVTSInfo/", "中都物流", DateTime.Now, result.status);
            LogHelper.Info("Get VTS info :" + result.content);
            return result.content;
        }

        public string ZDInGetJobInfo(string processId)
        {
            WebRequest webRequest = webRequest_Intance;
            LogHelper.Info("ZDInGetJobInfo");            
            webRequest.Headers.Add("SOAPAction", "Serva.OperationControl.serva.com/IMobileAppService/GetJobStatus");
            Result result = RequestServices.Instance.RequestLTAPI("<ser:GetJobStatus><ser:processId>" + processId + "</ser:processId></ser:GetJobStatus>", webRequest);
            RestEvent(processId, "in", "/zd/in/getJobInfo/", "中都物流", DateTime.Now, result.status);
            LogHelper.Info("Get Job Info :" + result.content);
            return result.content;
        }

        public string ZDInGetChargingStationStatus(string csId)
        {
            WebRequest webRequest = webRequest_Intance;
            LogHelper.Info("ZDInGetChargingStationStatus");            
            webRequest.Headers.Add("SOAPAction", "Serva.OperationControl.serva.com/IMobileAppService/GetChargingStationStatus");
            Result result = RequestServices.Instance.RequestLTAPI("<ser:GetChargingStationStatus><ser:csId>" + csId + "</ser:csId></ser:GetChargingStationStatus>", webRequest);
            RestEvent(csId, "in", "/zd/in/getChargingStationStatus/", "中都物流", DateTime.Now, result.status);
            LogHelper.Info("Get Charging Station Status :" + result.content);
            return result.content;
        }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel.Web;
using System.ServiceModel;
using RestService.HttpAPI;

namespace RestService.RestAPI
{
    [ServiceContract(Name = "RestServices")]
    public interface IRestServices
    {
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = Routing.ZDInVehicleOutbound, BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        string ZDInVehicleOutbound(string ticketID, string VTS_ID);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = Routing.ZDInMobileParking, BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        string ZDInMobileParking(string ticketID, string stallWayPointId);
        
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = Routing.ZDInGetVehicleInfo, BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        string ZDInGetVehicleInfo(string ticketId);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = Routing.ZDInGetInventoryInfo, BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        string ZDInGetInventoryInfo();

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = Routing.ZDInGetBasicMapInfo, BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        string ZDInGetBasicMapInfo();

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = Routing.ZDInGetAGVInfo, BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        string ZDInGetAGVInfo(string AGV_ID);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = Routing.ZDInGetVTSInfo, BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        string ZDInGetVTSInfo(string VTS_ID);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = Routing.ZDInGetJobInfo, BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        string ZDInGetJobInfo(string processId);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = Routing.ZDInGetChargingStationStatus, BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        string ZDInGetChargingStationStatus(string csId);

        // ====================================================================================================

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = Routing.LTInVehicleOutbound, BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        void LTVehicleOutbound(string Id);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = Routing.LTInMobileParking, BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        void LTMobileParking(string Id);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = Routing.LTInVehicleInfo, BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        void LTVehicleInfo(string Id);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = Routing.LTInInventoryInfo, BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        void LTInventoryInfo(string Id);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = Routing.LTInBasicMapInformation, BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        void LTBasicMapInformation(string Id);

    }  
}

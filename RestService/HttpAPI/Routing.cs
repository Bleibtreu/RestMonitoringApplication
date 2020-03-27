using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestService.HttpAPI
{
    public static class Routing
    {
        // ZD interface in direction
        public const string ZDInGetVehicleInfo = "/zd/in/getVehicleInfo/{ticketId}";

        public const string ZDInGetVTSInfo = "/zd/in/getVTSInfo/{VTS_ID}";

        public const string ZDInGetInventoryInfo = "/zd/in/getInventoryInfo/";

        public const string ZDInGetBasicMapInfo = "/zd/in/getBasicMapInformation/";

        public const string ZDInGetAGVInfo = "/zd/in/getAGVInfo/{AGV_ID}";

        public const string ZDInGetJobInfo = "/zd/in/getJobInfo/{processId}";

        public const string ZDInGetChargingStationStatus = "/zd/in/getChargingStationStatus/{csId}";

        public const string ZDInVehicleOutbound = "/zd/in/vehicleOutbound/";

        public const string ZDInMobileParking = "/zd/in/mobileParking/";


        // ZD interface out direction
        /*
        public const string ZDOutVehicleOutbound = "/zd/out/vehicleOutbound/{id}";

        public const string ZDOutMobileParking = "/zd/out/mobileParking/{id}";

        public const string ZDOutVehicleInfo = "/zd/out/vehicleInfo/{id}";

        public const string ZDOutInventoryInfo = "/zd/out/inventoryInfo/{id}";

        public const string ZDOutBasicMapInformation = "/zd/out/basicMapInformation/{id}";
        */

        // LT interface in direction
        public const string LTInVehicleOutbound = "/lt/in/vehicleOutbound/{id}";

        public const string LTInMobileParking = "/lt/in/mobileParking/{id}";

        public const string LTInVehicleInfo = "/lt/in/vehicleInfo/{id}";

        public const string LTInInventoryInfo = "/lt/in/inventoryInfo/{id}";

        public const string LTInBasicMapInformation = "/lt/in/basicMapInformation/{id}";

        // LT interface out direction
        /*
        public const string LTOutVehicleOutbound = "/lt/out/vehicleOutbound/{id}";

        public const string LTOutMobileParking = "/lt/out/mobileParking/{id}";

        public const string LTOutVehicleInfo = "/lt/out/vehicleInfo/{id}";

        public const string LTOutInventoryInfo = "/lt/out/inventoryInfo/{id}";

        public const string LTOutBasicMapInformation = "/lt/out/basicMapInformation/{id}";
        */
    }
}

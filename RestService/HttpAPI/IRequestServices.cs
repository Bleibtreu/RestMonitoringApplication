using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static RestService.RequestAPI.RequestServices;

namespace RestService.RequestAPI
{
    public interface IRequestServices
    {
        Result RequestLTAPI(string content, WebRequest webRequest);

        string RequestZDAPI(string urlSuffix);
    }
}

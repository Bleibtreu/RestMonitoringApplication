using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestService.DataServices
{
    public class Record
    {
        public string id { get; set; }
        public string direction { get; set; }
        public string url { get; set; }
        public string attribution { get; set; }
        public DateTime occurrence_time { get; set; }
        public string status { get; set; }
    }
}

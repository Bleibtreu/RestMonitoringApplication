using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestService.DataServices
{
    public interface ISQLServerServices
    {
        bool Query();
        bool Save();
        bool Update();
        bool Delete();
        bool SavaRecord(Record record);
    }
}
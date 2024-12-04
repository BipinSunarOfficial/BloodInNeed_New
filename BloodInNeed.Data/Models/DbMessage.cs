using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodInNeed.Data.Models
{
    public class DbMessage
    {
        public string MsgType { get; set; }

        public string Msg { get; set; }

        public List<string> ErrorList { get; set; }
    }

    public class DbMessageFlag
    {
        public string MsgType { get; set; }

        public string Msg { get; set; }

        public bool IsUnknownError { get; set; }
    }

}

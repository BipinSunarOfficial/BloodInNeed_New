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
        public int UserId { get; set; }

        public List<string> ErrorList { get; set; }

    }

    public class DbMessageUserName
    {
        public string MsgType { get; set; }
        public string Msg { get; set; }
        public string Username { get; set; }
        public int UserId { get; set; }

        public List<string> ErrorList { get; set; }



    }

    public class DbMessageWithValue
    {
        public string MsgType { get; set; }
        public string Msg { get; set; }
        public string Value { get; set; }
        
    }

    public class DbMessageFlag
    {
        public string MsgType { get; set; }

        public string Msg { get; set; }

        public bool IsUnknownError { get; set; }
    }

    public class GoogleUserId
    {
        public int UserId { get; set; }

    }

}

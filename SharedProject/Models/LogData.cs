using System;

namespace XpenceShared.Models
{
    public class LogData:BaseModelPersonal
    {
        public string TextMessage { get; set; }

        public string Command { get; set; }
    

        public DateTime RecordDate { get; set; }


    }
}
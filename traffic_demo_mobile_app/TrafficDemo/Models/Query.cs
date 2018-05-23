using System;
namespace TrafficDemo.Models
{
    /*
    {
        "stop_id": "200054",
        "cur_time": "09:10:00",
        "day": "5"
    }
    */
    public class Query
    {
        public string stop_id { get; set; }
        public string cur_time { get; set; }
        public string day { get; set; }
    }
}

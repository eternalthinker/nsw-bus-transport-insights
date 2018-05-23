using System;

namespace TrafficDemo.ViewModels
{
    public class QueryViewModel: BaseViewModel
    {
        public DateTime dateTime { get; set; }
        public string stop_id { get; set; }
        public QueryViewModel()
        {
            this.dateTime = DateTime.Now;
            this.stop_id = "200054";
        }
    }
}

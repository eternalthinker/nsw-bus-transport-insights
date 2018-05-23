using System;
namespace TrafficDemo.Models
{
    /*  
    {
        "trip_id": 583222,
        "arrival_time": "09:11:00",
        "departure_time": "09:11:00",
        "stop_id": 200054,
        "stop_sequence": 1,
        "stop_headsign": "NaN",
        "pickup_type": 0,
        "drop_off_type": 0,
        "shape_dist_traveled": 0,
        "timepoint": 1,
        "stop_note": "NaN",
        "route_id": "2441_891",
        "service_id": 213,
        "shape_id": 46504,
        "trip_headsign": "High St Nr ANZAC Pde UNSW Gate 3",
        "direction_id": 0,
        "block_id": "NaN",
        "wheelchair_accessible": 1,
        "trip_note": "NaN",
        "route_direction": "PrePay Only - UNSW High St to Central Eddy Ave",
        "congestion_level": "1",
        "occupancy_status": "1"
    }
    */
    public class Trip
    {
        public long trip_id { get; set; }
        public string arrival_time { get; set; }
        public string departure_time { get; set; }
        public long stop_id { get; set; }
        public int stop_sequence { get; set; }
        public string stop_headsign { get; set; }
        public int pickup_type { get; set; }
        public int drop_off_type { get; set; }
        public int shape_dist_traveled { get; set; }
        public int timepoint { get; set; }
        public string stop_note { get; set; }
        public string route_id { get; set; }
        public int service_id { get; set; }
        public int shape_id { get; set; }
        public string trip_headsign { get; set; }
        public int direction_id { get; set; }
        public string block_id { get; set; }
        public int wheelchair_accessible { get; set; }
        public string trip_note { get; set; }
        public string route_direction { get; set; }
        public string congestion_level { get; set; }
        public string occupancy_status { get; set; }
    }
}

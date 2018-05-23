using System;
namespace TrafficDemo.Models
{
    public enum OccupancyLevel
    {
        Empty = 0,
        Many_Seats_Available = 1,
        Few_Seats_Available = 2,
        Standing_Room_Only = 3,
        Crushed_Standing_Room_Only = 4,
        Full = 5,
        Not_Accepting_Passengers = 6
    }
}

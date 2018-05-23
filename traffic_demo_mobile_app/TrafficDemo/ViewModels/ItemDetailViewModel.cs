using System;

using TrafficDemo.Models;

namespace TrafficDemo.ViewModels
{
    public class ItemDetailViewModel : BaseViewModel
    {
        public Trip Trip { get; set; }
        public ItemDetailViewModel(Trip trip = null)
        {
            Trip = trip;
        }
    }
}

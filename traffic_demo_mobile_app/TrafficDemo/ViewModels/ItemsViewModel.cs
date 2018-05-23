using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using TrafficDemo.Models;
using TrafficDemo.Views;

namespace TrafficDemo.ViewModels
{
    public class ItemsViewModel : BaseViewModel
    {
        public ObservableCollection<Trip> Trips { get; set; }
        public Command LoadItemsCommand { get; set; }
        public ItemsViewModel()
        {
            Title = "Trip Demo";
            Trips = new ObservableCollection<Trip>();
            LoadItemsCommand = new Command<Query>(async q => await ExecuteLoadItemsCommand(q));

            MessagingCenter.Subscribe<NewItemPage, Query>(this, "AddItem", async (obj, query) =>
            {
                query = query ?? new Query
                {
                    stop_id = "200054",
                    cur_time = "09:10:00",
                    day = "5"
                };
                var trips = await DataStore.PostTripsAsync(query);
                foreach (var trip in trips)
                {
                    trip.route_id = (trip.route_id.Split('_'))[1];
                    Trips.Add(trip);
                }
            });
        }

        async Task ExecuteLoadItemsCommand(Query q)
        {
            if (IsBusy)
                return;
            IsBusy = true;
            var query = q ?? new Query{
                stop_id = "200054",
                cur_time = "09:10:00",
                day = "5"
            };
            try
            {
                Trips.Clear();
                var trips = await DataStore.PostTripsAsync(query);
                foreach (var trip in trips)
                {
                    trip.route_id = (trip.route_id.Split('_'))[1];
                    int congestion;
                    if(!Int32.TryParse(trip.congestion_level, out congestion)){
                        congestion = 0;
                    }
                    trip.congestion_level = ((CongestionLevel)congestion).ToString().Replace('_', ' ');
                    int occupancy;
                    if (!Int32.TryParse(trip.occupancy_status, out occupancy))
                    {
                        occupancy = 0;
                    }
                    trip.occupancy_status = ((OccupancyLevel)occupancy).ToString().Replace('_', ' ');
                    Trips.Add(trip);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
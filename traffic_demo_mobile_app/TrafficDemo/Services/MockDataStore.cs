using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using TrafficDemo.Models;

namespace TrafficDemo.Services
{
    public class MockDataStore : IDataStore<Trip, Query>
    {
        List<Trip> trips;

        public MockDataStore()
        {
            trips = new List<Trip>();
            var mockItems = new List<Trip>
            {
                new Trip { Id = Guid.NewGuid().ToString(), Text = "First item", Description="This is an item description." },
                new Trip { Id = Guid.NewGuid().ToString(), Text = "Second item", Description="This is an item description." },
                new Trip { Id = Guid.NewGuid().ToString(), Text = "Third item", Description="This is an item description." },
                new Trip { Id = Guid.NewGuid().ToString(), Text = "Fourth item", Description="This is an item description." },
                new Trip { Id = Guid.NewGuid().ToString(), Text = "Fifth item", Description="This is an item description." },
                new Trip { Id = Guid.NewGuid().ToString(), Text = "Sixth item", Description="This is an item description." },
            };

            foreach (var item in mockItems)
            {
                trips.Add(item);
            }
        }


    }
}
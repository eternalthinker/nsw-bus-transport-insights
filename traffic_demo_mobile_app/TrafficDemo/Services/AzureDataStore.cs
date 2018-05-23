using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Plugin.Connectivity;
using TrafficDemo.Models;

namespace TrafficDemo.Services
{
    public class AzureDataStore: IDataStore<Trip, Query>
    {
        HttpClient client;
        Query query;
        IEnumerable<Trip> trips;

        public AzureDataStore()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri($"{App.AzureBackendUrl}");
            trips = new List<Trip>();
        }

        public async Task<IEnumerable<Trip>> PostTripsAsync(Query query)
        {
            if(CrossConnectivity.Current.IsConnected)
            {
                var serializedItem = JsonConvert.SerializeObject(query);
                var buffer = Encoding.UTF8.GetBytes(serializedItem);
                var byteContent = new ByteArrayContent(buffer);

                var response = await client.PostAsync(client.BaseAddress, byteContent);
                if(response.Content != null)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    trips = await Task.Run(() => JsonConvert.DeserializeObject<IEnumerable<Trip>>(responseContent));
                }

            }
            return trips;
        }
    }
}
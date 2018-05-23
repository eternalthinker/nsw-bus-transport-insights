using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TrafficDemo.Services
{
    public interface IDataStore<T1, T2>
    {
        /* Task<bool> AddItemAsync(T item);
         Task<bool> UpdateItemAsync(T item);
         Task<bool> DeleteItemAsync(string id);
         Task<T> GetItemAsync(string id);
         Task<IEnumerable<T>> GetItemsAsync(bool forceRefresh = false);
         */
        Task<IEnumerable<T1>> PostTripsAsync(T2 query);
    }
}

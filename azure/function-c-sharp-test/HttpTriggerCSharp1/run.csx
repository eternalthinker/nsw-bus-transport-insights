#r "Newtonsoft.Json"

using System;
using System.Web;
using System.Net;
using Newtonsoft.Json;
using System.Text;

public static async Task<HttpResponseMessage> Run(HttpRequestMessage req, TraceWriter log)
{
    log.Info("C# HTTP trigger function processed a request.");

    //parse query parameter
    string fromStation = req.GetQueryNameValuePairs()
        .FirstOrDefault(q => string.Compare(q.Key, "fromSta", true) == 0)
        .Value;
    
    string toStation = req.GetQueryNameValuePairs()
        .FirstOrDefault(q => string.Compare(q.Key, "toSta", true) == 0)
        .Value;

    if (fromStation == null)
    {
        // Get request body
        dynamic data = await req.Content.ReadAsAsync<object>();
        fromStation = data?.fromSta;
        toStation = data?.toSta;
    }

    var model = new {
        route = "357",
        time = "12:12 pm",
        occupation = "30%"
    };

    var jsonToReturn = JsonConvert.SerializeObject(model);

    return new HttpResponseMessage(HttpStatusCode.OK) {
        Content = new StringContent(jsonToReturn, Encoding.UTF8, "application/json")
    };

}

public class Route
{
    public string route { get;set; }    
}
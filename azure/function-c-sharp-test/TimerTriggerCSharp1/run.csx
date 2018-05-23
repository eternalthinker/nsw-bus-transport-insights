#load "model.csx"
#r "Newtonsoft.Json"

using System;
using System.Web;
using System.Net;
using Newtonsoft.Json;
using System.Web.Mvc;

public static void Run(TimerInfo myTimer, TraceWriter log)
{
    log.Info($"C# Timer trigger function executed at: {DateTime.Now}");
    QueryOpenDataApiTest(log);
}

private static void QueryOpenDataApiTest(TraceWriter log)
{
    var url = "https://api.transport.nsw.gov.au/v1/tp/trip?outputFormat=rapidJSON&coordOutputFormat=EPSG%3A4326&depArrMacro=dep&itdDate=20180511&itdTime=1200&type_origin=any&name_origin=10101331&type_destination=any&name_destination=10102027&calcNumberOfTrips=6&TfNSWTR=true&version=10.2.1.42";
    var apiKey = "apikey y5miIMZKaieZrkcdUy0H4OynGinT3KuD3Weh";
    try
    {
        using (var wc = new WebClient())
        {
            wc.Headers.Add("Authorization", apiKey);
            //var str = wc.DownloadString(url);
            using (MemoryStream stream = new MemoryStream(wc.DownloadData(url)))
            {
                using (var sreader = new StreamReader(stream))
                {
                    var serialiser = new JsonSerializer();
                    TripInfo trip = serialiser.Deserialize<TripInfo>(new JsonTextReader(sreader));
                    log.Info(trip.version);
                }
            }
            //log.Info(str);
        }
    }
    catch (Exception)
    {
        log.Info("Failed");
    }
}

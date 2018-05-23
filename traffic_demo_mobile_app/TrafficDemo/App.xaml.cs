using System;
using Xamarin.Forms;
using TrafficDemo.Services;
using TrafficDemo.Views;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace TrafficDemo
{
    public partial class App : Application
    {
        //TODO: Replace with *.azurewebsites.net url after deploying backend to Azure
        public static string AzureBackendUrl = "https://bus-insights-app.azurewebsites.net/api/BusInsightsApp?code=opeNQqB04TlfA3jFToIaFCzyALzd6wKqMh0PGXermTiuhoTJEYTUJw==";
        //public static string Query = "";
        //public static bool UseMockDataStore = false;

        public App()
        {
            InitializeComponent();


            DependencyService.Register<AzureDataStore>();

            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}

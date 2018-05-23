using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using TrafficDemo.Models;
using TrafficDemo.ViewModels;


namespace TrafficDemo.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class QueryPage : ContentPage
    {
        QueryViewModel viewModel;
        ContentPage page;

        public string stopStr;
        /*
        public QueryPage(QueryViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = this.viewModel = viewModel;
        }
        */

        public QueryPage(ContentPage page)
        {
            InitializeComponent();
            var dt = DateTime.Now;
            this.page = page;
            this.viewModel = new QueryViewModel();
            BindingContext = this.viewModel;
            stopStr = "Central";
        }

        async void Search_Clicked(object sender, EventArgs e)
        {
            var day = (((int)(this.date.Date.DayOfWeek)+6) % 7).ToString();
            var t = this.time.Time.ToString();

            var stop_num = (int)Enum.Parse(typeof(StopId), this.stop_id.Text);

            var stop = stop_num.ToString();

            ((ItemsPage)page).query.stop_id = stop;
            ((ItemsPage)page).query.day = day;
            ((ItemsPage)page).query.cur_time = t;
            ((ItemsPage)page).Search = true;
            await Navigation.PopModalAsync();
        }

        async void StopEntry_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new StopListPage(this)));
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            this.stop_id.Text = stopStr;
            this.stop_id.Unfocus();
        }
    }
}



using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace TrafficDemo.Views
{
    public partial class StopListPage : ContentPage
    {
        ContentPage page;
        public StopListPage(ContentPage page)
        {
            InitializeComponent();
            stops.ItemsSource = new List<string>() { "Central", "UNSW" };
            this.page = page;
        }

        async void Stop_Selected(object sender, EventArgs e)
        {
            ((QueryPage)page).stopStr = ((ListView)sender).SelectedItem.ToString();
            await Navigation.PopModalAsync();
        }
    }
}

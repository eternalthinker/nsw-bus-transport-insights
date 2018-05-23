using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using TrafficDemo.Models;
using TrafficDemo.ViewModels;

namespace TrafficDemo.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ItemDetailPage : ContentPage
    {
        ItemDetailViewModel viewModel;

        public ItemDetailPage(ItemDetailViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }

        public ItemDetailPage()
        {
            InitializeComponent();

            var trip = new Trip
            {

            };

            viewModel = new ItemDetailViewModel(trip);
            BindingContext = viewModel;
        }
    }
}
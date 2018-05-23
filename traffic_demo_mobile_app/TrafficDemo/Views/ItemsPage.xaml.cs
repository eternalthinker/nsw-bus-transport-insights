using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using TrafficDemo.Models;
using TrafficDemo.Views;
using TrafficDemo.ViewModels;

namespace TrafficDemo.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ItemsPage : ContentPage
    {
        ItemsViewModel viewModel;

        public Query query { get; set; }
        bool appeared = false;
        public bool Search;
        public ItemsPage()
        {
            InitializeComponent();
            query = new Query();
            BindingContext = viewModel = new ItemsViewModel();
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var trip = args.SelectedItem as Trip;
            if (trip == null)
                return;
            
            await Navigation.PushAsync(new ItemDetailPage(new ItemDetailViewModel(trip)));

            // Manually deselect item.
            ItemsListView.SelectedItem = null;
        }

        async void AddItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new QueryPage(this)));
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            if(!Search){
                return;
            }
            Search = false;
            if (query.stop_id != null)
            {
                viewModel.LoadItemsCommand.Execute(query);
            }

        }


    }
}
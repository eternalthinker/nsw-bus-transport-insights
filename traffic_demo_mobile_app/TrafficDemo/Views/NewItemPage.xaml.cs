using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using TrafficDemo.Models;

namespace TrafficDemo.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewItemPage : ContentPage
    {
        public Trip Trip { get; set; }

        public NewItemPage()
        {
            InitializeComponent();

            Trip = new Trip
            {

            };

            BindingContext = this;
        }

        async void Save_Clicked(object sender, EventArgs e)
        {
            /*MessagingCenter.Send(this, "AddItem", Item);
            await Navigation.PopModalAsync();*/
        }
    }
}
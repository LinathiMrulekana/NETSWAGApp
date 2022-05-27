using NETSWAGApp.data;
using NETSWAGApp.models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace NETSWAGApp
{
    public partial class MainPage : ContentPage
    { 

        public MainPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            OrderingItemDatabase database = await OrderingItemDatabase.Instance;
            listView.ItemsSource = await database.GetItemsAsync();
        }

        async void OnItemAdded(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage
            {
                BindingContext = new OrderingItem()
            });
        }

        async void OnListItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new MainPage
                {
                    BindingContext = e.SelectedItem as OrderingItem
                });
            }
        }
    }
}
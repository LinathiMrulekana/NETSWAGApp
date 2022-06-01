using NETSWAGApp.data;
using NETSWAGApp.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NETSWAGApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InfoPage : ContentPage
    {
        public List<OrderingItem> OrderingItems { get; set; }

        public InfoPage()
        {
            InitializeComponent();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();

            OrderingItemDatabase database = await OrderingItemDatabase.Instance;

            OrderingItems = await database.GetItemsAsync();

            BindingContext = this;

         //   Listview.ItemsSource = await database.GetItemsAsync();
        }

       private async void OnListItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new InfoPage
                {
                    BindingContext = e.SelectedItem as OrderingItem
                });
            }
        }
    }
}
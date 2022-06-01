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
        public bool SmallSize { get; set; }
        public bool MediumSize { get; set; }
        public bool LargeSize { get; set; }
        public bool XLargeSize { get; set; }

        public OrderingItem CurrentOrderItem { get; set; }


        public MainPage()
        {
            InitializeComponent();

            CurrentOrderItem = new OrderingItem();
            BindingContext = this;
        }

        async void Save_ClickedAsync(object sender, EventArgs e)
        {
            var thisPage = (MainPage)BindingContext;
            var orderingItem = thisPage.CurrentOrderItem;


            if (thisPage.SmallSize)
                orderingItem.TShirtSize = "S";
            else
            if (thisPage.MediumSize)
                orderingItem.TShirtSize = "M";
            else
            if (thisPage.LargeSize)
                orderingItem.TShirtSize = "L";
            else
            if (thisPage.XLargeSize)
                orderingItem.TShirtSize = "XL";


            OrderingItemDatabase database = await OrderingItemDatabase.Instance;
            await database.SaveItemAsync(orderingItem);
            await Navigation.PushAsync(new InfoPage());

        }

       

        private void startDatePicker_DateSelected(object sender, DateChangedEventArgs e)
        {

        }

        async void Delete_Clicked(object sender, EventArgs e)
        {
            var thisPage = (MainPage)BindingContext;
            var orderingItem = thisPage.CurrentOrderItem;
            OrderingItemDatabase database = await OrderingItemDatabase.Instance;
            await database.DeleteItemAsync(orderingItem);
            await Navigation.PushAsync(new InfoPage());
        }
    }
}

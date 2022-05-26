using NETSWAGApp.data;
using NETSWAGApp.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NETSWAGApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OrderingItemPage : ContentPage
    {
        private object orderingItem;

        public OrderingItemPage()
        {
            InitializeComponent();
        }

        private void startDatePicker_DateSelected(object sender, DateChangedEventArgs e)
        {

        }

         async void Save_ClickedAsync(object sender, EventArgs e)
        {
            var todoItem = (OrderingItem)BindingContext;
            OrderingItemDatabase database = await OrderingItemDatabase.Instance;
            await database.SaveItemAsync(orderingItem);
            await Navigation.PopAsync();
        }

         async void Cancel_ClickedAsync(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}
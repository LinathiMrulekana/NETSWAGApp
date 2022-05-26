﻿using NETSWAGApp.data;
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
        private object orderingItem;

        public MainPage()
        {
            InitializeComponent();
        }

        async void Save_ClickedAsync(object sender, EventArgs e)
        {
            var OrderingItem = (OrderingItem)BindingContext;
            OrderingItemDatabase database = await OrderingItemDatabase.Instance;
            await database.SaveItemAsync(orderingItem);
            await Navigation.PopAsync();

        }

         async void Cancel_ClickedAsync(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        private void startDatePicker_DateSelected(object sender, DateChangedEventArgs e)
        {

        }
    }
}

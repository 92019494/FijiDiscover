using System;
using System.Collections.Generic;
using FijiDiscover.Services;
using Xamarin.Forms;

namespace FijiDiscover.Views
{
    public partial class ActivityPage : ContentPage
    {
        ActivityDataAccess dataAccess;


        public ActivityPage()
        {
            InitializeComponent();
            dataAccess = new ActivityDataAccess();
            this.BindingContext = dataAccess;
            
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            dataAccess = new ActivityDataAccess();
            this.BindingContext = dataAccess;
        }


    }
}

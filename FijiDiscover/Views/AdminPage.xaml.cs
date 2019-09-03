using System;
using System.Collections.Generic;
using FijiDiscover.Services;
using Xamarin.Forms;

namespace FijiDiscover.Views
{
    public partial class AdminPage : ContentPage
    {

        ActivityDataAccess dataAccess;

        public AdminPage()
        {
            InitializeComponent();
            dataAccess = new ActivityDataAccess();
            this.BindingContext = dataAccess;
        }

        private async void AddActivityButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddActivityPage());
        }

        private async void EditActivitiesButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new EditActivitiesPage());
        }

        private async void DeleteActivitiesButtonClicked(object sender, EventArgs e)
        {
            var result = await DisplayAlert("Confirmation", "Are you sure you want to delete all activities?", "OK", "Cancel");
            if (result == true)
            {
                dataAccess.DeleteAllActivities();
                

            }
         
        }
    }

}

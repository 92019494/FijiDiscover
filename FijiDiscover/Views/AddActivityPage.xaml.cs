using System;
using System.Collections.Generic;
using FijiDiscover.Services;
using Xamarin.Forms;
using System.Diagnostics;

namespace FijiDiscover.Views
{
    public partial class AddActivityPage : ContentPage
    {
        ActivityDataAccess dataAccess;

        public AddActivityPage()
        {
            InitializeComponent();
            dataAccess = new ActivityDataAccess();
            this.BindingContext = dataAccess;
        }

        private async void AddActivityButtonClicked(object sender, EventArgs e)
        {
            if (sourceURL.Text != null && name.Text != null && location.Text != null && description.Text != null
                && sourceURL.Text != "" && name.Text != "" && location.Text != "" && description.Text != "")
            {
                dataAccess.AddNewActivity(sourceURL.Text, name.Text, location.Text, description.Text);
                dataAccess.SaveAllActivities();
                helpText.TextColor = Color.Transparent;
                await Navigation.PopAsync();
                
            } else
            {
                helpText.TextColor = Color.Red;
            }
        }

    }
}

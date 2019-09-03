using System;
using System.Collections.Generic;
using FijiDiscover.Models;
using FijiDiscover.Services;
using Xamarin.Forms;

namespace FijiDiscover.Views
{
    public partial class ActivityDetailPage : ContentPage
    {
        ActivityDataAccess dataAccess;
        public int activityDetailPageActivityID;

        public ActivityDetailPage()
        {
            InitializeComponent();
            dataAccess = new ActivityDataAccess();

        }

        private async void UpdateActivityButtonClicked(object sender, EventArgs e)
        {
            if (sourceURL.Text != null && name.Text != null && location.Text != null && description.Text != null
                && sourceURL.Text != "" && name.Text != "" && location.Text != "" && description.Text != "")
            {

                Activity updatedActivity = new Activity
                {
                    Activity_id = activityDetailPageActivityID,
                    SourceURL = sourceURL.Text,
                    Name = name.Text,
                    Location = location.Text,
                    Description = description.Text
                };

                dataAccess.SaveActivity(updatedActivity);
                helpText.TextColor = Color.Transparent;
                await Navigation.PopAsync();
            }
            else
            {
                helpText.TextColor = Color.Red;
            }
        }

        private async void DeleteActivityButtonClicked(object sender, EventArgs e)
        {
            Activity updatedActivity = new Activity
            {
                Activity_id = activityDetailPageActivityID,
                SourceURL = sourceURL.Text,
                Name = name.Text,
                Location = location.Text,
                Description = description.Text
            };
            var result = await DisplayAlert("Confirmation", "Are you sure you want to delete this activity?", "OK", "Cancel");
            if (result == true)
            {
                dataAccess.DeleteActivity(updatedActivity);
                await Navigation.PopAsync();

            }
        }

    }
}


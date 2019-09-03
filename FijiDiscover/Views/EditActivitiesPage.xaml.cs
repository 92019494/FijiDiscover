using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using FijiDiscover.Models;
using FijiDiscover.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FijiDiscover.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditActivitiesPage : ContentPage
    {
        ActivityDataAccess dataAccess;

        public EditActivitiesPage()
        {
            InitializeComponent();
            dataAccess = new ActivityDataAccess();
            this.BindingContext = dataAccess;
        }

        private async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;

            var currentActivity = this.MyListView.SelectedItem as Activity;

            var activityDetailPage = new ActivityDetailPage();
            activityDetailPage.BindingContext = currentActivity;
            activityDetailPage.activityDetailPageActivityID = currentActivity.Activity_id;
            
            //Deselect Item
            ((ListView)sender).SelectedItem = null;
            await Navigation.PushAsync(activityDetailPage);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            dataAccess = new ActivityDataAccess();
            this.BindingContext = dataAccess;
        }
    }
}

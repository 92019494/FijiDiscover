using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace FijiDiscover.Views
{
    public partial class AdminPage : ContentPage
    {
        public AdminPage()
        {
            InitializeComponent();
        }

        private async void SignInButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new EditActivityPage());
        }
    }

}

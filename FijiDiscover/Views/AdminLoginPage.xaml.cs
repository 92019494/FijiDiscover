using System;
using System.Collections.Generic;
using FijiDiscover.Services;
using Xamarin.Forms;

namespace FijiDiscover.Views
{
    public partial class AdminLoginPage : ContentPage
    {
        CredentialDataAccess dataAccess;

        public AdminLoginPage()
        {

            InitializeComponent();
            dataAccess = new CredentialDataAccess();
            
        }
        private async void SignInButtonClicked(object sender, EventArgs e)
        {
            if (dataAccess.LogInAdminUser(emailEntry.Text, passwordEntry.Text))
            {
                helpText.TextColor = Color.Transparent;
                await Navigation.PushAsync(new AdminPage());
            } else
            {
                helpText.TextColor = Color.Red;
            }
        }
    }
}

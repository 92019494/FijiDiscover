using System;
using System.Collections.Generic;
using FijiDiscover.Services;

using Xamarin.Forms;

namespace FijiDiscover.Views
{
    public partial class PhrasePage : ContentPage
    {
        PhraseDataAccess dataAccess;

        public PhrasePage()
        {
            InitializeComponent();
            dataAccess = new PhraseDataAccess();
            this.BindingContext = dataAccess;
        }
    }
}

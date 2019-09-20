using System;
using System.Collections.Generic;
using Android;
using Android.Content;
using Android.Media;
using FijiDiscover;
using FijiDiscover.Models;
using FijiDiscover.Services;

using Xamarin.Forms;

namespace FijiDiscover.Views
{
    public partial class PhrasePage : ContentPage
    {
        PhraseDataAccess dataAccess;
        MediaPlayer player;
        

        public PhrasePage()
        {
            InitializeComponent();
            dataAccess = new PhraseDataAccess();
            this.BindingContext = dataAccess;
          
        }

        private void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;

            var currentphrase = this.MyListView.SelectedItem as Phrase;

            DependencyService.Get<IAudio>().PlayAudioFile(currentphrase.VoiceClip);
            //test.Text = currentphrase.VoiceClip;

            //Deselect Item
            ((ListView)sender).SelectedItem = null;
        }

    }
}

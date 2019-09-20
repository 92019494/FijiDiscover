using System;
using Xamarin.Forms;
using Android.Media;
using FijiDiscover.Droid;
using Android.Content.Res;

[assembly: Dependency(typeof(AudioService))]
namespace FijiDiscover.Droid
{
    public class AudioService: IAudio
    {
        MediaPlayer player = new MediaPlayer();

        public AudioService()
        {
        }

        public void PlayAudioFile(string fileName)
        {
            player.Stop();

            player = new MediaPlayer();

            var fd = global::Android.App.Application.Context.Assets.OpenFd(fileName);
            player.Prepared += (s, e) =>
            {
                player.Start();
            };
            player.SetDataSource(fd.FileDescriptor, fd.StartOffset, fd.Length);
            player.Prepare();
        }
    }
}

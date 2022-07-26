using Xamarin.Forms;
using Plugin.SimpleAudioPlayer;
using System.IO;
using System.Reflection;
using SoundApp;
using System;
using System.ComponentModel;

namespace SoundApp
{
	[DesignTimeVisible(false)]
	public partial class MainPage : ContentPage
	{
		ISimpleAudioPlayer player = CrossSimpleAudioPlayer.CreateSimpleAudioPlayer();
		public MainPage()
		{
			InitializeComponent();
			Load("sound.mp3");
		}
		private void Load(string file)
		{
			var assembly = typeof(App).GetTypeInfo().Assembly;
			String ns = "Audio";
			Stream audioStream = assembly.GetManifestResourceStream(ns + "." + file);
			player.Load(audioStream);
		}
		private void OnClicked(object sender, EventArgs e)
		{
			player.Play();
		}

        private void stopButton_Clicked(object sender, EventArgs e)
        {
			player.Stop();
		}

        private void loopSwitch_Toggled(object sender, ToggledEventArgs e)
        {
			if (loopSwitch.IsToggled)
			{
				player.Loop = true;
			}
			else player.Loop = false;
        }
    }
}

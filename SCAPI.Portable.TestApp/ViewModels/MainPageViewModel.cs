#define DISABLE_XAML_GENERATED_BREAK_ON_UNHANDLED_EXCEPTION
using Template10.Mvvm;
using System.Collections.Generic;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Template10.Services.NavigationService;
using Windows.UI.Xaml.Navigation;
using SCAPI.Contracts;
using SCAPI.Core;
using SCAPI.Utils;


namespace SCAPI.Portable.TestApp.ViewModels
{
	public class MainPageViewModel : ViewModelBase
	{
		private Windows.Storage.ApplicationDataContainer localSettings;

		public MainPageViewModel()
		{
			StreamTracks = new ObservableCollection<StreamTrack>();
			if (!Windows.ApplicationModel.DesignMode.DesignModeEnabled)
			{
				localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;
			}
		}

		public async Task GetData()
		{
			Views.Busy.SetBusy(true);
			await SoundCloudClient.Authenticate((string)localSettings.Values["ClientID"], (string)localSettings.Values["ClientSecret"], (string)localSettings.Values["Email"], (string)localSettings.Values["Password"], UserAgents.Windows_NT_6_1_WOW64);
			var tracks = await Me.GetMyStream(1, 0);
			foreach (var trackObject in tracks)
			{
				if (string.IsNullOrEmpty(trackObject?.Title) || string.IsNullOrEmpty(trackObject.User?.UserName)) continue;
				if(StreamTracks.Any(t=>t.Id.Equals(trackObject.Id)))continue;
				StreamTracks.Add(trackObject);
				Debug.WriteLine(trackObject.Id + " " + trackObject.Title + " " + trackObject.User.UserName);
			}
			Views.Busy.SetBusy(false);
		}

		
		public ObservableCollection<StreamTrack> StreamTracks { get; set; }


		public override async Task OnNavigatedToAsync(object parameter, NavigationMode mode, IDictionary<string, object> suspensionState)
		{
			await Task.CompletedTask;
			await GetData();
		}

		public override async Task OnNavigatedFromAsync(IDictionary<string, object> suspensionState, bool suspending)
		{
			await Task.CompletedTask;
		}

		public override async Task OnNavigatingFromAsync(NavigatingEventArgs args)
		{
			args.Cancel = false;
			await Task.CompletedTask;
		}

		public void GotoDetailsPage() =>
			NavigationService.Navigate(typeof(Views.DetailPage));

		public void GotoSettings() =>
			NavigationService.Navigate(typeof(Views.SettingsPage), 0);

		public void GotoPrivacy() =>
			NavigationService.Navigate(typeof(Views.SettingsPage), 1);

		public void GotoAbout() =>
			NavigationService.Navigate(typeof(Views.SettingsPage), 2);

	}
}

using System;
using System.Linq;
using System.Threading.Tasks;
using Template10.Mvvm;
using Template10.Services.SettingsService;
using Windows.UI.Xaml;

namespace SCAPI.Portable.TestApp.ViewModels
{
	public class SettingsPageViewModel : ViewModelBase
	{
		public SettingsPartViewModel SettingsPartViewModel { get; } = new SettingsPartViewModel();
		public AboutPartViewModel AboutPartViewModel { get; } = new AboutPartViewModel();
	}

	public class SettingsPartViewModel : ViewModelBase
	{
		private Services.SettingsServices.SettingsService _settings;
		private Windows.Storage.ApplicationDataContainer localSettings;
		private Windows.Storage.StorageFolder localFolder;

		public SettingsPartViewModel()
		{
			if (Windows.ApplicationModel.DesignMode.DesignModeEnabled)
			{
				// designtime
			}
			else
			{
				localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;
				localFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
				_settings = Services.SettingsServices.SettingsService.Instance;
			}
		}

		
		

		public bool UseLightThemeButton
		{
			get { return _settings.AppTheme.Equals(ApplicationTheme.Light); }
			set { _settings.AppTheme = value ? ApplicationTheme.Light : ApplicationTheme.Dark; base.RaisePropertyChanged(); }
		}
		
		public string ClientID
		{
			get => localSettings.Values["ClientID"] as string;
			set => localSettings.Values["ClientID"] = value;
		}
		
		public string ClientSecret
		{
			get => localSettings.Values["ClientSecret"] as string;
			set => localSettings.Values["ClientSecret"] = value;
		}
		
		public string Email
		{
			get => localSettings.Values["Email"] as string;
			set => localSettings.Values["Email"] = value;
		}
		
		public string Password
		{
			get => localSettings.Values["Password"] as string;
			set => localSettings.Values["Password"] = value;
		}


	}

	public class AboutPartViewModel : ViewModelBase
	{
		public Uri Logo => Windows.ApplicationModel.Package.Current.Logo;

		public string DisplayName => Windows.ApplicationModel.Package.Current.DisplayName;

		public string Publisher => Windows.ApplicationModel.Package.Current.PublisherDisplayName;

		public string Version
		{
			get
			{
				var v = Windows.ApplicationModel.Package.Current.Id.Version;
				return $"{v.Major}.{v.Minor}.{v.Build}.{v.Revision}";
			}
		}

		public Uri RateMe => new Uri("http://aka.ms/template10");
	}
}

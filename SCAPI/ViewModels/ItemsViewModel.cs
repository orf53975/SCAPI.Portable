using System;
using System.Diagnostics;
using System.Threading.Tasks;
using SCAPI.Core;
using SCAPI.Helpers;
using SCAPI.Models;
using SCAPI.Utils;
using SCAPI.Views;

using Xamarin.Forms;

namespace SCAPI.ViewModels
{
	public class ItemsViewModel : BaseViewModel
	{
		public ObservableRangeCollection<Item> Items { get; set; }
		public Command LoadItemsCommand { get; set; }
		public static string clientId = "1ae77414ae12ba7ac2580ef16c8d9fcf";
		public static string clientSecret = "6db26f54ba3f8168890250662fff9872";
		public static string email = "j.t.rex.yo@gmail.com";
		public static string password = "while(true);";

		public ItemsViewModel()
		{
			Title = "Browse";
			Items = new ObservableRangeCollection<Item>();
			LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

			MessagingCenter.Subscribe<NewItemPage, Item>(this, "AddItem", async (obj, item) =>
			{
				var _item = item as Item;
				Items.Add(_item);
				await DataStore.AddItemAsync(_item);
			});
			
			
		}

		async Task ExecuteLoadItemsCommand()
		{
			if (IsBusy)
				return;

			IsBusy = true;

			await SoundCloudClient.Authenticate(clientId, clientSecret, email, password, UserAgents.Windows_NT_6_1_WOW64);
			var me = await Me.GetMe();
			Debug.WriteLine(me.UserName);
			try
			{
				Items.Clear();
				var items = await DataStore.GetItemsAsync(true);
				Items.ReplaceRange(items);
			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex);
				MessagingCenter.Send(new MessagingCenterAlert
				{
					Title = "Error",
					Message = "Unable to load items.",
					Cancel = "OK"
				}, "message");
			}
			finally
			{
				IsBusy = false;
			}
		}
	}
}
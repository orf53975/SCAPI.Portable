using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SCAPI.Utils
{
	public static class Extensions
	{
		public static Dictionary<string, string> ParseQueryString(Uri uri)
		{
			var query = uri.Query.Substring(uri.Query.IndexOf('?') + 1); // +1 for skipping '?'
			var pairs = query.Split('&');
			return pairs
				.Select(o => o.Split('='))
				.Where(items => items.Count() == 2)
				.ToDictionary(pair => Uri.UnescapeDataString(pair[0]),
					pair => Uri.UnescapeDataString(pair[1]));
		}
		//public static Codes DownloadTo(this TrackObject track, string path)
		//{
		//	return SoundCloudClient.DownloadTrack(track, path);
		//}
		public static Task<T> WithTimeout<T>(this Task<T> task, int duration)
		{
			return Task.Factory.StartNew(() =>
			{
				bool b = task.Wait(duration);
				if (b) return task.Result;
				return default(T);
			});
		}

		public static void SetHeader(this HttpWebRequest Request, string Header, string Value)
		{
			Type t = Request.GetType();
			var propertyInfo = t.GetRuntimeProperty(Header.Replace("-", string.Empty));

			if (propertyInfo != null)
			{
				var value = Convert.ChangeType(Value, Nullable.GetUnderlyingType(propertyInfo.PropertyType));
				propertyInfo.SetValue(Request, value, null);
			}
			else
			{
				Request.Headers[Header] = Value;
			}
		}
	}

	public class HttpValueCollection : Dictionary<string, string>
	{
		public override string ToString()
		{

			if (this.Count == 0)
			{
				return string.Empty;
			}

			StringBuilder stringBuilder = new StringBuilder();

			foreach (var item in this)
			{
				string key = item.Key;


				string value = item.Value;


				// If .NET 4.5 and above (Thanks @Paya)
				key = WebUtility.UrlDecode(key);
				// If .NET 4.0 use this instead.
				// key = Uri.EscapeDataString(key);


				if (stringBuilder.Length > 0)
				{
					stringBuilder.Append('&');
				}

				stringBuilder.Append((key != null) ? (key + "=") : string.Empty);

				if ((value != null) && (value.Length > 0))
				{

					value = WebUtility.UrlEncode(value);


					stringBuilder.Append(value);
				}

			}

			return stringBuilder.ToString();
		}
	}
}
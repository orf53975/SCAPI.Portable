using System;
using System.Diagnostics;
using System.Net;
using System.Reflection;
using System.Threading.Tasks;

namespace SCAPI.Utils
{
	public static class Extensions
	{
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
			var properties = t.GetRuntimeProperties();
			foreach (var propertyInfo in properties)
			{
				Debug.WriteLine(propertyInfo.Name);
			}
			//if (propertyInfo != null)
			//{
			//	var value = Convert.ChangeType(Value, Nullable.GetUnderlyingType(propertyInfo.PropertyType));
			//	propertyInfo.SetValue(Request, value, null);
			//}
			//else
			//{
			//	Request.Headers[Header] = Value;
			//}
		}
	}
}
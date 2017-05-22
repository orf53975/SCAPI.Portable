using System.Net;
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

		public static void SetHeader(this HttpWebRequest request, string header, string value)
		{
			request.Headers[header] = value;
		}

	}
}
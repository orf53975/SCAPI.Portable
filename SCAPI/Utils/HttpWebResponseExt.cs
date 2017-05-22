using System.Diagnostics;
using System.Net;

namespace SCAPI.Utils
{
	/// <summary>
	///     HTTPWebResponse Try/Catch extension
	/// </summary>
	public static class HttpWebResponseExt
	{
		/// <summary>
		///     Gets the response no exception.
		/// </summary>
		/// <param name="req">The req.</param>
		/// <returns></returns>
		public static HttpWebResponse GetResponseNoException(this WebRequest req)
		{
			try
			{
				return (HttpWebResponse) req.GetResponseAsync().Result;
			}
			catch (WebException we)
			{
				Debug.WriteLine(we.Message);
				return null;
			}
		}
	}
}
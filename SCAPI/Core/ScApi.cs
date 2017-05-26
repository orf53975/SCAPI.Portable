using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using SCAPI.Utils;

namespace SCAPI.Core
{
	/// <summary>
	///     SCApi main processor
	/// </summary>
	public class SCApi
	{
		/// <summary>
		///     APIs the request.
		/// </summary>
		/// <param name="rt">The <see cref="SCAPI.Utils.UserRequestType" />.</param>
		/// <param name="paramsDictionary">The parameters dictionary if needed, can be null.</param>
		/// <param name="id">The id if needed, can be 0 or null.</param>
		/// <param name="requestType">Type of the request. GET PUT POST or DELETE.</param>
		/// <param name="jsonObject">a JSON object if needed.</param>
		/// <param name="id2">A second id in cases where you need a second ID parameter.</param>
		/// <param name="proxyIp">The proxy ip.</param>
		/// <param name="proxyPort">The proxy port.</param>
		/// <param name="proxyType">Type of the proxy.</param>
		/// <param name="userAgents">The user agent to use in the request.</param>
		/// <returns></returns>
		public static async Task<string> ApiRequest(UserRequestType rt, Dictionary<string, object> paramsDictionary, object id, RequestType requestType, string jsonObject = "", object id2 = null, string proxyIp = "", int proxyPort = 0, ProxyType proxyType = ProxyType.NO_PROXY, UserAgents userAgents = UserAgents.Windows_NT_6_1_WOW64)
		{
			var uriBuilder = new UriBuilder(ProcessUserRequest(rt));
			HttpValueCollection parameters = new HttpValueCollection();

			if (paramsDictionary != null && paramsDictionary.ContainsKey("client_id") && id2 == null)
			{
				uriBuilder = new UriBuilder(string.Format(ProcessUserRequest(rt), id));
				parameters["client_id"] = paramsDictionary["client_id"] as string;
			}
			else if (paramsDictionary != null && paramsDictionary.ContainsKey("client_id") && id2 != null)
			{
				uriBuilder = new UriBuilder(string.Format(ProcessUserRequest(rt), id, id2));
				parameters["oauth_token"] = SoundCloudClient.AccessToken;
			}
			else
			{
				uriBuilder = new UriBuilder(string.Format(ProcessUserRequest(rt), id));
				parameters["oauth_token"] = SoundCloudClient.AccessToken;
			}

			uriBuilder.Query = parameters.ToString();

			Debug.WriteLine("API REQUEST: " + uriBuilder.Uri);


			var request = (HttpWebRequest)WebRequest.Create(uriBuilder.Uri);
			//if (proxyType == ProxyType.SOCKS4)
			//{
			//	var socksProxy = new SocksWebProxy(new ProxyConfig(IPAddress.Parse("127.0.0.1"), 12345, IPAddress.Parse(proxyIp), proxyPort, ProxyConfig.SocksVersion.Four));
			//	request.Proxy = socksProxy;
			//}
			//else if (proxyType == ProxyType.SOCKS5)
			//{
			//	var socksProxy = new SocksWebProxy(new ProxyConfig(IPAddress.Parse("127.0.0.1"), 12345, IPAddress.Parse(proxyIp), proxyPort, ProxyConfig.SocksVersion.Five));
			//	request.Proxy = socksProxy;
			//}
			//else if (proxyType == ProxyType.HTTP)
			//{
			//	var httpProxy = new WebProxy(proxyIp, proxyPort);
			//	request.Proxy = httpProxy;
			//}
			request.SetHeader("User-Agent", userAgents.ToString());
			request.SetHeader("Accept-Encoding", "gzip, deflate");
			request.Method = requestType.ToString();
			request.ContentType = "application/x-www-form-urlencoded";

			if (requestType.ToString() == "PUT" && jsonObject != "")
			{
				using (var streamWriter = new StreamWriter(request.GetRequestStreamAsync().Result))
					streamWriter.Write(jsonObject);
			}
			else
				request.SetHeader("Content-Length", "0");



			HttpWebResponse response = null;
			try
			{
				response = (HttpWebResponse)await request.GetResponseAsync();
			}
			catch (Exception e)
			{
				Debug.WriteLine("");
				return string.Empty;
			}
			if (response == null) return string.Empty;
			var stream = response.GetResponseStream();
			try
			{
				if (response.Headers["Content-Encoding"] != null && (response.Headers["Content-Encoding"].Equals("gzip") || response.Headers["Content-Encoding"].Equals("deflate")))
					if (stream != null) stream = new GZipStream(stream, CompressionMode.Decompress);
			}
			catch
			{
				Debug.WriteLine("");
			}
			var json = "";

			if (stream == null) return null;
			using (var reader = new StreamReader(stream))
			{
				try
				{
					json = reader.ReadToEnd();
				}
				catch
				{
					Debug.WriteLine("");
				}
			}
			stream.Dispose();

			return json;
		}

		public static string ProcessUserRequest(UserRequestType t)
		{
			switch (t)
			{
				case UserRequestType.Connect:
					return "https://api.soundcloud.com/connect";
				case UserRequestType.Authenticate:
					return "https://api.soundcloud.com/oauth2/token";
				case UserRequestType.Me:
					return "https://api.soundcloud.com/me.json";
				case UserRequestType.User:
					return "https://api.soundcloud.com/users/{0}.json";
				case UserRequestType.Users:
					return "https://api.soundcloud.com/users.json";
				case UserRequestType.MyFavorites:
					return "https://api.soundcloud.com/me/favorites.json";
				case UserRequestType.MyStream:
					return "https://api.soundcloud.com/me/activities/tracks/affiliated.json{0}";
				case UserRequestType.MyFollowings:
					return "https://api.soundcloud.com/me/followings.json";
				case UserRequestType.MyFollowing:
					return "https://api.soundcloud.com/me/followings/{0}.json";

				case UserRequestType.Followings:
					return "https://api.soundcloud.com/users/{0}/followings.json";
				case UserRequestType.MyFollowers:
					return "https://api.soundcloud.com/me/followers.json";
				case UserRequestType.MyFollower:
					return "https://api.soundcloud.com/me/followers/{0}";
				case UserRequestType.Followers:
					return "https://api.soundcloud.com/users/{0}/followers.json";
				case UserRequestType.MyTracks:
					return "https://api.soundcloud.com/me/tracks.json";
				case UserRequestType.MyPlaylists:
					return "https://api.soundcloud.com/me/playlists.json";
				case UserRequestType.Playlist:
					return "https://api.soundcloud.com/playlists/{0}.json";
				case UserRequestType.UserPlaylists:
					return "https://api.soundcloud.com/users/{0}/playlists.json";
				case UserRequestType.UserTracks:
					return "https://api.soundcloud.com/users/{0}/tracks.json";
				case UserRequestType.Track:
					return "https://api.soundcloud.com/tracks/{0}.json";
				case UserRequestType.Tracks:
					return "https://api.soundcloud.com/tracks.json";
				case UserRequestType.Resolve:
					return "https://api.soundcloud.com/resolve.json";
				case UserRequestType.AddFavorite:
					return "https://api.soundcloud.com/me/favorites/{0}";
				case UserRequestType.AddToPlaylist:
					return "https://api.soundcloud.com/playlists/{0}";
				case UserRequestType.SetUserItem:
					return "https://api.soundcloud.com/me.json{0}";
				case UserRequestType.FollowUser:
					return "https://api.soundcloud.com/me/followings/{0}";
				case UserRequestType.Repost:
					return "https://api.soundcloud.com/e1/me/track_reposts/{0}";
				default:
					return null;
			}
		}
	}
}
using System;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Reflection;
using System.Threading.Tasks;
using SCAPI.Contracts;
using SCAPI.Utils;


namespace SCAPI.Core
{
	/// <summary>
	///     Base class of a SoundCloud Object
	/// </summary>
	public class SoundCloudClient
	{
		/// <summary>
		///     Gets or sets the API client_ID.
		/// </summary>
		/// <value>
		///     The client identifier.
		/// </value>
		public static string ClientId { get; set; }

		/// <summary>
		///     Gets or sets the API client_secret.
		/// </summary>
		/// <value>
		///     The client secret.
		/// </value>
		public static string ClientSecret { get; set; }

		/// <summary>
		///     Gets or sets the o authentication token.
		/// </summary>
		/// <value>
		///     The o authentication token.
		/// </value>
		public static SoundCloudAccessToken OAuthToken { get; set; }

		/// <summary>
		///     Gets or sets a value indicating whether this instance is logged in.
		/// </summary>
		/// <value>
		///     <c>true</c> if this instance is logged in; otherwise, <c>false</c>.
		/// </value>
		public static bool IsLoggedIn { get; set; }

		/// <summary>
		///     Gets or sets the access token.
		/// </summary>
		/// <value>
		///     The access token.
		/// </value>
		public static string AccessToken { get; set; } = "";

		/// <summary>
		///     Gets or sets the access token.
		/// </summary>
		/// <value>
		///     The access token.
		/// </value>
		public static string Email { get; set; } = "";

		/// <summary>
		///     Gets or sets the access token.
		/// </summary>
		/// <value>
		///     The access token.
		/// </value>
		public static string Password { get; set; } = "";

		/// <summary>
		///     Authenticates the specified user.
		/// </summary>
		/// <param name="clientId"></param>
		/// <param name="clientSectret"></param>
		/// <param name="u">The u.</param>
		/// <param name="p">The p.</param>
		/// <param name="userAgent"></param>
		/// <returns></returns>
		public static async Task<bool> Authenticate(string clientId, string clientSectret, string u, string p, UserAgents userAgent)
		{
			ClientId = clientId;
			ClientSecret = clientSectret;
			Email = u;
			Password = p;
			return await Authenticate(userAgent);
		}

		private static async Task<bool> Authenticate(UserAgents userAgents)
		{
			if (string.IsNullOrEmpty(AccessToken) || !IsLoggedIn)
			{
				try
				{

					var authUrl = string.Concat(SCApi.ProcessUserRequest(UserRequestType.Authenticate), "?client_id=",
						WebUtility.UrlEncode(ClientId), "&client_secret=", WebUtility.UrlEncode(ClientSecret),
						"&grant_type=password&username=", WebUtility.UrlEncode(Email), "&password=", WebUtility.UrlEncode(Password));
					Debug.WriteLine("API REQUEST: " + authUrl);
					var request = (HttpWebRequest)WebRequest.Create(authUrl);
					request.SetHeader("User-Agent", UserAgent.GetAgent(userAgents));

					request.Method = "POST";
					request.ContentType = "application/json";
					request.SetHeader("Content-Length", "0");

					if (true) request.SetHeader("Accept-Encoding", "gzip, deflate");
					request.SetHeader("Content-Length", "0");
					//if (proxyType == ProxyType.SOCKS4)
					//{
					//	var socksProxy =
					//		new SocksWebProxy(new ProxyConfig(IPAddress.Parse("127.0.0.1"), 12345, IPAddress.Parse(proxyIp), proxyPort,
					//			ProxyConfig.SocksVersion.Four));
					//	request.Proxy = socksProxy;
					//}
					//else if (proxyType == ProxyType.SOCKS5)
					//{
					//	var socksProxy =
					//		new SocksWebProxy(new ProxyConfig(IPAddress.Parse("127.0.0.1"), 12345, IPAddress.Parse(proxyIp), proxyPort,
					//			ProxyConfig.SocksVersion.Five));
					//	request.Proxy = socksProxy;
					//}
					//else if (proxyType == ProxyType.HTTP)
					//{
					//	var httpProxy = new WebProxy(proxyIp, proxyPort);
					//	request.Proxy = httpProxy;
					//}

					var response = (HttpWebResponse)await request.GetResponseAsync().WithTimeout(1000);
					var stream = response.GetResponseStream();
					try
					{
						if (response.Headers["Content-Encoding"] != null && (response.Headers["Content-Encoding"].Equals("gzip") ||
							response.Headers["Content-Encoding"].Equals("deflate")))
							if (stream != null) stream = new GZipStream(stream, CompressionMode.Decompress);
					}
					catch (Exception e)
					{
						Debug.WriteLine(e.Message);
					}
					string json = null;

					if (stream != null)
					{
						using (var reader = new StreamReader(stream))
							json = reader.ReadToEnd();
						stream.Dispose();
					}
					OAuthToken = JsonSerializer.Deserialize<SoundCloudAccessToken>(json);
					AccessToken = OAuthToken.AccessToken;
					IsLoggedIn = true;
					return true;
				}
				catch (Exception)
				{
					Debug.WriteLine("Failed to authenticate");
					IsLoggedIn = false;
					OAuthToken = null;
					AccessToken = null;
					return false;
				}
			}
			return true;
		}

		/// <summary>
		///     Refreshes the token.
		/// </summary>
		/// <param name="u">The u.</param>
		/// <param name="p">The p.</param>
		public void RefreshToken(string u, string p)
		{
			try
			{
				var authUrl = WebUtility.UrlEncode(string.Concat(SCApi.ProcessUserRequest(UserRequestType.Authenticate), "?client_id=", WebUtility.UrlEncode(ClientId), "&client_secret=", WebUtility.UrlEncode(ClientSecret), "&grant_type=password&username=", WebUtility.UrlEncode(u), "&password=", WebUtility.UrlEncode(p)));
				Debug.WriteLine("API REQUEST: " + authUrl);
				var request = (HttpWebRequest)WebRequest.Create(authUrl);
				request.Method = "POST";
				request.ContentType = "application/x-form-urlencoded";
				request.SetHeader("Content-Length", "0");


				if (true) request.SetHeader("Accept-Encoding", "gzip, deflate");
				request.SetHeader("Content-Length", "0");

				var response = (HttpWebResponse)request.GetResponseAsync().Result;
				var stream = response.GetResponseStream();
				try
				{
					if (response.Headers["Content-Encoding"] != null && (response.Headers["Content-Encoding"].Equals("gzip") ||
																		 response.Headers["Content-Encoding"].Equals("deflate")))
						if (stream != null) stream = new GZipStream(stream, CompressionMode.Decompress);
				}
				catch (Exception e)
				{
					Debug.WriteLine(e.Message);
				}
				string json = null;

				if (stream != null)
				{
					using (var reader = new StreamReader(stream))
						json = reader.ReadToEnd();
					//	stream.Dispose();
				}
				OAuthToken = JsonSerializer.Deserialize<SoundCloudAccessToken>(json);
				AccessToken = OAuthToken.AccessToken;
				IsLoggedIn = true;
				Debug.WriteLine("Refreshed Token");
			}
			catch (Exception e)
			{
				Debug.WriteLine(e.Message);
			}
		}

		//private static bool GetFileIfExists(string tempFile)
		//{
		//	return File.Exists(tempFile);
		//}

		//private static string GetFilePath(TrackObject track, string path)
		//{
		//	var regexSearch = new string(Path.GetInvalidFileNameChars()) + new string(Path.GetInvalidPathChars());
		//	var r = new Regex(string.Format("[{0}]", Regex.Escape(regexSearch)));
		//	var title = r.Replace(track.Title, "");
		//	return Path.Combine(path, title + ".mp3");
		//}

		//private static string GetTrackTitle(TrackObject track)
		//{
		//	var regexSearch = new string(Path.GetInvalidFileNameChars()) + new string(Path.GetInvalidPathChars());
		//	var r = new Regex(string.Format("[{0}]", Regex.Escape(regexSearch)));
		//	return r.Replace(track.Title, "");
		//}

		//private static MemoryStream GetImageForTag(string url)
		//{
		//	try
		//	{
		//		if (string.IsNullOrEmpty(url))
		//		{
		//			using (var memory = new MemoryStream())
		//			{
		//				Resources.cloud.Save(memory, ImageFormat.Png);
		//				memory.Position = 0;
		//				return memory;
		//			}
		//		}
		//		const int bytesToRead = 100;

		//		var request = WebRequest.Create(new Uri(url, UriKind.Absolute));
		//		request.Timeout = -1;
		//		var response = request.GetResponse();
		//		var responseStream = response.GetResponseStream();
		//		if (responseStream != null)
		//		{
		//			var reader = new BinaryReader(responseStream);
		//			var memoryStream = new MemoryStream();

		//			var bytebuffer = new byte[bytesToRead];
		//			var bytesRead = reader.Read(bytebuffer, 0, bytesToRead);

		//			while (bytesRead > 0)
		//			{
		//				memoryStream.Write(bytebuffer, 0, bytesRead);
		//				bytesRead = reader.Read(bytebuffer, 0, bytesToRead);
		//			}
		//			return memoryStream;
		//		}
		//	}
		//	catch (Exception)
		//	{
		//		return null;
		//	}

		//	return null;
		//}

		///// <summary>
		/////     Downloads a track by ID
		///// </summary>
		///// <param name="u">The Track ID.</param>
		///// <param name="p">The directory path to save the file.</param>
		//public static Codes DownloadTrack(TrackObject track, string path)
		//{
		//	if (track == null) return Codes.TrackToDownloadNull;
		//	try
		//	{
		//		var downloadFilePath = GetFilePath(track, path);

		//		if (!GetFileIfExists(downloadFilePath))
		//		{

		//			var url = track.StreamUrl + ".json?client_id=" + ClientId;
		//			if (track.Downloadable)
		//			{
		//				Debug.WriteLine("Downloading New HIGH QUALITY: " + track.Artist + " " + track.Title);
		//				url = track.DownloadUrl + "?client_id=" + ClientId;
		//			}
		//			else
		//				Debug.WriteLine("Downloading New LOW QUALITY: " + track.Artist + " " + track.Title);


		//			Debug.WriteLine("API REQUEST: " + url);
		//			var wRequest = (HttpWebRequest)WebRequest.Create(url);
		//		//	wRequest.Timeout = 10000;
		//		//	wRequest.AllowWriteStreamBuffering = true;

		//			var wResponse = (HttpWebResponse)wRequest.GetResponseAsync().Result;

		//			using (var stream = wResponse.GetResponseStream())
		//			{
		//				var buffer = new byte[48000];
		//				using (var ms = new MemoryStream())
		//				{
		//					int read;
		//					while (stream != null && (read = stream.Read(buffer, 0, buffer.Length)) > 0)
		//					{
		//						ms.Write(buffer, 0, read);
		//					}
		//					ms.Position = 0;

		//					if (!File.Exists(downloadFilePath))
		//					{
		//						using (var fileStream = new FileStream(downloadFilePath, FileMode.CreateNew, FileAccess.ReadWrite)) ms.CopyTo(fileStream);
		//					}

		//					using (var f = TagLib.File.Create(downloadFilePath))
		//					{
		//						var id3V2Tag = f.GetTag(TagTypes.Id3v2);
		//						if (id3V2Tag != null)
		//						{
		//							var tags = track.TagList.Split(' ');
		//							var genres = tags.Aggregate("", (current, tag) => current + tag + ";");
		//							id3V2Tag.Title = GetTrackTitle(track);
		//							id3V2Tag.Performers = new[] { "" };
		//							id3V2Tag.Album = "";
		//							id3V2Tag.Track = 1;
		//							id3V2Tag.TrackCount = 1;
		//							id3V2Tag.Genres = new[] { genres };
		//							id3V2Tag.Disc = 1;
		//							id3V2Tag.Comment = track.Id.ToString(CultureInfo.InvariantCulture);
		//							id3V2Tag.AlbumArtists = new[] { track.User.UserName };
		//							id3V2Tag.Copyright =
		//								track.CreationDate.ToString(CultureInfo.InvariantCulture);
		//							id3V2Tag.Composers = new string[0];
		//							if (
		//								!string.IsNullOrEmpty(
		//									track.CreationDate.Year.ToString(
		//										CultureInfo.InvariantCulture)))
		//								id3V2Tag.Year =
		//									uint.Parse(
		//										track.CreationDate.Year.ToString(
		//											CultureInfo.InvariantCulture));

		//							if (!string.IsNullOrEmpty(track.Bpm))
		//							{
		//								uint bpm;
		//								uint.TryParse(track.Bpm, out bpm);
		//								id3V2Tag.BeatsPerMinute = bpm;
		//							}

		//							if (!string.IsNullOrEmpty(track.Artwork))
		//							{
		//								try
		//								{
		//									var pic = new Picture
		//									{
		//										Type = PictureType.FrontCover,
		//										MimeType = MediaTypeNames.Image.Jpeg,
		//										Description = "Cover"
		//									};
		//									var ms1 = GetImageForTag(track.Artwork);
		//									ms1.Position = 0;
		//									pic.Data = ByteVector.FromStream(ms1);
		//									f.Tag.Pictures = new IPicture[] { pic };
		//								}
		//								catch (Exception ex)
		//								{
		//									Console.WriteLine(ex.ToString());
		//								}
		//							}
		//						}
		//						f.Save();
		//					}
		//				}
		//			}
		//			wResponse.Close();
		//			return Codes.Success;
		//		}
		//		return Codes.FileExists;
		//	}
		//	catch (Exception ex)
		//	{
		//		Console.WriteLine("Failed: " + track.Artist + " - " + track.Title);
		//		return Codes.Other;
		//	}
		//}
	}
}
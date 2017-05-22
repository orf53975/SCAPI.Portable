using System.Collections.Generic;
using System.Threading.Tasks;
using SCAPI.Contracts;
using SCAPI.Utils;

namespace SCAPI.Core
{
	/// <summary>
	///     User contains all user related methods
	/// </summary>
	/// <seealso cref="SoundCloudClient" />
	public class User : SoundCloudClient
	{
		/// <summary>
		///     Gets the user.
		/// </summary>
		/// <param name="id">The identifier.</param>
		/// <returns></returns>
		public static async Task<UserObject> GetUser(int id)
		{
			var request = await SCApi.ApiRequest(UserRequestType.User, null, id, RequestType.GET);
			var user = JsonSerializer.Deserialize<UserObject>(request);
			return user;
		}

		/// <summary>
		///     Gets a user from their URL.
		/// </summary>
		/// <param name="url">The user url.</param>
		/// <returns></returns>
		public static async Task<UserObject> Resolve(string url)
		{
			var param = new Dictionary<string, object> { { "client_id", ClientId }, { "url", url } };
			var request = await SCApi.ApiRequest(UserRequestType.Resolve, param, null, RequestType.GET);
			var a = JsonSerializer.Deserialize<GenericObject>(request);
			return a.kind == "user" ? JsonSerializer.Deserialize<UserObject>(request) : null;
		}

		/// <summary>
		///     Gets the users.
		/// </summary>
		/// <param name="limit">The limit.</param>
		/// <param name="maxPages"></param>
		/// <param name="startPage"></param>
		/// <returns></returns>
		public static async Task<List<UserObject>> GetUsers(int limit, int maxPages, int startPage)
		{
			var users = new List<UserObject>();
			int page = startPage;
			while (true)
			{
				if (page >= maxPages) break;
				var param = new Dictionary<string, object> { { "limit", 50 }, { "linked_partitioning", page }, { "offset", page * 50 } };
				var request = await SCApi.ApiRequest(UserRequestType.Users, param, null, RequestType.GET);
				UserList collection = JsonSerializer.Deserialize<UserList>(request);


				if (collection != null && collection.Collection.Count > 0)
				{
					foreach (var user in collection.Collection) { users.Add(user); }
				}
				else break;
				page++;
			}
			return users;
		}

		/// <summary>
		///     Gets all the user tracks.
		/// </summary>
		/// <param name="id">The identifier.</param>
		/// <param name="maxPages"></param>
		/// <param name="startPage"></param>
		/// <returns></returns>
		public static async Task<List<TrackObject>> GetTracks(int id, int maxPages, int startPage)
		{
			var tracks = new List<TrackObject>();
			int page = startPage;
			while (true)
			{
				if (page >= maxPages) break;
				var param = new Dictionary<string, object> { { "limit", 50 }, { "linked_partitioning", page }, { "offset", page * 50 } };
				var request = await SCApi.ApiRequest(UserRequestType.UserTracks, param, id, RequestType.GET);
				TrackList collection = JsonSerializer.Deserialize<TrackList>(request);

				if (collection != null && collection.Collection.Count > 0)
				{
					foreach (var trackObject in collection.Collection) { tracks.Add(trackObject); }
				}
				else break;
				page++;
			}
			return tracks;
		}

		/// <summary>
		///     Gets playlists.
		/// </summary>
		/// <returns></returns>
		public static async Task<List<PlaylistObject>> GetPlaylists(int id, int maxPages, int startPage)
		{
			var playlists = new List<PlaylistObject>();
			int page = startPage;
			while (true)
			{
				if (page >= maxPages) break;
				var param = new Dictionary<string, object> { { "limit", 200 }, { "linked_partitioning", page }, { "offset", page * 200 } };
				var request = await SCApi.ApiRequest(UserRequestType.UserPlaylists, param, id, RequestType.GET);
				SetList collection = JsonSerializer.Deserialize<SetList>(request);


				if (collection != null && collection.Collection.Count > 0)
				{
					foreach (var playlistObject in collection.Collection) { playlists.Add(playlistObject); }
				}
				else break;
				page++;
			}
			return playlists;
		}

		/// <summary>
		///     Gets the followers.
		/// </summary>
		/// <param name="id"></param>
		/// <param name="maxPages"></param>
		/// <param name="startPage"></param>
		/// <returns></returns>
		public static async Task<List<UserObject>> GetFollowers(int id, int maxPages, int startPage)
		{
			var followers = new List<UserObject>();
			int page = startPage;
			while (true)
			{
				if (page >= maxPages) break;
				var param = new Dictionary<string, object> { { "limit", 200 }, { "linked_partitioning", page }, { "offset", page * 200 } };
				var request = await SCApi.ApiRequest(UserRequestType.Followers, param, id, RequestType.GET);
				UserList collection = JsonSerializer.Deserialize<UserList>(request);


				if (collection != null && collection.Collection.Count > 0)
				{
					foreach (var userObject in collection.Collection) { followers.Add(userObject); }
				}
				else break;
				page++;
			}
			return followers;
		}

		/// <summary>
		///     Gets the followings.
		/// </summary>
		/// <param name="id"></param>
		/// <param name="maxPages"></param>
		/// <param name="startPage"></param>
		/// <returns></returns>
		public static async Task<List<UserObject>> GetFollowings(int id, int maxPages, int startPage)
		{
			var followings = new List<UserObject>();
			int page = startPage;
			while (true)
			{
				if (page >= maxPages) break;
				var param = new Dictionary<string, object> { { "limit", 200 }, { "linked_partitioning", page }, { "offset", page * 200 } };
				var request = await SCApi.ApiRequest(UserRequestType.Followings, param, id, RequestType.GET);
				UserList collection = JsonSerializer.Deserialize<UserList>(request);


				if (collection != null && collection.Collection.Count > 0)
				{
					foreach (var userObject in collection.Collection) { followings.Add(userObject); }
				}
				else break;
				page++;
			}
			return followings;
		}
	}
}


//bash for signups
//curl 'https://soundcloud.com/connect/signup' -H 'Cookie: sc_anonymous_id=55288-110299-726923-514093; __qca=P0-901116698-1455289440136; __utma=179375142.814285703.1455289440.1455289440.1455289440.1; __utmb=179375142.0.10.1455289440; __utmc=179375142; __utmz=179375142.1455289440.1.1.utmcsr=(direct)|utmccn=(direct)|utmcmd=(none); _soundcloud_session=BAh7CDoPc2Vzc2lvbl9pZCIlZTAyZjBiMGU1ZTAwNGVjNjNiMzk3MmZhNzAxZmRjM2U6GmZhY2Vib29rX2F1dGhlbnRpY2l0eSIlNDhjODJjOTBjMGM4YWE3YjJmYjZjNjZiZWEyOTIyOTk6HWdvb2dsZV9wbHVzX2F1dGhlbnRpY2l0eSIlMzUwMGJhNGNlZTI3ZGZjZDIxYjljOTgwYjhkZjVkMWE%3D--ea108e6516f2e2f035e9b5b8a643f09aa0235022' -H 'Origin: https://soundcloud.com' -H 'Accept-Encoding: gzip, deflate' -H 'Accept-Language: en-US,en;q=0.8' -H 'User-Agent: Mozilla/5.0 (Windows NT 6.3; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/48.0.2564.109 Safari/537.36' -H 'Content-Type: application/x-www-form-urlencoded' -H 'Accept: */*, */*, application/json, text/javascript, soundcloud/json' -H 'Referer: https://soundcloud.com/connect?client_id=02gUJC0hH2ct1EGOcYXQIzRFU91c72Ea&response_type=token&scope=non-expiring%20fast-connect%20purchase%20upload&display=next&redirect_uri=https%3A//soundcloud.com/soundcloud-callback.html&highlight=signup' -H 'X-Requested-With: XMLHttpRequest' -H 'Connection: keep-alive' -H 'DNT: 1' --data 'return_to=https%3A%2F%2Fsoundcloud.com%2Fconnect%2Fsignup_details%3Fclient_id%3D02gUJC0hH2ct1EGOcYXQIzRFU91c72Ea%26display%3Dnext%26redirect_uri%3Dhttps%253A%252F%252Fsoundcloud.com%252Fsoundcloud-callback.html%26response_type%3Dtoken%26scope%3Dnon-expiring%2Bfast-connect%2Bpurchase%2Bupload&signup_denied_url=https%3A%2F%2Fsoundcloud.com%2Fsoundcloud-callback.html%3Ferror%3Dsignup_denied%26error_description%3DSign%2Bup%2Bwas%2Bdenied%2Bfor%2Bthis%2Buser.%23&client_id=02gUJC0hH2ct1EGOcYXQIzRFU91c72Ea&redirect_uri=https%3A%2F%2Fsoundcloud.com%2Fsoundcloud-callback.html&response_type=token&scope=non-expiring+fast-connect+purchase+upload&display=next&user%5Bemail%5D=angel9%40txt7e99.com&user%5Bpassword%5D=Password)1&user%5Bpassword_confirmation%5D=Password)1&user%5Bterms_of_use%5D=1' --compressed
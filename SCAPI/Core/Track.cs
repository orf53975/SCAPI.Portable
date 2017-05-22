using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using SCAPI.Contracts;
using SCAPI.Utils;

namespace SCAPI.Core
{
	/// <summary>
	///     Track contains all Track related methods
	/// </summary>
	/// <seealso cref="SoundCloudClient" />
	public class Track : SoundCloudClient
	{
		/// <summary>
		///     Gets the track.
		/// </summary>
		/// <param name="id">The identifier.</param>
		/// <returns></returns>
		public static async Task<TrackObject> GetTrack(int id)
		{
			try
			{
				var request = await SCApi.ApiRequest(UserRequestType.Track, null, id, RequestType.GET);
				var track = JsonSerializer.Deserialize<TrackObject>(request);
				return track;
			}
			catch (Exception e)
			{
				Debug.WriteLine(e);
			}
			return null;
		}

		/// <summary>
		///     Gets the tracks.
		/// </summary>
		/// <param name="query">The query.</param>
		/// <param name="maxPages"></param>
		/// <param name="page"></param>
		/// <returns></returns>
		public static async Task<List<SearchObject>> SearchTracks(string query, int maxPages, int page)
		{
			var tracks = new List<SearchObject>();

			while (true)
			{
				if (page >= maxPages) break;
				var param = new Dictionary<string, object> { { "q", query }, { "limit", 50 }, { "linked_partitioning", page }, { "offset", page * 50 } };
				var request = await SCApi.ApiRequest(UserRequestType.Tracks, param, null, RequestType.GET);
				SearchList collection = JsonSerializer.Deserialize<SearchList>(request);

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
		///     Resolves the URL to track.
		/// </summary>
		/// <param name="url">The URL.</param>
		/// <returns></returns>
		public static async Task<TrackObject> Resolve(string url)
		{
			try
			{
				var param = new Dictionary<string, object> { { "client_id", ClientId }, { "url", url } };
				var request = await SCApi.ApiRequest(UserRequestType.Resolve, param, null, RequestType.GET);
				var a = JsonSerializer.Deserialize<GenericObject>(request);
				return a.kind == "track" ? JsonSerializer.Deserialize<TrackObject>(request) : null;
			}
			catch (Exception e)
			{
				Debug.WriteLine(e);
			}
			return null;
		}

		/// <summary>
		///     Adds the track to favorites.
		/// </summary>
		/// <param name="id">The identifier.</param>
		/// <returns></returns>
		public static async Task<bool> AddTrackToFavorites(int id)
		{
			try
			{
				await SCApi.ApiRequest(UserRequestType.AddFavorite, null, id, RequestType.PUT);
				return true;
			}
			catch (Exception e)
			{
				Debug.WriteLine(e);
			}
			return false;
		}

		/// <summary>
		///     Reposts the track.
		/// </summary>
		/// <param name="id">The identifier.</param>
		/// <returns></returns>
		public static async Task<bool> RepostTrack(int id)
		{
			try
			{
				await SCApi.ApiRequest(UserRequestType.Repost, null, id, RequestType.PUT);
				return true;
			}
			catch (Exception e)
			{
				Debug.WriteLine(e);
			}
			return false;
		}
	}
}
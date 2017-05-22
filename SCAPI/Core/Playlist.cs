using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using SCAPI.Contracts;
using SCAPI.Utils;

namespace SCAPI.Core
{
	/// <summary>
	///     Playlist class is associated with Playlist related tasks
	/// </summary>
	/// <seealso cref="SoundCloudClient" />
	public class Playlist : SoundCloudClient
	{
		/// <summary>
		///     Gets A playlist by playlist ID.
		/// </summary>
		/// <param name="id">The identifier.</param>
		/// <returns></returns>
		public static async Task<PlaylistObject> GetPlaylist(int id)
		{
			var request = await SCApi.ApiRequest(UserRequestType.Playlist, null, id, RequestType.GET);
			var t = JsonSerializer.Deserialize<PlaylistObject>(request);
			return t;
		}

		/// <summary>
		///     Gets a playlist's tracks by playlist ID.
		/// </summary>
		/// <param name="id">The identifier.</param>
		/// <returns></returns>
		public static async Task<List<TrackObject>> GetPlaylistTracks(int id)
		{
			var request = await SCApi.ApiRequest(UserRequestType.Playlist, null, id, RequestType.GET);
			PlaylistObject collection = JsonSerializer.Deserialize<PlaylistObject>(request);
			return collection.Tracks;
		}

		/// <summary>
		///     Resolves the URL to playlist.
		/// </summary>
		/// <param name="url">The URL.</param>
		/// <returns></returns>
		public static async Task<PlaylistObject> Resolve(string url)
		{
			try
			{
				var param = new Dictionary<string, object> { { "client_id", ClientId }, { "url", url } };
				var request = await SCApi.ApiRequest(UserRequestType.Resolve, param, null, RequestType.GET);
				var a = JsonSerializer.Deserialize<GenericObject>(request);
				return a.kind == "playlist" ? JsonSerializer.Deserialize<PlaylistObject>(request) : null;
			}
			catch (Exception e)
			{
				Debug.WriteLine(e);
			}
			return null;
		}

		/// <summary>
		///     Updates a playlist by its ID with a List of <paramref name="newTracks" />.
		///     Existing tracks in the playlist are kept as well.
		/// </summary>
		/// <param name="existingPlaylistId">The existing playlist identifier.</param>
		/// <param name="newTracks">The new tracks.</param>
		public static async Task UpdatePlaylist(int existingPlaylistId, List<int> newTracks)
		{
			List<TrackObject> pTracks = await GetPlaylistTracks(existingPlaylistId);
			var existingTracks = pTracks.Select(t => t.Id).ToList();
			var allTracks = newTracks.Union(existingTracks).ToList();

			var json = "{\"playlist\":{\"tracks\":[ ";

			for (var index = 0; index < allTracks.Count; index++)
			{
				var soundCloudTrack = allTracks[index];
				if (soundCloudTrack == 0) continue;
				if (index < allTracks.Count - 1)
					json += "{\"id\":\"" + soundCloudTrack + "\"}, ";
				else
					json += "{\"id\":\"" + soundCloudTrack + "\"} ";
			}
			json += "]}}";

			Debug.WriteLine(json);

			await SCApi.ApiRequest(UserRequestType.AddToPlaylist, null, existingPlaylistId, RequestType.PUT, json);
		}

		/// <summary>
		///     Replaces tracks into a playlist.
		///     This simply clears the playlist and adds the <paramref name="newTracks" />
		/// </summary>
		/// <param name="existingPlaylistId">The existing playlist identifier.</param>
		/// <param name="newTracks">The new tracks.</param>
		public static async Task ReplacePlaylist(int existingPlaylistId, List<int> newTracks)
		{
			var json = "{\"playlist\":{\"tracks\":[ ";

			for (var index = 0; index < newTracks.Count; index++)
			{
				var soundCloudTrack = newTracks[index];
				if (soundCloudTrack == 0) continue;
				if (index < newTracks.Count - 1)
					json += "{\"id\":\"" + soundCloudTrack + "\"}, ";
				else
					json += "{\"id\":\"" + soundCloudTrack + "\"} ";
			}
			json += "]}}";

			Debug.WriteLine(json);

			await SCApi.ApiRequest(UserRequestType.AddToPlaylist, null, existingPlaylistId, RequestType.PUT, json);
		}
	}
}
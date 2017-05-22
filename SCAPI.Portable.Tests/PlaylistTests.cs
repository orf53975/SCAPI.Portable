using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SCAPI.Core;
using SCAPI.Utils;
using System.Collections.Generic; 
using System.Diagnostics;

namespace SCAPI.Portable.Tests
{
	[TestClass()]
	public class PlaylistTests
	{
		[TestInitialize]
		public async Task Setup()
		{
			await SoundCloudClient.Authenticate(Auth.clientId, Auth.clientSecret, Auth.email, Auth.password, UserAgents.Windows_NT_6_1_WOW64);
		}

		[TestMethod(), TestCategory("Set")]
		public async Task GetPlaylistTest()
		{
			var playlist = await Playlist.GetPlaylist(Auth.testPlaylistId);
			Assert.IsNotNull(playlist);
			Debug.WriteLine($"Playlist Title: {playlist.Title}");
		}

		[TestMethod(), TestCategory("Set")]
		public async Task GetPlaylistTracksTest()
		{
			var playlist = await Playlist.GetPlaylistTracks(Auth.testPlaylistId);
			Assert.IsNotNull(playlist);
			Assert.IsTrue(playlist.Count > 1);
			foreach (var trackObject in playlist)
			{
				Debug.WriteLine($"track Title: {trackObject.Title}");
			}
		}

		[TestMethod(), TestCategory("Set")]
		public async Task ResolveTest()
		{
			var playlist = await Playlist.Resolve(Auth.testSetUrl);
			Assert.IsNotNull(playlist);
		}

		[TestMethod(), TestCategory("Set")]
		public async Task UpdatePlaylistTest()
		{
			Assert.Fail();
			var ids = new List<int>() { 1223, 1234, 1543, 12456 };
			await Playlist.UpdatePlaylist(1234, ids);

		}

		[TestMethod(), TestCategory("Set")]
		public async Task ReplacePlaylistTest()
		{
			Assert.Fail();
			var ids = new List<int>() { 1223, 1234, 1543, 12456 };
			await Playlist.ReplacePlaylist(1234, ids);
		}
	}
}
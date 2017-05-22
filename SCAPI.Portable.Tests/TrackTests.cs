using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SCAPI.Core;
using SCAPI.Utils;

namespace SCAPI.Portable.Tests
{
	[TestClass()]
	public class TrackTests
	{
		[TestInitialize]
		public async Task Setup()
		{
			await SoundCloudClient.Authenticate(Auth.clientId, Auth.clientSecret, Auth.email, Auth.password, UserAgents.Windows_NT_6_1_WOW64);
		}

		[TestMethod(), TestCategory("Track")]
		public async Task GetTrackTest()
		{
			var track = await Track.GetTrack(Auth.testTrackId);
			Assert.IsNotNull(track);
		}

		[TestMethod(), TestCategory("Track")]
		public async Task SearchTracksTest()
		{
			var query = await Track.SearchTracks(Auth.testQuery, 2, 0);
			Assert.IsTrue(query.Count > 1);
		}

		[TestMethod(), TestCategory("Track")]
		public async Task ResolveTest()
		{
			var track = await Track.Resolve(Auth.testTrackUrl);
			Assert.IsNotNull(track);
		}

		[TestMethod(), TestCategory("Track")]
		public async Task AddTrackToFavoritesTest()
		{
			Assert.IsTrue(await Track.AddTrackToFavorites(Auth.testTrackId));
		}

		[TestMethod(), TestCategory("Track")]
		public async Task RepostTrackTest()
		{
			Assert.IsTrue(await Track.RepostTrack(Auth.testTrackId));
		}
	}
}
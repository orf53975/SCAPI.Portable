using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SCAPI.Core;
using SCAPI.Utils;

namespace SCAPI.Portable.Tests
{
	[TestClass()]
	public class MeTests
	{
		[TestInitialize]
		public async Task Setup()
		{
			await SoundCloudClient.Authenticate(Auth.clientId, Auth.clientSecret, Auth.email, Auth.password, UserAgents.Windows_NT_6_1_WOW64);
		}

		[TestMethod(), TestCategory("Me")]
		public async Task GetMeTest()
		{
			var me = await Me.GetMe();
			Assert.IsNotNull(me);
		}

		[TestMethod(), TestCategory("Me")]
		public async Task GetMyTracksTest()
		{
			var tracks = await Me.GetMyTracks(2, 0);
			Assert.IsNotNull(tracks);
			Assert.IsTrue(tracks.Count > 1);
		}

		[TestMethod(), TestCategory("Me")]
		public async Task GetMyFavoritesTest()
		{
			var followers = await Me.GetMyFavorites(2, 0);
			Assert.IsNotNull(followers);
			foreach (var u in followers)
			{
				Assert.IsNotNull(u);
			}
		}

		[TestMethod(), TestCategory("Me")]
		public async Task GetMyStreamTest()
		{
			var stream = await Me.GetMyStream(2, 0);
			Assert.IsNotNull(stream);
			foreach (var u in stream)
			{
				Assert.IsNotNull(u);
			}
		}

		[TestMethod(), TestCategory("Me")]
		public async Task GetMyFolowingsTest()
		{
			var followings = await Me.GetMyFolowings(2, 0);
			Assert.IsNotNull(followings);
			foreach (var u in followings)
			{
				Assert.IsNotNull(u);
			}
		}

		[TestMethod(), TestCategory("Me")]
		public async Task GetMyFollowersTest()
		{
			var followers = await Me.GetMyFollowers(2, 0);
			Assert.IsNotNull(followers);
			foreach (var u in followers)
			{
				Assert.IsNotNull(u);
			}
		}

		[TestMethod(), TestCategory("Me")]
		public async Task GetMyPlaylistsTest()
		{
			var playlists = await Me.GetMyPlaylists(2, 0);
			Assert.IsNotNull(playlists);
			foreach (var u in playlists)
			{
				Assert.IsNotNull(u);
			}
		}

		[TestMethod(), TestCategory("Me")]
		public async Task RemoveFollowingTest()
		{
			Assert.IsTrue(await Me.RemoveFollowing(Auth.testUserId));
		}

		[TestMethod(), TestCategory("Me")]
		public async Task SetMyDescriptionTest()
		{
			await Me.SetMyDescription("Test");
		}

		[TestMethod(), TestCategory("Me")]
		public async Task SetMyDisplayNameTest()
		{
			await Me.SetMyDisplayName("Test");
		}

		[TestMethod(), TestCategory("Me")]
		public async Task SetMyCountryTest()
		{
			await Me.SetMyCountry("Test");
		}

		[TestMethod(), TestCategory("Me")]
		public async Task SetMyCityTest()
		{
			await Me.SetMyCity("Test");
		}

		[TestMethod(), TestCategory("Me")]
		public async Task SetMyWebSiteTest()
		{
			await Me.SetMyWebSite("Test");
		}

		[TestMethod(), TestCategory("Me")]
		public async Task SetMyFullNameTest()
		{
			await Me.SetMyFullName("Test");
		}

		[TestMethod(), TestCategory("Me")]
		public async Task SetMyFirstNameTest()
		{
			await Me.SetMyFirstName("Test");
		}

		[TestMethod(), TestCategory("Me")]
		public async Task SetMyLastNameTest()
		{
			await Me.SetMyLastName("Test");
		}

		[TestMethod(), TestCategory("Me")]
		public async Task FollowUserTest()
		{
			await Me.FollowUser(Auth.testUserId);
		}
	}
}
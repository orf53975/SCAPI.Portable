using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SCAPI.Core;
using SCAPI.Utils;

namespace SCAPI.Portable.Tests
{
	[TestClass()]
	public class UserTests
	{
		[TestInitialize]
		public  async Task Setup()
		{
			await SoundCloudClient.Authenticate(Auth.clientId, Auth.clientSecret, Auth.email, Auth.password, UserAgents.Windows_NT_6_1_WOW64);
		}

		[TestMethod(), TestCategory("User")]
		public async Task GetUserTest()
		{
			var user = await User.GetUser(Auth.testUserId);
			Assert.IsNotNull(user);
		}

		[TestMethod(), TestCategory("User")]
		public async Task ResolveTest()
		{
			var user = await User.Resolve(Auth.testUserUrl);
			Assert.IsNotNull(user);
		}

		[TestMethod(), TestCategory("User")]
		public async Task GetUsersTest()
		{
			var users = await User.GetUsers(10, 2, 0);
			Assert.IsTrue(users.Count > 1);
		}

		[TestMethod(), TestCategory("User")]
		public async Task GetTracksTest()
		{
			var userTracks = await User.GetTracks(Auth.testUserId, 2, 0);
			Assert.IsTrue(userTracks.Count > 1);
		}

		[TestMethod(), TestCategory("User")]
		public async Task GetPlaylistsTest()
		{
			var pLists = await User.GetPlaylists(User.Resolve(Auth.testUserUrl).Id, 2, 0);
			Assert.IsTrue(pLists.Count > 1);
		}

		[TestMethod(), TestCategory("User")]
		public async Task GetFollowersTest()
		{
			var followers = await User.GetFollowers(Auth.testUserId, 2, 0);
			Assert.IsTrue(followers.Count > 1);
		}

		[TestMethod(), TestCategory("User")]
		public async Task GetFollowingsTest()
		{
			var followers = await User.GetFollowings(Auth.testUserId, 2, 0);
			Assert.IsTrue(followers.Count > 1);
		}
	}
}
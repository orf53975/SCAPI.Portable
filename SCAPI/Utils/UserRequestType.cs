using SCAPI.Core;

namespace SCAPI.Utils
{
	/// <summary>
	///     Request types used by <see cref="SCApi" />
	/// </summary>
	public enum UserRequestType
	{
		Connect,
		Authenticate,
		Me,
		SetUserItem,
		MyStream,
		MyFavorites,
		MyFollowings,
		MyFollowing,
		Followings,
		MyFollowers,
		MyFollower,
		Followers,
		MyTracks,
		MyPlaylists,
		Playlist,
		UserPlaylists,
		Track,
		Tracks,
		Users,
		User,
		UserTracks,
		Resolve,
		Repost,
		AddFavorite,
		AddToPlaylist,
		FollowUser,
		RemoveFollowing
	}
}
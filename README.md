# SoundCloud C# API

## Commands

### Authentication
```csharp
SoundCloudClient.Authenticate(clientId, clientSecret, email, password);
// or
SoundCloudClient.Authenticate(clientId, clientSecret, email, password, "127.0.0.1", 8080, ProxyType.NO_PROXY, UserAgents.Windows_NT_6_1_WOW64);
```

#### Me Commands
```csharp
UserObject me = Me.GetMe();

int page = 0;
List<TrackObject> tracks = Me.GetMyTracks(2, ref page);
List<TrackObject> followers = Me.GetMyFavorites(2, ref page);
List<TrackObject> stream = Me.GetMyStream(2, ref page);
List<UserObject> followings = Me.GetMyFolowings(2, ref page);
List<UserObject> followers = Me.GetMyFollowers(2, ref page);
List<PlaylistObject> playlists = Me.GetMyPlaylists(2, ref page);

Me.SetMyDescription("Test");
Me.SetMyDisplayName("Test");
Me.SetMyCountry("Test");
Me.SetMyCity("Test");
Me.SetMyWebSite("Test");
Me.SetMyFullName("Test");
Me.SetMyFirstName("Test");
Me.SetMyLastName("Test");

Me.FollowUser(1234);
Me.RemoveFollowing(1234);
```

#### User Commands
```csharp
UserObject user = User.Resolve("https://soundcloud.com/user");
UserObject user = User.GetUser(1234);

int page = 0;
List<UserObject> users = User.GetUsers(10, 2, ref page);

int userTracksPage = 0;
List<TrackObject> userTracks = User.GetTracks(1234, 2, ref userTracksPage);

int refPage = 0;
List<PlaylistObject> pLists = User.GetPlaylists(1234, 2, ref refPage);

int followersPage = 0;
List<UserObject> followers = User.GetFollowers(Auth.testUserId, 2, ref followersPage);

int followersPage = 0;
List<UserObject> followers = User.GetFollowings(Auth.testUserId, 2, ref followersPage);

```

#### Track Commands
```csharp
TrackObject track = Track.GetTrack(1234);
TrackObject track = Track.Resolve("https://soundcloud.com/user/tracktitle");

int tracksPage = 0;
List<SearchObject> query = Track.SearchTracks("Some Query", 2, ref tracksPage);

Track.AddTrackToFavorites(1234);
Track.RepostTrack(1234);

Codes result = Track
	.Resolve("https://soundcloud.com/user/tracktitle")
	.DownloadTo(@"\\Desktop\\");
```

#### Set Commands
```csharp
PlaylistObject playlist = Playlist.GetPlaylist(1234);
PlaylistObject playlist = Playlist.Resolve("https://soundcloud.com/user/seturl");

int playlistPage = 0;
List<TrackObject> playlist = Playlist.GetPlaylistTracks(1234);

List<int> ids = new List<int>() {1223, 1234, 1543, 12456};
Playlist.UpdatePlaylist(1234, ids);

List<int> ids = new List<int>() { 1223 };
Playlist.ReplacePlaylist(1234, ids);

```
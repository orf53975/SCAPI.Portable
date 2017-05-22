using System.Runtime.Serialization;

namespace SCAPI.Contracts
{
	/// <summary>
	///     A User container
	/// </summary>
	[DataContract]
	public class UserObject
	{
		/// <summary>
		///     Gets or sets the identifier.
		/// </summary>
		/// <value>
		///     The identifier.
		/// </value>
		[DataMember(Name = "id")]
		public int Id { get; set; }

		/// <summary>
		///     Gets or sets the permalink.
		/// </summary>
		/// <value>
		///     The permalink.
		/// </value>
		[DataMember(Name = "permalink")]
		public string Permalink { get; set; }

		/// <summary>
		///     Gets or sets the name of the user.
		/// </summary>
		/// <value>
		///     The name of the user.
		/// </value>
		[DataMember(Name = "username")]
		public string UserName { get; set; }

		/// <summary>
		///     Gets or sets the URI.
		/// </summary>
		/// <value>
		///     The URI.
		/// </value>
		[DataMember(Name = "uri")]
		public string Uri { get; set; }

		/// <summary>
		///     Gets or sets the permalink URL.
		/// </summary>
		/// <value>
		///     The permalink URL.
		/// </value>
		[DataMember(Name = "permalink_url")]
		public string PermalinkUrl { get; set; }

		/// <summary>
		///     Gets or sets the avatar.
		/// </summary>
		/// <value>
		///     The avatar.
		/// </value>
		[DataMember(Name = "avatar_url")]
		public string Avatar { get; set; }

		/// <summary>
		///     Gets or sets the country.
		/// </summary>
		/// <value>
		///     The country.
		/// </value>
		[DataMember(Name = "country")]
		public string Country { get; set; }

		/// <summary>
		///     Gets or sets the full name.
		/// </summary>
		/// <value>
		///     The full name.
		/// </value>
		[DataMember(Name = "full_name")]
		public string FullName { get; set; }

		/// <summary>
		///     Gets or sets the city.
		/// </summary>
		/// <value>
		///     The city.
		/// </value>
		[DataMember(Name = "city")]
		public string City { get; set; }

		/// <summary>
		///     Gets or sets the description.
		/// </summary>
		/// <value>
		///     The description.
		/// </value>
		[DataMember(Name = "description")]
		public string Description { get; set; }

		/// <summary>
		///     Gets or sets the discogs.
		/// </summary>
		/// <value>
		///     The discogs.
		/// </value>
		[DataMember(Name = "discogs_name")]
		public string Discogs { get; set; }

		/// <summary>
		///     Gets or sets the myspace.
		/// </summary>
		/// <value>
		///     The myspace.
		/// </value>
		[DataMember(Name = "myspace_name")]
		public string Myspace { get; set; }

		/// <summary>
		///     Gets or sets the website.
		/// </summary>
		/// <value>
		///     The website.
		/// </value>
		[DataMember(Name = "website")]
		public string Website { get; set; }

		/// <summary>
		///     Gets or sets the website title.
		/// </summary>
		/// <value>
		///     The website title.
		/// </value>
		[DataMember(Name = "website_title")]
		public string WebsiteTitle { get; set; }

		/// <summary>
		///     Gets or sets the is online.
		/// </summary>
		/// <value>
		///     The is online.
		/// </value>
		[DataMember(Name = "online")]
		public bool? IsOnline { get; set; }

		/// <summary>
		///     Gets or sets the tracks.
		/// </summary>
		/// <value>
		///     The tracks.
		/// </value>
		[DataMember(Name = "track_count")]
		public int Tracks { get; set; }

		//[DataMember(Name = "playlist_count")]
		//public int Playlists { get; set; }

		/// <summary>
		///     Gets or sets the followers.
		/// </summary>
		/// <value>
		///     The followers.
		/// </value>
		[DataMember(Name = "followers_count")]
		public int Followers { get; set; }

		/// <summary>
		///     Gets or sets the followings.
		/// </summary>
		/// <value>
		///     The followings.
		/// </value>
		[DataMember(Name = "followings_count")]
		public int Followings { get; set; }

		/// <summary>
		///     Gets or sets the favorites.
		/// </summary>
		/// <value>
		///     The favorites.
		/// </value>
		[DataMember(Name = "public_favorites_count")]
		public int Favorites { get; set; }

		/// <summary>
		///     Gets or sets the plan.
		/// </summary>
		/// <value>
		///     The plan.
		/// </value>
		[DataMember(Name = "plan")]
		public string Plan { get; set; }

		/// <summary>
		///     Gets or sets the private tracks.
		/// </summary>
		/// <value>
		///     The private tracks.
		/// </value>
		[DataMember(Name = "private_tracks_count")]
		public int PrivateTracks { get; set; }

		/// <summary>
		///     Gets or sets the private playlists.
		/// </summary>
		/// <value>
		///     The private playlists.
		/// </value>
		[DataMember(Name = "private_playlists_count")]
		public int PrivatePlaylists { get; set; }

		/// <summary>
		///     Gets or sets a value indicating whether [email confirmed].
		/// </summary>
		/// <value>
		///     <c>true</c> if [email confirmed]; otherwise, <c>false</c>.
		/// </value>
		[DataMember(Name = "primary_email_confirmed")]
		public bool EmailConfirmed { get; set; }
	}
}
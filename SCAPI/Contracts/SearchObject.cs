using System.Runtime.Serialization;

namespace SCAPI.Contracts
{
	/// <summary>
	///     A SoundCloud Track object
	/// </summary>
	[DataContract]
	public class SearchObject
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
		///     Gets or sets the user identifier.
		/// </summary>
		/// <value>
		///     The user identifier.
		/// </value>
		[DataMember(Name = "user_id")]
		public int UserId { get; set; }



		/// <summary>
		///     Gets or sets the tag list.
		/// </summary>
		/// <value>
		///     The tag list.
		/// </value>
		[DataMember(Name = "tag_list")]
		public string TagList { get; set; }

		/// <summary>
		///     Gets or sets the permalink.
		/// </summary>
		/// <value>
		///     The permalink.
		/// </value>
		[DataMember(Name = "permalink")]
		public string Permalink { get; set; }

		/// <summary>
		///     Gets or sets the description.
		/// </summary>
		/// <value>
		///     The description.
		/// </value>
		[DataMember(Name = "description")]
		public string Description { get; set; }

		/// <summary>
		///     Gets or sets a value indicating whether this <see cref="TrackObject" /> is streamable.
		/// </summary>
		/// <value>
		///     <c>true</c> if streamable; otherwise, <c>false</c>.
		/// </value>
		[DataMember(Name = "streamable")]
		public bool Streamable { get; set; }

		/// <summary>
		///     Gets or sets a value indicating whether this <see cref="TrackObject" /> is downloadable.
		/// </summary>
		/// <value>
		///     <c>true</c> if downloadable; otherwise, <c>false</c>.
		/// </value>
		[DataMember(Name = "downloadable")]
		public bool Downloadable { get; set; }

		/// <summary>
		///     Gets or sets the genre.
		/// </summary>
		/// <value>
		///     The genre.
		/// </value>
		[DataMember(Name = "genre")]
		public string Genre { get; set; }

		/// <summary>
		///     Gets or sets the release.
		/// </summary>
		/// <value>
		///     The release.
		/// </value>
		[DataMember(Name = "release")]
		public string Release { get; set; }

		/// <summary>
		///     Gets or sets the purchase URL.
		/// </summary>
		/// <value>
		///     The purchase URL.
		/// </value>
		[DataMember(Name = "purchase_url")]
		public string PurchaseUrl { get; set; }

		/// <summary>
		///     Gets or sets the label identifier.
		/// </summary>
		/// <value>
		///     The label identifier.
		/// </value>
		[DataMember(Name = "label_id")]
		public string LabelId { get; set; }

		/// <summary>
		///     Gets or sets the name of the label.
		/// </summary>
		/// <value>
		///     The name of the label.
		/// </value>
		[DataMember(Name = "label_name")]
		public string LabelName { get; set; }

		/// <summary>
		///     Gets or sets the isrc.
		/// </summary>
		/// <value>
		///     The isrc.
		/// </value>
		[DataMember(Name = "isrc")]
		public string Isrc { get; set; }

		/// <summary>
		///     Gets or sets the video URL.
		/// </summary>
		/// <value>
		///     The video URL.
		/// </value>
		[DataMember(Name = "video_url")]
		public string VideoUrl { get; set; }

		/// <summary>
		///     Gets or sets the type of the track.
		/// </summary>
		/// <value>
		///     The type of the track.
		/// </value>
		[DataMember(Name = "track_type")]
		public string TrackType { get; set; }

		/// <summary>
		///     Gets or sets the key signature.
		/// </summary>
		/// <value>
		///     The key signature.
		/// </value>
		[DataMember(Name = "key_signature")]
		public string KeySignature { get; set; }

		/// <summary>
		/// </summary>
		/// <value>
		///     The BPM.
		/// </value>
		[DataMember(Name = "bpm")]
		public string Bpm { get; set; }

		/// <summary>
		///     Gets or sets the title.
		/// </summary>
		/// <value>
		///     The title.
		/// </value>
		[DataMember(Name = "title")]
		public string Title { get; set; }

		[DataMember(Name = "release_year")]
		public string ReleaseYear { get; set; }

		/// <summary>
		///     Gets or sets the release month.
		/// </summary>
		/// <value>
		///     The release month.
		/// </value>
		[DataMember(Name = "release_month")]
		public string ReleaseMonth { get; set; }

		/// <summary>
		///     Gets or sets the release day.
		/// </summary>
		/// <value>
		///     The release day.
		/// </value>
		[DataMember(Name = "release_day")]
		public string ReleaseDay { get; set; }

		/// <summary>
		///     Gets or sets the original format.
		/// </summary>
		/// <value>
		///     The original format.
		/// </value>
		[DataMember(Name = "original_format")]
		public string OriginalFormat { get; set; }

		/// <summary>
		///     Gets or sets the license.
		/// </summary>
		/// <value>
		///     The license.
		/// </value>
		[DataMember(Name = "license")]
		public string License { get; set; }

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
		///     Gets or sets the artwork.
		/// </summary>
		/// <value>
		///     The artwork.
		/// </value>
		[DataMember(Name = "artwork_url")]
		public string Artwork { get; set; }

		/// <summary>
		///     Gets or sets the wave form.
		/// </summary>
		/// <value>
		///     The wave form.
		/// </value>
		[DataMember(Name = "waveform_url")]
		public string WaveForm { get; set; }

		/// <summary>
		///     Gets or sets the user.
		/// </summary>
		/// <value>
		///     The user.
		/// </value>
		[DataMember(Name = "user")]
		public UserObject User { get; set; }

		/// <summary>
		///     Gets or sets the stream URL.
		/// </summary>
		/// <value>
		///     The stream URL.
		/// </value>
		[DataMember(Name = "stream_url")]
		public string StreamUrl { get; set; }

		/// <summary>
		///     Gets or sets the download URL.
		/// </summary>
		/// <value>
		///     The download URL.
		/// </value>
		[DataMember(Name = "download_url")]
		public string DownloadUrl { get; set; }


		/// <summary>
		///     Gets or sets the secret token.
		/// </summary>
		/// <value>
		///     The secret token.
		/// </value>
		[DataMember(Name = "secret_token")]
		public string SecretToken { get; set; }

		/// <summary>
		///     Gets or sets the secret URI.
		/// </summary>
		/// <value>
		///     The secret URI.
		/// </value>
		[DataMember(Name = "secret_uri")]
		public string SecretUri { get; set; }

		/// <summary>
		///     Gets or sets a value indicating whether [user favorite].
		/// </summary>
		/// <value>
		///     <c>true</c> if [user favorite]; otherwise, <c>false</c>.
		/// </value>
		[DataMember(Name = "user_favorite")]
		public bool UserFavorite { get; set; }


		/// <summary>
		///     Gets or sets the attachment URI.
		/// </summary>
		/// <value>
		///     The attachment URI.
		/// </value>
		[DataMember(Name = "attachments_uri")]
		public string AttachmentUri { get; set; }

		/// <summary>
		///     Gets the artist.
		/// </summary>
		/// <value>
		///     The artist.
		/// </value>
		[IgnoreDataMember]
		public string Artist => User.UserName;
	}
}
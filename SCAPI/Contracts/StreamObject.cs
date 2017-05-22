using System;
using System.Globalization;
using System.Runtime.Serialization;

namespace SCAPI.Contracts
{
	/// <summary>
	///     A UserStream object
	/// </summary>
	[DataContract]
	public class UserStream
	{
		/// <summary>
		///     Gets or sets the future href.
		/// </summary>
		/// <value>
		///     The future href.
		/// </value>
		[DataMember(Name = "future_href")]
		public string FutureHref { get; set; }

		/// <summary>
		///     Gets or sets the stream tracks.
		/// </summary>
		/// <value>
		///     The stream tracks.
		/// </value>
		[DataMember(Name = "collection")]
		public StreamTracks[] StreamTracks { get; set; }
	}

	/// <summary>
	///     A List of stream Tracks
	/// </summary>
	[DataContract]
	public class StreamTracks
	{
		/// <summary>
		///     Gets or sets the stream track.
		/// </summary>
		/// <value>
		///     The stream track.
		/// </value>
		[DataMember(Name = "origin")]
		public StreamTrack StreamTrack { get; set; }
	}

	/// <summary>
	///     A stream track container
	/// </summary>
	[DataContract]
	public class StreamTrack
	{
		/// <summary>
		///     The creation date
		/// </summary>
		[DataMember(Name = "created_at")] private string creationDate;

		/// <summary>
		///     Gets or sets the identifier.
		/// </summary>
		/// <value>
		///     The identifier.
		/// </value>
		[DataMember(Name = "id")]
		public int Id { get; set; }

		/// <summary>
		///     Gets or sets the creation date.
		/// </summary>
		/// <value>
		///     The creation date.
		/// </value>
		public DateTime CreationDate
		{
			get { return (DateTime.Parse(creationDate)); }
			set { creationDate = value.ToString(CultureInfo.InvariantCulture); }
		}

		/// <summary>
		///     Gets or sets the kind.
		/// </summary>
		/// <value>
		///     The kind.
		/// </value>
		[DataMember(Name = "kind")]
		public string Kind { get; set; }

		/// <summary>
		///     Gets or sets the user identifier.
		/// </summary>
		/// <value>
		///     The user identifier.
		/// </value>
		[DataMember(Name = "user_id")]
		public int UserId { get; set; }

		/// <summary>
		///     Gets or sets the duration.
		/// </summary>
		/// <value>
		///     The duration.
		/// </value>
		[DataMember(Name = "duration")]
		public int Duration { get; set; }

		/// <summary>
		///     Gets or sets the state.
		/// </summary>
		/// <value>
		///     The state.
		/// </value>
		[DataMember(Name = "state")]
		public string State { get; set; }

		/// <summary>
		///     Gets or sets the sharing.
		/// </summary>
		/// <value>
		///     The sharing.
		/// </value>
		[DataMember(Name = "sharing")]
		public string Sharing { get; set; }

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

		/// <summary>
		///     Gets or sets the release year.
		/// </summary>
		/// <value>
		///     The release year.
		/// </value>
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
		///     Gets or sets the playback count.
		/// </summary>
		/// <value>
		///     The playback count.
		/// </value>
		[DataMember(Name = "playback_count")]
		public int PlaybackCount { get; set; }

		/// <summary>
		///     Gets or sets the download count.
		/// </summary>
		/// <value>
		///     The download count.
		/// </value>
		[DataMember(Name = "download_count")]
		public int DownloadCount { get; set; }

		/// <summary>
		///     Gets or sets the favoritings count.
		/// </summary>
		/// <value>
		///     The favoritings count.
		/// </value>
		[DataMember(Name = "favoritings_count")]
		public int FavoritingsCount { get; set; }

		/// <summary>
		///     Gets or sets the comments count.
		/// </summary>
		/// <value>
		///     The comments count.
		/// </value>
		[DataMember(Name = "comment_count")]
		public int CommentsCount { get; set; }
	}
}
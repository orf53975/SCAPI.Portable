using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using SCAPI.Core;

namespace SCAPI.Contracts
{
	/// <summary>
	///     A <see cref="Playlist" /> container object
	/// </summary>
	[DataContract]
	public class PlaylistObject
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
		///     Gets or sets the sharing.
		/// </summary>
		/// <value>
		///     The sharing.
		/// </value>
		[DataMember(Name = "sharing")]
		public string Sharing { get; set; }

		/// <summary>
		///     Gets or sets the tags list.
		/// </summary>
		/// <value>
		///     The tags list.
		/// </value>
		[DataMember(Name = "tag_list")]
		public string TagsList { get; set; }

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
		public int? LabelId { get; set; }

		/// <summary>
		///     Gets or sets the name of the label.
		/// </summary>
		/// <value>
		///     The name of the label.
		/// </value>
		[DataMember(Name = "label_name")]
		public string LabelName { get; set; }

		/// <summary>
		///     Gets or sets the type.
		/// </summary>
		/// <value>
		///     The type.
		/// </value>
		[DataMember(Name = "type")]
		public string Type { get; set; }

		/// <summary>
		///     Gets or sets the type of the playlist.
		/// </summary>
		/// <value>
		///     The type of the playlist.
		/// </value>
		[DataMember(Name = "playlist_type")]
		public string PlaylistType { get; set; }

		/// <summary>
		///     Gets or sets the ean.
		/// </summary>
		/// <value>
		///     The ean.
		/// </value>
		[DataMember(Name = "ean")]
		public string Ean { get; set; }

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
		public int? ReleaseYear { get; set; }

		/// <summary>
		///     Gets or sets the release month.
		/// </summary>
		/// <value>
		///     The release month.
		/// </value>
		[DataMember(Name = "release_month")]
		public int? ReleaseMonth { get; set; }

		/// <summary>
		///     Gets or sets the release day.
		/// </summary>
		/// <value>
		///     The release day.
		/// </value>
		[DataMember(Name = "release_day")]
		public int? ReleaseDay { get; set; }

		/// <summary>
		///     Gets the realease date.
		/// </summary>
		/// <value>
		///     The realease date.
		/// </value>
		public DateTime RealeaseDate
		{
			get
			{
				if (ReleaseDay != null && ReleaseMonth != null && ReleaseYear != null)
					return new DateTime((int) ReleaseYear, (int) ReleaseMonth, (int) ReleaseDay);

				return DateTime.MinValue;
			}
		}

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
		///     Gets or sets the artwork URL.
		/// </summary>
		/// <value>
		///     The artwork URL.
		/// </value>
		[DataMember(Name = "artwork_url")]
		public string ArtworkUrl { get; set; }

		/// <summary>
		///     Gets or sets the user.
		/// </summary>
		/// <value>
		///     The user.
		/// </value>
		[DataMember(Name = "user")]
		public UserObject User { get; set; }

		/// <summary>
		///     Gets or sets the tracks.
		/// </summary>
		/// <value>
		///     The tracks.
		/// </value>
		[DataMember(Name = "tracks")]
		public List<TrackObject> Tracks { get; set; }

		/// <summary>
		///     Gets the total tracks.
		/// </summary>
		/// <value>
		///     The total tracks.
		/// </value>
		[XmlIgnore]
		public int TotalTracks
		{
			get { return Tracks.Count; }
		}
	}
}
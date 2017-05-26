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
	
}
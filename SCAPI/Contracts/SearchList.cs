using System.Collections.Generic;
using System.Runtime.Serialization;

namespace SCAPI.Contracts
{
	/// <summary>
	///     A SoundCloud Track object
	/// </summary>
	[DataContract]
	public class SearchList
	{
		/// <summary>
		///     Gets or sets the identifier.
		/// </summary>
		/// <value>
		///     The identifier.
		/// </value>
		[DataMember(Name = "collection")]
		public List<SearchObject> Collection { get; set; }
	}
}
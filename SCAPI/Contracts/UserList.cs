using System.Collections.Generic;
using System.Runtime.Serialization;

namespace SCAPI.Contracts
{
	/// <summary>
	///     A SoundCloud Track object
	/// </summary>
	[DataContract]
	public class UserList
	{
		/// <summary>
		///     Gets or sets the identifier.
		/// </summary>
		/// <value>
		///     The identifier.
		/// </value>
		[DataMember(Name = "collection")]
		public List<UserObject> Collection { get; set; }
	}
}
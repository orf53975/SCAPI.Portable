using System.Runtime.Serialization;

namespace SCAPI.Contracts
{
	/// <summary>
	///     A <see cref="GenericObject" /> container object
	/// </summary>
	[DataContract]
	public class GenericObject
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
		///     Gets or sets the creation date.
		/// </summary>
		/// <value>
		///     The creation date.
		/// </value>
		[DataMember(Name = "kind")]
		public string kind { get; set; }

		
	}
}
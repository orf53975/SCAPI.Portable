using System.Runtime.Serialization;

namespace SCAPI.Contracts
{
	/// <summary>
	///     SoundCloud Access Token used to store the token used to authenticate
	/// </summary>
	[DataContract]
	public class SoundCloudAccessToken
	{
		/// <summary>
		///     Gets or sets the access token.
		/// </summary>
		/// <value>
		///     The access token.
		/// </value>
		[DataMember(Name = "access_token")]
		public string AccessToken { get; set; }

		/// <summary>
		///     Gets or sets the expires in.
		/// </summary>
		/// <value>
		///     The expires in.
		/// </value>
		[DataMember(Name = "expires_in")]
		public int ExpiresIn { get; set; }

		/// <summary>
		///     Gets or sets the scope.
		/// </summary>
		/// <value>
		///     The scope.
		/// </value>
		[DataMember(Name = "scope")]
		public string Scope { get; set; }

		/// <summary>
		///     Gets or sets the refresh token.
		/// </summary>
		/// <value>
		///     The refresh token.
		/// </value>
		[DataMember(Name = "refresh_token")]
		public string RefreshToken { get; set; }
	}
}
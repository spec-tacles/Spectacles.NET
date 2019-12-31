namespace Spectacles.NET.Types
{
	/// <summary>
	///     Features of a Guild
	/// </summary>
	public enum GuildFeature
	{
		/// <summary>
		///     guild has access to set an invite splash background
		/// </summary>
		INVITE_SPLASH,

		/// <summary>
		///     guild has access to set 320kbps bitrate in voice (previously VIP voice servers)
		/// </summary>
		VIP_REGIONS,

		/// <summary>
		///     guild has access to set a vanity URL
		/// </summary>
		VANITY_URL,

		/// <summary>
		///     guild is verified
		/// </summary>
		VERIFIED,

		/// <summary>
		///     guild is partnered
		/// </summary>
		PARTNERED,

		/// <summary>
		///     guild is public
		/// </summary>
		PUBLIC,

		/// <summary>
		///     guild has access to use commerce features (i.e. create store channels)
		/// </summary>
		COMMERCE,

		/// <summary>
		///     guild has access to create news channels
		/// </summary>
		NEWS,

		/// <summary>
		///     guild is able to be discovered in the directory
		/// </summary>
		DISCOVERABLE,

		/// <summary>
		///     guild is able to be featured in the directory
		/// </summary>
		FEATURABLE,

		/// <summary>
		///     guild has access to set an animated guild icon
		/// </summary>
		ANIMATED_ICON,

		/// <summary>
		///     guild has access to set a guild banner image
		/// </summary>
		BANNER
	}
}

// ReSharper disable ClassNeverInstantiated.Global
// ReSharper disable UnusedMember.Global

using Newtonsoft.Json;

namespace Spectacles.NET.Types
{
	/// <summary>
	/// Represents an activity which is part of a user's presence.
	/// </summary>
	public class Activity
	{
		/// <summary>
		///     the activity's name
		/// </summary>
		[JsonProperty("name")]
		public string Name { get; set; }

		/// <summary>
		///     <see cref="ActivityType" />
		/// </summary>
		[JsonProperty("type")]
		public ActivityType Type { get; set; }

		/// <summary>
		///     stream url, is validated when type is 1
		/// </summary>
		[JsonProperty("url")]
		public string URL { get; set; }

		/// <summary>
		///     unix timestamps for start and/or end of the game
		/// </summary>
		[JsonProperty("timestamps")]
		public ActivityTimestamps Timestamps { get; set; }

		/// <summary>
		///     application id for the game
		/// </summary>
		[JsonProperty("application_id")]
		public string ApplicationId { get; set; }

		/// <summary>
		///     what the player is currently doing
		/// </summary>
		[JsonProperty("details")]
		public string Details { get; set; }

		/// <summary>
		///     the user's current party status
		/// </summary>
		[JsonProperty("state")]
		public string State { get; set; }
		
		/// <summary>
		/// 	the emoji used for a custom status
		/// </summary>
		[JsonProperty("emoji")]
		public Emoji Emoji { get; set; }

		/// <summary>
		///     information for the current party of the player
		/// </summary>
		[JsonProperty("party")]
		public ActivityParty Party { get; set; }

		/// <summary>
		///     images for the presence and their hover texts
		/// </summary>
		[JsonProperty("assets")]
		public ActivityAssets Assets { get; set; }

		/// <summary>
		///     secrets for Rich Presence joining and spectating
		/// </summary>
		[JsonProperty("secrets")]
		public ActivitySecrets Secrets { get; set; }

		/// <summary>
		///     whether or not the activity is an instanced game session
		/// </summary>
		[JsonProperty("instance")]
		public bool? Instance { get; set; }

		/// <summary>
		///     activity flags ORd together, describes what the payload includes
		/// </summary>
		[JsonProperty("flags")]
		public ActivityFlags Flags { get; set; }
	}
}

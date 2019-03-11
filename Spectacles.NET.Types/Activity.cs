// ReSharper disable ClassNeverInstantiated.Global
// ReSharper disable UnusedMember.Global

using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Spectacles.NET.Types
{
	[Flags]
	public enum ActivityFlags {
		INSTANCE = 1 << 0,
		JOIN = 1 << 1,
		SPECTATE = 1 << 2,
		JOIN_REQUEST = 1 << 3,
		SYNC = 1 << 4,
		PLAY = 1 << 5
	}

	public enum ActivityType {
		PLAYING,
		STREAMING,
		LISTENING,
		WATCHING
	}
	
	public class Activity
	{
		/// <summary>
		/// the activity's name
		/// </summary>
		[JsonProperty("name")]
		public string Name { get; set; }
		
		/// <summary>
		/// <see cref="ActivityType"/>
		/// </summary>
		[JsonProperty("type")]
		public ActivityType Type { get; set; }
		
		/// <summary>
		/// stream url, is validated when type is 1
		/// </summary>
		[JsonProperty("url", NullValueHandling = NullValueHandling.Ignore)]
		public string URL { get; set; }
		
		/// <summary>
		/// unix timestamps for start and/or end of the game
		/// </summary>
		[JsonProperty("timestamps", NullValueHandling = NullValueHandling.Ignore)]
		public ActivityTimestamps Timestamps { get; set; }
		
		/// <summary>
		/// application id for the game
		/// </summary>
		[JsonProperty("application_id", NullValueHandling = NullValueHandling.Ignore)]
		public string ApplicationID { get; set; }
		
		/// <summary>
		/// what the player is currently doing
		/// </summary>
		[JsonProperty("details", NullValueHandling = NullValueHandling.Ignore)]
		public string Details { get; set; }
		
		/// <summary>
		/// the user's current party status
		/// </summary>
		[JsonProperty("state", NullValueHandling = NullValueHandling.Ignore)]
		public string State { get; set; }
		
		/// <summary>
		/// information for the current party of the player
		/// </summary>
		[JsonProperty("party", NullValueHandling = NullValueHandling.Ignore)]
		public ActivityParty Party { get; set; }
		
		/// <summary>
		/// images for the presence and their hover texts
		/// </summary>
		[JsonProperty("assets", NullValueHandling = NullValueHandling.Ignore)]
		public ActivityAssets Assets { get; set; }
		
		/// <summary>
		/// secrets for Rich Presence joining and spectating
		/// </summary>
		[JsonProperty("secrets", NullValueHandling = NullValueHandling.Ignore)]
		public ActivitySecrets Secrets { get; set; }
		
		/// <summary>
		/// whether or not the activity is an instanced game session
		/// </summary>
		[JsonProperty("instance", NullValueHandling = NullValueHandling.Ignore)]
		public bool? Instance { get; set; }
		
		/// <summary>
		/// activity flags ORd together, describes what the payload includes
		/// </summary>
		[JsonProperty("flags", NullValueHandling = NullValueHandling.Ignore)]
		public ActivityFlags Flags { get; set; }
	}

	public class ActivityTimestamps
	{
		/// <summary>
		/// unix time (in milliseconds) of when the activity started
		/// </summary>
		[JsonProperty("start", NullValueHandling = NullValueHandling.Ignore)]
		public long? Start { get; set; }
		
		/// <summary>
		/// unix time (in milliseconds) of when the activity ends
		/// </summary>
		[JsonProperty("end", NullValueHandling = NullValueHandling.Ignore)]
		public long? End { get; set; }
	}

	public class ActivityParty
	{
		/// <summary>
		/// the id of the party
		/// </summary>
		[JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
		public string ID { get; set; }
		
		/// <summary>
		/// used to show the party's current and maximum size
		/// </summary>
		[JsonProperty("size", NullValueHandling = NullValueHandling.Ignore)]
		public List<int> Size { get; set; }
	}

	public class ActivityAssets
	{
		/// <summary>
		/// the id for a large asset of the activity, usually a snowflake
		/// </summary>
		[JsonProperty("large_image", NullValueHandling = NullValueHandling.Ignore)]
		public string LargeImage { get; set; }
		
		/// <summary>
		/// text displayed when hovering over the large image of the activity
		/// </summary>
		[JsonProperty("large_text", NullValueHandling = NullValueHandling.Ignore)]
		public string LargeText { get; set; }
		
		/// <summary>
		/// the id for a small asset of the activity, usually a snowflake
		/// </summary>
		[JsonProperty("small_image", NullValueHandling = NullValueHandling.Ignore)]
		public string SmallImage { get; set; }
		
		/// <summary>
		/// text displayed when hovering over the small image of the activity
		/// </summary>
		[JsonProperty("small_text", NullValueHandling = NullValueHandling.Ignore)]
		public string SmallText { get; set; }
	}

	public class ActivitySecrets
	{
		/// <summary>
		/// the secret for joining a party
		/// </summary>
		[JsonProperty("join", NullValueHandling = NullValueHandling.Ignore)]
		public string Join { get; set; }
		
		/// <summary>
		/// the secret for spectating a game
		/// </summary>
		[JsonProperty("spectate", NullValueHandling = NullValueHandling.Ignore)]
		public string Spectate { get; set; }
		
		/// <summary>
		/// the secret for a specific instanced match
		/// </summary>
		[JsonProperty("match", NullValueHandling = NullValueHandling.Ignore)]
		public string Match { get; set; }
	}
}
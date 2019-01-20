// ReSharper disable ClassNeverInstantiated.Global
// ReSharper disable UnusedMember.Global

using Newtonsoft.Json;

namespace Spectacles.NET.Types
{
	public enum ActivityFlags {
		INSTANCE = 1 << 0,
		JOIN = 1 << 1,
		SPECTATE = 1 << 2,
		JOIN_REQUEST = 1 << 3,
		SYNC = 1 << 4,
		PLAY = 1 << 5
	}

	public enum ActivityType {
		GAME,
		STREAMING,
		LISTENING
	}
	
	public class Activity
	{
		[JsonProperty("name")]
		public string Name { get; set; }
		
		[JsonProperty("type")]
		public ActivityType Type { get; set; }
		
		[JsonProperty("url")]
		public string URL { get; set; }
		
		[JsonProperty("timestamps")]
		public ActivityTimestamps Timestamps { get; set; }
		
		[JsonProperty("application_id")]
		public string ApplicationID { get; set; }
		
		[JsonProperty("details")]
		public string Details { get; set; }
		
		[JsonProperty("state")]
		public string State { get; set; }
		
		[JsonProperty("party")]
		public ActivityParty Party { get; set; }
		
		[JsonProperty("assets")]
		public ActivityAssets Assets { get; set; }
		
		[JsonProperty("secrets")]
		public ActivitySecrets Secrets { get; set; }
		
		[JsonProperty("flags")]
		public ActivityFlags Flags { get; set; }
	}

	public class ActivityTimestamps
	{
		[JsonProperty("start")]
		public int? Start { get; set; }
		
		[JsonProperty("end")]
		public int? End { get; set; }
	}

	public class ActivityParty
	{
		[JsonProperty("id")]
		public string ID { get; set; }
		
		[JsonProperty("size")]
		public int[] Size { get; set; }
	}

	public class ActivityAssets
	{
		[JsonProperty("large_image")]
		public string LargeImage { get; set; }
		
		[JsonProperty("large_text")]
		public string LargeText { get; set; }
		
		[JsonProperty("small_image")]
		public string SmallImage { get; set; }
		
		[JsonProperty("small_text")]
		public string SmallText { get; set; }
	}

	public class ActivitySecrets
	{
		[JsonProperty("join")]
		public string Join { get; set; }
		
		[JsonProperty("spectate")]
		public string Spectate { get; set; }
		
		[JsonProperty("match")]
		public string Match { get; set; }
	}
}
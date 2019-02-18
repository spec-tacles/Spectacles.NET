using System;
using Newtonsoft.Json;

namespace Spectacles.NET.Rest.APIError
{
	public class DiscordAPIErrorResponse
	{
		[JsonProperty("code")]
		public int Code { get; set; }
		
		[JsonProperty("message")]
		public string Message { get; set; }
	}
	
	public class DiscordAPIException : Exception
	{
		public int StatusCode { get; }
		
		public DiscordAPIException(int statusCode, int errorCode, string errorMessage) : base($"{errorCode}: {errorMessage}")
		{
			StatusCode = statusCode;
		}
	}
}
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
		
		public int? ErrorCode { get; }
		
		public string ErrorMessages { get; }

		public DiscordAPIException(int statusCode, int? errorCode, string errorMessages) : base($"{(errorCode ?? statusCode)}: {errorMessages}")
		{
			StatusCode = statusCode;
			ErrorCode = errorCode;
			ErrorMessages = errorMessages;
		}
	}
}
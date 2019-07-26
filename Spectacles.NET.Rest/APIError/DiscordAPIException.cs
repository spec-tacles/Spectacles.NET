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
	
	/// <inheritdoc />
	/// <summary>
	/// Class representing a Discord API exception.
	/// </summary>
	public class DiscordAPIException : Exception
	{
		/// <summary>
		/// The StatusCode of the Exception.
		/// </summary>
		public int StatusCode { get; }
		
		/// <summary>
		/// Optional ErrorCode of the Exception.
		/// </summary>
		public int? ErrorCode { get; }
		
		/// <summary>
		/// Optional ErrorMessage of the Exception.
		/// </summary>
		public string ErrorMessages { get; }

		/// <inheritdoc />
		/// <summary>
		/// Creates a new Instance of DiscordAPIException
		/// </summary>
		/// <param name="statusCode">The StatusCode of the Exception.</param>
		/// <param name="errorCode">Optional ErrorCode of the Exception.</param>
		/// <param name="errorMessages">Optional ErrorMessage of the Exception.</param>
		public DiscordAPIException(int statusCode, int? errorCode, string errorMessages) : base($"{errorCode ?? statusCode}: {errorMessages}")
		{
			StatusCode = statusCode;
			ErrorCode = errorCode;
			ErrorMessages = errorMessages;
		}
	}
}
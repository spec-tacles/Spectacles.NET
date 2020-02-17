namespace Spectacles.NET.Gateway
{
	/// <summary>
	/// Reconnect Strategies to use when Connect
	/// </summary>
	public enum ReconnectStrategy
	{
		/// <summary>
		/// Increase timeout between connection attempts using Fibonacci 
		/// </summary>
		FIBONACCI,
		
		/// <summary>
		/// Increase timeout between connection attempts exponential
		/// </summary>
		EXPONENTIAL,
		
		/// <summary>
		/// Uses the same timeout between connection attempts
		/// </summary>
		PERIODICALLY
	}
}

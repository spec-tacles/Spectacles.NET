namespace Spectacles.NET.Types
{
	/// <summary>
	/// Type of Activity sent in a Message.
	/// </summary>
	public enum MessageActivityType
	{
		/// <summary>
		/// Join Type
		/// </summary>
		JOIN = 1,
		
		/// <summary>
		/// Spectate Type
		/// </summary>
		SPECTATE,
		
		/// <summary>
		/// Listen Type
		/// </summary>
		LISTEN,
		
		/// <summary>
		/// Join Request Type
		/// </summary>
		JOIN_REQUEST = 5
	}
}

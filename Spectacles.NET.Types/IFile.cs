namespace Spectacles.NET.Types
{
	/// <summary>
	/// Interface for Files attached to Messages
	/// </summary>
	public interface IFile
	{
		/// <summary>
		/// The name of the File
		/// </summary>
		string Name { get; }

		/// <summary>
		/// The value of the file
		/// </summary>
		byte[] Value { get; }
	}
}

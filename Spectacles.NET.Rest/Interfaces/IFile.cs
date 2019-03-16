namespace Spectacles.NET.Rest.Interfaces
{
	public interface IFile
	{
		string Name { get; }
		
		byte[] Value { get; }
	}
}
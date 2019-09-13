namespace Spectacles.NET.Rest.Util
{
	public interface IFile
	{
		string Name { get; }

		byte[] Value { get; }
	}
}

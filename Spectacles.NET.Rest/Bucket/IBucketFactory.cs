namespace Spectacles.NET.Rest.Bucket
{
	/// <summary>
	/// Factory which creates IBucket instances.
	/// </summary>
	public interface IBucketFactory
	{
		/// <summary>
		/// Creates a new instance of IBucket
		/// </summary>
		/// <param name="client"></param>
		/// <returns>IBucket</returns>
		IBucket CreateBucket(RestClient client);
	}
}
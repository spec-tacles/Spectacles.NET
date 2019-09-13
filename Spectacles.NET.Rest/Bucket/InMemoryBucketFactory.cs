namespace Spectacles.NET.Rest.Bucket
{
	/// <inheritdoc />
	public class InMemoryBucketFactory : IBucketFactory
	{
		/// <inheritdoc />
		public IBucket CreateBucket(RestClient client, string route)
			=> new InMemoryBucket(client);
	}
}

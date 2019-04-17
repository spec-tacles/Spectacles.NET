namespace Spectacles.NET.Rest.Bucket
{
	/// <inheritdoc />
	public class BucketFactory : IBucketFactory
	{
		/// <inheritdoc />
		public IBucket CreateBucket(RestClient client, string route)
			=> new Bucket(client);
	}
}
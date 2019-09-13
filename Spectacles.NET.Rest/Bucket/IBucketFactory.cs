namespace Spectacles.NET.Rest.Bucket
{
	/// <summary>
	///     Factory which creates IBucket instances.
	/// </summary>
	public interface IBucketFactory
	{
		/// <summary>
		///     Creates a new instance of IBucket
		/// </summary>
		/// <param name="client">The Client who creates the Buckets</param>
		/// <param name="route">The route of the Bucket</param>
		/// <returns>
		///     <see cref="IBucket" />
		/// </returns>
		IBucket CreateBucket(RestClient client, string route);
	}
}

using System;
using Spectacles.NET.Rest.Redis;

namespace Spectacles.NET.Rest.Bucket
{
	/// <inheritdoc />
	public class RedisBucketFactory : IBucketFactory
	{
		/// <summary>
		/// </summary>
		/// <param name="redisPool">The ConnectionPool to use</param>
		/// <exception cref="ArgumentException">If the ConnectionPool isn't connecteds</exception>
		public RedisBucketFactory(ConnectionPool redisPool)
		{
			if (!redisPool.Connected)
				throw new ArgumentException(
					"ConnectionPool#ConnectAsync needs to be invoked before passing ConnectionPool to RedisBucketFactory constructor");
			RedisPool = redisPool;
		}

		private ConnectionPool RedisPool { get; }

		/// <inheritdoc />
		public IBucket CreateBucket(RestClient client, string route)
			=> new RedisBucket(client, route, RedisPool);
	}
}

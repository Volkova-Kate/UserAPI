using System;

using Microsoft.Extensions.Options;

using MongoDB.Driver;
using MongoDBExt;

namespace UserAPI.MongoDB
{
	public abstract class MongoDBContext
	{
		public readonly IMongoClient _client;
		public readonly IMongoDatabase _db;

		public MongoDBContext(IOptions<MongoDBSettings> settings, Action initConventions = null)
		{
			initConventions?.Invoke();
			_client = new MongoClient(settings.Value.ConnectionString);
			if (_client != null)
			{
				_db = _client.GetDatabase(settings.Value.Database);
			}
		}
	}
}

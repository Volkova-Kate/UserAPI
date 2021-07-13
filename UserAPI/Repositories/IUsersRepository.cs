using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;
using UserAPI.Models;
using MongoDBExt;

namespace UserAPI.Repositories
{
	public interface IUsersRepository : IRepository<User>
	{
		Task<IEnumerable<User>> Get(int? take, int skip = 0, FilterDefinition<User> filter = null,
			SortDefinition<User> sort = null);
	}
}

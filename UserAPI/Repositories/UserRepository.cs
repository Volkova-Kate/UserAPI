using System;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
using UserAPI.Models;
using MongoDBExt;
using System.Threading.Tasks;

namespace UserAPI.Repositories
{
    public class UserRepository : MongoDBRepository<User>, IUsersRepository
    {
        public UserRepository (UserContext userContext)
        {
            collection = userContext.UserCollection;
        }

        public async Task<IEnumerable<User>> Get(int? take, int skip = 0, FilterDefinition<User> filter = null,
           SortDefinition<User> sort = null)
        {
            if (take <= 0)
            {
                throw new ArgumentException($"{nameof(take)} arg can't be less or equal 0.", nameof(take));
            }

            if (skip < 0)
            {
                throw new ArgumentException($"{nameof(skip)} arg can't be less 0.", nameof(take));
            }

            filter ??= FilterDefinition<User>.Empty;

            IFindFluent<User, User> clicks = collection.Find(filter)
                .Skip(skip);

            if (take.HasValue)
            {
                clicks = clicks.Limit(take);
            }

            return await clicks.ToListAsync();
        }

        public List<User> Get() =>
            collection.Find(user => true).ToList();

        public User Get(string id) =>
            collection.Find<User>(user => user.Id == id).FirstOrDefault();

        public List<User> GetPage(int skip, int count) =>
            collection.Find(user => true).Skip(skip).Limit(count).ToList();

        public User Create(User user)
        {
            collection.InsertOne(user);
            return user;
        }

        public void Update(string id, User userIn) =>
            collection.ReplaceOne(user => user.Id == id, userIn);

        public void Remove(User userIn) =>
            collection.DeleteOne(user => user.Id == userIn.Id);

        public void Remove(string id) =>
            collection.DeleteOne(user => user.Id == id);
    }
}

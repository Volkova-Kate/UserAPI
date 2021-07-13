using System;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
using UserAPI.Models;

namespace UserAPI.Repositories
{
    public class UserRepository
    {
        public UserRepository (UserContext userContext)
        {
            _users = userContext.UserCollection;
        }
        private readonly IMongoCollection<User> _users;

        public List<User> Get() =>
            _users.Find(user => true).ToList();

        public User Get(string id) =>
            _users.Find<User>(user => user.Id == id).FirstOrDefault();

        public List<User> GetPage(int skip, int count) =>
            _users.Find(user => true).Skip(skip).Limit(count).ToList();

        public User Create(User user)
        {
            _users.InsertOne(user);
            return user;
        }

        public void Update(string id, User userIn) =>
            _users.ReplaceOne(user => user.Id == id, userIn);

        public void Remove(User userIn) =>
            _users.DeleteOne(user => user.Id == userIn.Id);

        public void Remove(string id) =>
            _users.DeleteOne(user => user.Id == id);
    }
}

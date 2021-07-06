using System;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
using UserAPI.Models;


namespace UserAPI.Services
{
    public class UserService
    {
        private readonly IMongoCollection<User> _users;

        public UserService(IUserstoreDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            //считывает экземпляр сервера для выполнения операций с базой данных
            var database = client.GetDatabase(settings.DatabaseName);
            //представляет базу данных Mongo для выполнения операций

            _users = database.GetCollection<User>(settings.UsersCollectionName);

            //var ls = Get();
        }

        public List<User> Get() =>
            _users.Find(user => true).ToList();

        public User Get(string id) =>
            _users.Find<User>(user => user.Id == id).FirstOrDefault();

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

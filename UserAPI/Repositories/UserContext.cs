using System;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
using UserAPI.Models;
using UserAPI.Infrastructure.Settings;

namespace UserAPI.Repositories
{
    public class UserContext
    {
        private readonly IMongoCollection<User> _users;
        public IMongoCollection<User> UserCollection => _users;

        private readonly IMongoClient _client;
        private readonly IMongoDatabase _database;
        public UserContext(IUserStoreDatabaseSettings settings)
        {
            _client = new MongoClient(settings.ConnectionString);
            //считывает экземпляр сервера для выполнения операций с базой данных
            _database = _client.GetDatabase(settings.DatabaseName);
            //представляет базу данных Mongo для выполнения операций

            _users = _database.GetCollection<User>(settings.UsersCollectionName);
        }
    }
}

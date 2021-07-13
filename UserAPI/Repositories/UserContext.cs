﻿using System;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
using UserAPI.Models;
using UserAPI.Infrastructure.Settings;
using MongoDBExt;
using Microsoft.Extensions.Options;

namespace UserAPI.Repositories
{
    public class UserContext : MongoDBContext
    {
		public UserContext(IOptions<MongoDBSettings> settings) : base(settings)
		{
		}

		public IMongoCollection<User> UserCollection => _db.GetCollection<User>("Users");
	}
}
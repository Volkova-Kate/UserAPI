using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDBExt;

namespace UserAPI.Models
{
    public class User : IEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        //[BsonElement("FirstName")]
        public string FirstName { get; set; }
        //[BsonElement("LastName")]
        public string LastName { get; set; }
        //[BsonElement("Number")]
        public string Number { get; set; }
    }
}
 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using FluentValidation;

namespace UserAPI.Models
{
    public class User
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

    public class UserValidation :AbstractValidator<User>
    {
        public UserValidation()
        {
            RuleFor(x => x.FirstName).NotNull().Length(1, 10).WithMessage("Length include 1-10 symbols");
            RuleFor(x => x.LastName).NotNull().Length(1, 10).WithMessage("Length include 1-10 symbols");
            RuleFor(x => x.Number).NotNull().Length(11).WithMessage("Length include 11 symbols");
        }
    }
}
 

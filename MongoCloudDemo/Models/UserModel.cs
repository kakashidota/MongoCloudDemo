using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoCloudDemo.Models
{
    internal class UserModel
    {
        [BsonId]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public Adress Adress { get; set; }
    }
}

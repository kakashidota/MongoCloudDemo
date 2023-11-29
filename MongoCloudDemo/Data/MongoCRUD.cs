using MongoCloudDemo.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoCloudDemo.Data
{
    internal class MongoCRUD
    {
        private IMongoDatabase db;

        public MongoCRUD(string database)
        {
            var client = new MongoClient();
            db = client.GetDatabase(database);
        }

        public void AddUser(string table, UserModel user)
        {
            var collection = db.GetCollection<UserModel>(table);
            collection.InsertOne(user);
        }

        public List<UserModel> GetAllUsers(string table)
        {
            var collection = db.GetCollection<UserModel>(table);
            return collection.Find(_ => true).ToList();
        }

        public UserModel GetUserById(string table, Guid id)
        {
            var collection = db.GetCollection<UserModel>(table);
            return collection.AsQueryable().ToList().Find(x => x.Id == id);
        }

        public void UpdateUser(string table, UserModel user)
        {
            var collection = db.GetCollection<UserModel>(table);
            user.Name = "Potatis";
            collection.ReplaceOne(x => x.Id == user.Id, user, new ReplaceOptions { IsUpsert = true });
        }

        public void DeleteUser(string table, UserModel user)
        {
            var collection = db.GetCollection<UserModel>(table);
            collection.DeleteOne(x => x.Id == user.Id);
        }


        public void ClearDatabase(string table)
        {
            var collection = db.GetCollection<UserModel>(table);
            collection.DeleteMany(_ => true);
        }

    }
}

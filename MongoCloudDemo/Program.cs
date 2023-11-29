using MongoCloudDemo.Data;
using MongoCloudDemo.Models;

namespace MongoCloudDemo
{
    internal class Program
    {

        static MongoCRUD db = new MongoCRUD("UserDB");
        static List<UserModel> users = new List<UserModel>();


        static void Main(string[] args)
        {
            //AddUser();
            GetUsers();
            //GetUserById();
            //UpdateById();
            //DeleteUser();
            ClearDatabase();
            Console.ReadKey();
        }


        static void AddUser()
        {
            //Adds a user to the database
            UserModel user = new UserModel
            {
                Name = "Robin Kamo",
                Age = 32,
                Adress = new Adress
                {
                    Street = "Salviagatan 38",
                    City = "GBG",
                    State = "No state",
                    ZipCode = "41440"
                }
            };

            db.AddUser("Users", user);
            
        }

        static void GetUsers()
        {
            //Reads all users from database
            users = db.GetAllUsers("Users");
            foreach (var user in users)
            {
                Console.WriteLine($"{user.Name} found in the database");
            }

        }

        static void GetUserById()
        {
            //Returns a specific user
            var result = db.GetUserById("Users", users[1].Id);
            Console.WriteLine($"Found user by id: {result.Name}");
        }


        static void UpdateById()
        {
            //Updates a user
            db.UpdateUser("Users", users[1]);
        }

        static void DeleteUser()
        {
            //Deletes a user
            db.DeleteUser("Users", users[1]);
        }


        static void ClearDatabase()
        {
            db.ClearDatabase("Users");
        }
    }
}
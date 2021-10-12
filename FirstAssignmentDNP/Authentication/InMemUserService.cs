using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using Models;

namespace FirstAssignmentDNP.Authentication
{
    public class InMemUserService : IUserService
    {
        private List<User> users;
        private string usersFile = "users.json";

        public InMemUserService()
        {
            if (!File.Exists(usersFile))
            {
                users = users = new[]
                {
                    new User()
                    {
                        Username = "Ionut",
                        Id = 1,
                        Password = "12345",
                        FirstName = "Baicoianu",
                        LastName = "Ioan-Sorin",
                        SecurityLevel = 4,
                        Family = null,
                        Role = "Admin",
                    }
                }.ToList();
                string userAsJson = JsonSerializer.Serialize(users);
                File.WriteAllText(usersFile, userAsJson);
            }
            else
            {
                string content = File.ReadAllText(usersFile);
                users = JsonSerializer.Deserialize<List<User>>(content);
            }
        }

        public User ValidateUser(string username, string password)
        {
            User first = users.FirstOrDefault(user => user.Username.Equals(username));
            
            if (first == null) throw new Exception("User not found");
            if (!first.Password.Equals(password)) throw new Exception("Incorrect password");

            return first;
        }
    }
}
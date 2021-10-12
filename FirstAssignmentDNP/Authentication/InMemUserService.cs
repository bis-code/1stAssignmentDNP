using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using FirstAssignmentDNP.Data;
using Models;

namespace FirstAssignmentDNP.Authentication
{
    public class InMemUserService : IUserService
    {
        private List<User> users;
        private string usersFile = "users.json";
        private UsersJSONData UsersData = new UsersJSONData();

        public InMemUserService()
        {
            users = UsersData.GetUsers().ToList();
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
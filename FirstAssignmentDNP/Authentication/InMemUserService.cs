using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using FirstAssignmentDNP.Data;
using Models;

namespace FirstAssignmentDNP.Authentication
{
    public class InMemUserService : IUserService
    {
        private IList<User> users;
        private string usersFile = "users.json";
        private IUsersData _usersData;

        public InMemUserService(IUsersData usersData)
        {
            _usersData = usersData;
        }

        public async Task<User> ValidateUser(string username, string password)
        {
            users = await _usersData.GetUsersAsync();
            User first = users.FirstOrDefault(user => user.Username.Equals(username));
            
            if (first == null) throw new Exception("User not found");
            if (!first.Password.Equals(password)) throw new Exception("Incorrect password");

            return first;
        }
    }
}
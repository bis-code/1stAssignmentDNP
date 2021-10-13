using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using Models;

namespace FirstAssignmentDNP.Data
{
    public class UsersJSONData : IUsersData
    {
        private IList<User> users;
        private string usersFile = "users.json";

        public UsersJSONData()
        {
            if (!File.Exists(usersFile))
            {
                Seed();
                WriteUsersToFile();
            }
            else
            {
                string content = File.ReadAllText(usersFile);
                users = JsonSerializer.Deserialize<List<User>>(content);
            }
        }

        private void Seed()
        {
            users = new[]
            {
                new User()
                {
                    Username = "Ionut",
                    Id = 2,
                    Password = "12345",
                    SecurityLevel = 4,
                    Role = "Admin",
                },
                new User()
                {
                    Username = "Baicoianu",
                    Id = 3,
                    Password = "12345",
                    SecurityLevel = 2,
                    Role = "Member",
                }
            }.ToList();
        }

        public void AddUser(User user)
        {
            int max = users.Max(user => user.Id);
            user.Id = (++max);
            user.Family = null;
            user.Person = null;
            user.Role = "Member";
            user.Photo = "default.png";
            user.SecurityLevel = 0;
            users.Add(user);
            WriteUsersToFile();
        }

        public IList<User> GetUsers()
        {
            List<User> tmp = new List<User>(users);
            return tmp;
        }

        public void RemoveUser(int userID)
        {
            User toRemove = users.First(u => u.Id == userID);
            users.Remove(toRemove);
            WriteUsersToFile();
        }

        public void Update(User user)
        {
            //to be updated
            User toUpdate = users.First(u => u.Id == user.Id);
            toUpdate.Username = user.Username;
            toUpdate.Role = user.Role;
            toUpdate.SecurityLevel = user.SecurityLevel;
            toUpdate.Password = user.Password;
            toUpdate.Family = user.Family;
            toUpdate.Person = user.Person;
            WriteUsersToFile();
        }

        public User Get(int userID)
        {
            return users.FirstOrDefault(u => u.Id == userID);
        }

        public User Get(string username)
        {
            return users.FirstOrDefault(u => u.Username.Equals(username));
        }

        public void AddFamilyToUser(Family family, int userId)
        {
            User toUpdate = users.First(u => u.Id == userId);
            toUpdate.Family = family;
            WriteUsersToFile();
        }

        public void AddPersonToUser(Person person, int userId)
        {
            if (!CredentialsForColor(person.HairColor) || !CredentialsForColor(person.EyeColor))
                throw new Exception("Color required: Dark/Blue/Grey/Blond/Brown.");
            User toUpdate = users.First(u => u.Id == userId);
            person.Photo = toUpdate.Photo;
            toUpdate.Person = person;
            WriteUsersToFile();
        }

        private bool CredentialsForColor(string color)
        {
            if (color.Equals("Grey") || color.Equals("Blue") || color.Equals("Dark") ||
                color.Equals("Blond") || color.Equals("Brown"))
                return true;
            return false;
        }

        private void WriteUsersToFile()
        {
            string userAsJson = JsonSerializer.Serialize(users);
            File.WriteAllText(usersFile, userAsJson);
        }
    }
}
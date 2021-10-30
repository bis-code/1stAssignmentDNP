using System.Collections.Generic;
using Models;

namespace FirstAssignmentDNP.Data
{
    public interface IUsersData
    {
        IList<User> GetUsers();
        void AddUser(User user);
        void AddFamilyToUser(Family family, int userId);
        void AddPersonToUser(Person person, int userId);
        void RemoveFamilyFromUser(int userId, Family family);
        void RemoveUser(int userID);
        void Update(User user);
        User Get(int userID);

        User Get(string username);
    }
}
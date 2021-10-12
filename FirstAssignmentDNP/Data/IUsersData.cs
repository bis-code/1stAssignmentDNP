using System.Collections.Generic;
using Models;

namespace FirstAssignmentDNP.Data
{
    public interface IUsersData
    {
        IList<User> GetUsers();
        void AddUser(User user);
        void AddFamilyToUser(Family family, int userId);
        void RemoveUser(int userID);
        void Update(User user);
        User Get(int userID);
    }
}
using System.Collections.Generic;
using System.Threading.Tasks;
using Models;

namespace FirstAssignmentDNP.Data
{
    public interface IUsersData
    {
        Task<IList<User>> GetUsersAsync();
        Task AddUserAsync(User user);
        Task AddFamilyToUserAsync(Family family, int userId);
        Task AddPersonToUserAsync(Person person, int userId);
        Task<User> GetUserAsync(int userID);
        Task<User> GetUserAsync(string username);
    }
}
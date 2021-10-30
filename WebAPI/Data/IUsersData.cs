using System.Collections.Generic;
using System.Threading.Tasks;
using Models;

namespace FirstAssignmentDNP.Data
{
    public interface IUsersData
    {
        Task<IList<User>> GetUsersAsync();
        Task<User> AddUserAsync(User user);
        Task<Family> AddFamilyToUserAsync(Family family, int userId);
        Task<Person> AddPersonToUserAsync(Person person, int userId);
        Task<User> GetUserAsync(int userID);
        Task<User> GetUserAsync(string username);
        Task<User> UpdateAsync(User user);
        Task RemoveUserAsync(User user);
    }
}
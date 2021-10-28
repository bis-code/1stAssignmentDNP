using System.Threading.Tasks;
using Models;

namespace FirstAssignmentDNP.Authentication
{
    public interface IUserService
    {
        Task<User> ValidateUser(string username, string password);
    }
}
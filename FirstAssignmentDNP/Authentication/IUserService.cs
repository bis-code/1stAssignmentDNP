using Models;

namespace FirstAssignmentDNP.Authentication
{
    public interface IUserService
    {
        User ValidateUser(string username, string password);
    }
}
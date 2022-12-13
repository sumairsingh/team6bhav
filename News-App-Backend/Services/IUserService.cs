using News_App_Backend.Models;

namespace News_App_Backend.Services
{
    public interface IUserService
    {
        User RegisterUser(User user);
        User Login(string Email, string Password);
    }
}

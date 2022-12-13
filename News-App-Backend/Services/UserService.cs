using AuthServer.Exceptions;
using News_App_Backend.Models;

namespace News_App_Backend.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repo;

        public UserService(IUserRepository repo)
        {
            _repo = repo;
        }

        public User Login(string email, string password)
        {
            var user = _repo.Login(email, password);
            if (user != null)
            {
                return user;
            }
            else
            {
                throw new UserNotFoundException("Invalid user id or password");
            }
            //return null;
        }

        public User RegisterUser(User userDetails)
        {
            var user = _repo.FindUserByEmail(userDetails.Email);
            if (user == null)
            {
                return _repo.Register(userDetails);
            }
            else
            {
                throw new UserAlreadyExistsException($"This email {userDetails.Email} already exists");
            }
         
        }
    }
}

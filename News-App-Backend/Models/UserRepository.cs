using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using News_App_Backend.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace News_App_Backend.Models
{
    public class UserRepository : IUserRepository
    {
        private readonly UserDbContext _context;
     //   private readonly IWebHostEnvironment _webHostEnvironment;
        public UserRepository(UserDbContext context)
        {
            _context = context;
          //  _webHostEnvironment = webHostEnvironment;
        }

        public User Register(User user)
        {
         /*   string imgtext = Path.GetExtension(file.FileName);
            if(imgtext=="jpg" || imgtext=="gif")
            {
                var upload = Path.Combine(_webHostEnvironment.WebRootPath,"Images", file.FileName);
                using (FileStream stream = System.IO.File.Create(upload + file.FileName))
                {
                    file.CopyTo(stream);
                    user.ProfilePicture = upload;
                }
                    

            }*/

            _context.Users.Add(user);
            _context.SaveChanges();
            return user;
        }

        public User Login(string email, string password)
        {
            var _user = _context.Users.FirstOrDefault(u => u.Email == email && u.Password == password);
            return _user;
        }

        public User FindUserByEmail(string email)
        {
            var _user = _context.Users.FirstOrDefault(u => u.Email == email);
            return _user;
        }

    }
}

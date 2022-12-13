using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AuthServer.Exceptions;
using News_App_Backend.Models;
using News_App_Backend.Services;

namespace News_App_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _service;
        

        public AuthController(IUserService service)
        {
            _service = service;
           // _webHostEnvironment= webHostEnvironment;

    }

        [HttpPost]
        [Route("register")]
        public IActionResult Register([FromBody] User user)
        {
           // string imgtext = Path.GetExtension(file.FileName);
         /*   if(objFile.file.Length>0)
            {
                string path = _webHostEnvironment.WebRootPath + "\\upload\\";
                if (!Directory.Exists(path)) ;
                {
                    Directory.CreateDirectory(path);
                }
                using (FileStream stream = System.IO.File.Create(path + objFile.file.FileName))
                {
                    objFile.file.CopyTo(stream);
                  //  FileStream.Flush();
                   

                }

             //   var upload = Path.Combine("Images", file.FileName);
              //  var stream = FileStream(upload, FileMode.Create);
               // await file.CopyToAsync(stream);
            }*/
            try
            {
                _service.RegisterUser(user);
                return StatusCode(201, "You are successfully registered!");
            }
            catch (UserAlreadyExistsException ue)
            {
                return Conflict(ue.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, "There is some server error");
            }
        }

        [HttpPost]
        [Route("login")]
        public IActionResult Login([FromBody] User user)
        {
            try
            {
                string email = user.Email;
                string password = user.Password;

                User _user = _service.Login(email, password);

                //calling the function for the JWT token for respected user
                string value = this.GetJWTToken(email);
                //returning the token to the consumer app
                return Ok(value);
            }
            catch (UserNotFoundException unf)
            {
                return NotFound(unf.Message);
            }
            catch
            {
                return StatusCode(500, "Some server error");
            }
        }


        private string GetJWTToken(string email)
        {
            var claims = new[]
           {
                new Claim(JwtRegisteredClaimNames.UniqueName, email)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("authserver_secret_to_validate_token"));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: "AuthServer",
                audience: "jwtclient",
                claims: claims,
                expires: DateTime.UtcNow.AddHours(1),
                signingCredentials: creds
            );
            var response = new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token)
            };
            return JsonConvert.SerializeObject(response);
        }
    }
}

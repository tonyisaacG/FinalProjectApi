using FinalProjectBkEndApi.DTO;
using FinalProjectBkEndApi.Models;
using FinalProjectBkEndApi.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using FinalProjectBkEndApi.Helper;
using Microsoft.EntityFrameworkCore;

namespace FinalProjectBkEndApi.Services
{
    public class AuthServices : IAuthServices
    {
        private readonly RestaurantDbContext _DbContext;
        private readonly IConfiguration _config;
        public AuthServices(RestaurantDbContext DbContext, IConfiguration config)
        {
            _DbContext = DbContext;
            _config = config;
        }
        public string Login([FromBody] LoginModel model)
        {
            var hashPassword = HelperFunc.EncodePasswordToBase64(model.password);
            var userModel = _DbContext.Users.Where(user => user.username == model.username && user.password == hashPassword).Include(r=>r.Role).FirstOrDefault();
            if (userModel != null)
            {
                return GenerateJSONWebToken(userModel);
            }
            else
            {
                return null;
            }
        }

        public bool Register([FromBody] RegisterModel userModel)
        {
            var hashPassword = HelperFunc.EncodePasswordToBase64(userModel.password);

            var user = _DbContext.Users.Where(
                userM => userM.username == userModel.username &&
                userM.password == hashPassword &&
                userM.phone == userModel.phone).FirstOrDefault();
            if (user != null)
            {
                return false;
            }
            else
            {
                var newUser = userModel.RegisterDTOUser();
                var Roles = _DbContext.Roles.Where(r => r.permission == Permission.User.ToString()).FirstOrDefault();
                newUser.Role = Roles;
                _DbContext.Users.Add(newUser);
                _DbContext.SaveChanges();
                return true;
            }
        }

        private string GenerateJSONWebToken(User userModel)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Secret"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var authClaims = new List<Claim>()
            {
                
                new Claim("id", userModel.id.ToString()),
                new Claim("username", userModel.username),
                new Claim(ClaimTypes.Role, userModel.Role?.permission),

            };


            var token = new JwtSecurityToken(
                claims:authClaims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: credentials
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

       
    }
}

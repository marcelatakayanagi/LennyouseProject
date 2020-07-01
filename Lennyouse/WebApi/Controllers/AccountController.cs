using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Recodme.RD.Lennyouse.DataLayer.UserInfo;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Recodme.RD.Lennyouse.PresentationLayer.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController:ControllerBase
    {
        private readonly IConfiguration _config;

        public AccountController (IConfiguration config)
        {
            _config = config;
        }

        [HttpGet]
        public ActionResult<string> Login()
        {
            var mockUser = new LennyouseUser();
            mockUser.Email = "recodme@recodme.pt";
            mockUser.PasswordHash = "lkjlkj123";
            return GenerateJsonWebToken(mockUser);
        }

        private string GenerateJsonWebToken(LennyouseUser user)
        {
            var jwtKey = _config["Jwt:Key"];
            var keyBytes = Encoding.UTF8.GetBytes(jwtKey);
            var key = new SymmetricSecurityKey(keyBytes);

            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var issuer = _config["Jwt:Issuer"];
            var audience = _config["Jwt:Audience"];
            var claims = new List<Claim>()
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Email)
                
            };
            var token = new JwtSecurityToken(issuer, audience, claims, expires:DateTime.Now.AddMinutes(120), signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}

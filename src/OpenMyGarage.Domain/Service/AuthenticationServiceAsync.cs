using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using OpenMyGarage.Domain.ViewModel;
using OpenMyGarage.Entity.Entity.UserPrivileges;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace OpenMyGarage.Domain.Service
{
    public class AuthenticationServiceAsync : IAuthenticationServiceAsync
    {
        private UserManager<ApplicationUser> userManager;
        private IConfiguration configuration;

        public AuthenticationServiceAsync(UserManager<ApplicationUser> um, IConfiguration c)
        {
            this.userManager = um;
            this.configuration = c;
        }

        public async Task<ActionResult> RegisterUser(RegisterViewModel vm)
        {
            var user = new ApplicationUser
            {
                Email = vm.Email,
                UserName = vm.Email,
                SecurityStamp = Guid.NewGuid().ToString()
            };
            var result = await userManager.CreateAsync(user, vm.Password);
            if (result.Succeeded)
                result = await userManager.AddToRoleAsync(user, "User");

            return new OkObjectResult(new { Username = user.UserName });
        }

        public async Task<ActionResult> LoginUser(LoginViewModel vm)
        {
            var user = await userManager.FindByNameAsync(vm.Username);

            if (user is null)
                return new UnauthorizedResult();

            var roles = await userManager.GetRolesAsync(user);
            string role = GetHighestRole(roles);
            
            if (!await userManager.CheckPasswordAsync(user, vm.Password))
                return new UnauthorizedResult();

            var claim = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim("http://schemas.microsoft.com/ws/2008/06/identity/claims/role", role)
            };
            var signinKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:SigninKey"]));
            int expiryInMinutes = Convert.ToInt32(configuration["Jwt:ExpiryInMinutes"]);
            JwtSecurityToken token;
            switch (role)
            {
                case "RaspberryPi":
                    token = new JwtSecurityToken(
                                issuer: configuration["Jwt:Site"],
                                audience: configuration["Jwt:Site"],
                                claims: claim,
                                signingCredentials: new SigningCredentials(signinKey, SecurityAlgorithms.HmacSha256));
                    break;

                case "Admin":
                case "User":
                default:
                    token = new JwtSecurityToken(
                                issuer: configuration["Jwt:Site"],
                                audience: configuration["Jwt:Site"],
                                claims: claim,
                                expires: DateTime.Now.AddDays(1.0),
                                signingCredentials: new SigningCredentials(signinKey, SecurityAlgorithms.HmacSha256));
                    break;
            }

            return new OkObjectResult(new { token = new JwtSecurityTokenHandler().WriteToken(token), expiration = token.ValidTo });
        }

        private string GetHighestRole(IList<string> roles)
        {
            if (roles.Contains("RaspberryPi"))
                return "RaspberryPi";
            
            if (roles.Contains("Admin"))
                return "Admin";
            
            return "User";
        }
    }
}

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using OpenMyGarage.Domain.ViewModel;
using OpenMyGarage.Entity.Entity;
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
        private readonly UserManager<IdentityUser> userManager;
        private readonly IOptions<JwtSettings> jwtSettings;

        public AuthenticationServiceAsync(UserManager<IdentityUser> um, IOptions<JwtSettings> options)
        {
            this.userManager = um;
            this.jwtSettings = options;
        }

        public async Task<ActionResult> RegisterUser(RegisterViewModel vm)
        {
            var user = new IdentityUser
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

            List<Claim> claims = await BuildClaims(user, role);
            var signinKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Value.SigningKey));
            int expiryInDays = Convert.ToInt32(jwtSettings.Value.ExpiryInDays);
            JwtSecurityToken token;
            switch (role)
            {
                case "RaspberryPi":
                    token = new JwtSecurityToken(
                                issuer: jwtSettings.Value.Site,
                                audience: jwtSettings.Value.Site,
                                claims: claims,
                                signingCredentials: new SigningCredentials(signinKey, SecurityAlgorithms.HmacSha256));
                    break;

                case "Admin":
                case "User":
                default:
                    token = new JwtSecurityToken(
                                issuer: jwtSettings.Value.Site,
                                audience: jwtSettings.Value.Site,
                                claims: claims,
                                expires: DateTime.Now.AddDays(expiryInDays),
                                signingCredentials: new SigningCredentials(signinKey, SecurityAlgorithms.HmacSha256));
                    break;
            }

            return new OkObjectResult(new { token = new JwtSecurityTokenHandler().WriteToken(token), expiration = token.ValidTo });
        }

        private async Task<List<Claim>> BuildClaims(IdentityUser user, string role)
        {
            List <Claim> claims = new List<Claim>();
            claims.Add(new Claim(JwtRegisteredClaimNames.Sub, user.UserName));
            claims.Add(new Claim("http://schemas.microsoft.com/ws/2008/06/identity/claims/role", role));
            
            var userclaims = await userManager.GetClaimsAsync(user);
            foreach (var claim in userclaims)
            {
                claims.Add(claim);
            }

            return claims;
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

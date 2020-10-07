using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OpenMyGarage.Domain.Service;
using OpenMyGarage.Domain.ViewModel;

namespace OpenMyGarage.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationServiceAsync authenticationService;

        public AuthenticationController(IAuthenticationServiceAsync service)
        {
            this.authenticationService = service;
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        [Route("register")]
        public async Task<ActionResult> Register([FromBody] RegisterViewModel newUser)
        {
            return await authenticationService.RegisterUser(newUser);
        }

        [HttpPost]
        [Route("login")]
        public async Task<ActionResult> Login([FromBody] LoginViewModel user)
        {
            return await authenticationService.LoginUser(user);
        }
    }
}

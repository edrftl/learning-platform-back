﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using learning_platform_back.Models;
using learning_platform_back.Services;

namespace learning_platform_back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountsService accountsService;

        public AccountsController(IAccountsService accountsService)
        {
            this.accountsService = accountsService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterModel model)
        {
            await accountsService.Register(model);
            return Ok();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            await accountsService.Login(model);
            // to return 
            return Ok();
            //return Ok(await accountsService.Login(model));
        }

        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            await accountsService.Logout();
            return Ok();
        }
       
    }
}

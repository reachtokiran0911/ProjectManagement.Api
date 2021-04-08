﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectManagement.Data.Interfaces;
using ProjectManagement.Entities;
using ProjectManagement.Shared;
using System.Collections.Generic;
using System.Linq;

namespace ProjectManagement.Api.Controllers
{
    [ApiController]
    [Route("api/User")]
    public class UserController : BaseController<User>
    {
        private readonly IUserRepository _userRepository;
        public UserController(IUserRepository userRepository) : base(userRepository)
        {
            _userRepository = userRepository;
        }
        [HttpPost]
        [Route("Login")]
        public ActionResult Login([FromBody] User user)
        {
            var result = _userRepository.Login(user);
            if (result != null)
                return Ok(result);
            else
                return StatusCode(500);
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectManagement.Entities;
using ProjectManagement.Shared;
using System.Collections.Generic;
using System.Linq;

namespace ProjectManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : BaseController<User>
    {
        private PMContext _context;
        public UserController(PMContext projectContext)
        {
            _context = projectContext;
        }

        protected override User GetDataById(long id)
        {
            var data = _context.Users.Find(id);
            if (data != null)
            {
                return data;
            }
            return null;
        }

        protected override IEnumerable<User> GetData()
        {
            return _context.Users.ToList();
        }

        protected override IActionResult UpdateData(User user)
        {
            try
            {
                _context.Users.Update(user);
                _context.SaveChanges();
                return Ok(user);
            }
            catch (DbUpdateConcurrencyException)
            {
                return BadRequest("record not exists");
            }
        }

        protected override bool DeleteData(long id)
        {
            var itemToDelete = _context.Users.Find(id);
            if (itemToDelete != null)
            {
                _context.Users.Remove(itemToDelete);
                _context.SaveChanges();

                return true;
            }

            return false;
        }

        protected override IActionResult AddData(User user)
        {
            var currentTask = _context.Users.Find(user.ID);
            if (currentTask == null)
            {
                _context.Users.Add(user);
                _context.SaveChanges();
                return Ok(user);
            }

            return BadRequest("user already exists");
        }

        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody]AuthenticateModel model)
        {
            // var user = _userService.Authenticate(model.Username, model.Password);

            //if (user == null)
            //    return BadRequest(new { message = "Username or password is incorrect" });

            // return basic user info
            //return Ok(new
            //{
            //    Id = user.Id,
            //    Username = user.Username,
            //    FirstName = user.FirstName,
            //    LastName = user.LastName,
            //});

            return Ok("User authenticated successfully !!");
        }


    }

}

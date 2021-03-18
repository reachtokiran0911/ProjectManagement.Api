using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectManagement.Shared;
using System.Collections.Generic;
using System.Linq;
using Task = ProjectManagement.Entities.Task;

namespace ProjectManagement.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TaskController : BaseController<Task>
    {
        private PMContext _context;
        public TaskController(PMContext projectContext)
        {
            _context = projectContext;
        }

        protected override Task GetDataById(long id)
        {
            var data = _context.Tasks.Find(id);
            if (data != null)
            {
                return data;
            }
            return null;
        }

        protected override IEnumerable<Task> GetData()
        {
            return _context.Tasks.ToList();
        }

        protected override IActionResult UpdateData(Task task)
        {
            try
            {
                _context.Tasks.Update(task);
                _context.SaveChanges();
                return Ok(task);
            }
            catch (DbUpdateConcurrencyException)
            {
                return BadRequest("record not exists");
            }
        }

        protected override bool DeleteData(long id)
        {
            var itemToDelete = _context.Tasks.Find(id);
            if (itemToDelete != null)
            {
                _context.Tasks.Remove(itemToDelete);
                _context.SaveChanges();

                return true;
            }

            return false;
        }

        protected override IActionResult AddData(Task task)
        {
            var currentTask = _context.Tasks.Find(task.ID);
            if (currentTask == null)
            {
                _context.Tasks.Add(task);
                _context.SaveChanges();
                return Ok(task);
            }

            return BadRequest("Task already exists");
        }
    }
}

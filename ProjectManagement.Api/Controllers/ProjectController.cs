using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectManagement.Entities;
using ProjectManagement.Shared;
using System.Collections.Generic;
using System.Linq;

namespace ProjectManagement.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProjectController : BaseController<Project>
    {
        private PMContext _context;
        public ProjectController(PMContext projectContext)
        {
            _context = projectContext;
        }
        //public ProjectController(Sprint1TestStorage<Project> storage) : base(storage)
        //{
        //}
        protected override Project GetDataById(long id)
        {
            var data = _context.Projects.Find(id);
            if (data != null)
            {
                return data;
            }
            return null;
        }

        protected override IEnumerable<Project> GetData()
        {
            return _context.Projects.ToList();
        }

        protected override IActionResult UpdateData(Project project)
        {
            try
            {
                _context.Projects.Update(project);
                _context.SaveChanges();
                return Ok(project);
            }
            catch (DbUpdateConcurrencyException)
            {
                return BadRequest("record not exists");
            }
        }

        protected override bool DeleteData(long id)
        {
            var itemToDelete = _context.Projects.Find(id);
            if (itemToDelete != null)
            {
                _context.Projects.Remove(itemToDelete);
                _context.SaveChanges();

                return true;
            }

            return false;
        }

        protected override IActionResult AddData(Project project)
        {
            var currentProject = _context.Projects.Find(project.ID);
            if (currentProject == null)
            {
                _context.Projects.Add(project);
                _context.SaveChanges();
                return Ok(project);
            }

            return BadRequest("Project already exists");
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using ProjectManagement.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectManagement.Data.Implementation;

namespace ProjectManagement.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProjectController : BaseController<Project>
    {
        public ProjectController(Sprint1TestStorage<Project> storage) : base(storage)
        {
        }
    }
}

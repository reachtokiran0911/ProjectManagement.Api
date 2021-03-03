using Microsoft.AspNetCore.Mvc;
using ProjectManagement.Data.Implementation;
using ProjectManagement.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task = ProjectManagement.Entities.Task;

namespace ProjectManagement.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TaskController : BaseController<Task>
    {
        public TaskController(Sprint1TestStorage<Task> storage) : base(storage)
        {
        }
    }
}

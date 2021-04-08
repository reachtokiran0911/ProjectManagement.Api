using Microsoft.AspNetCore.Mvc;
using ProjectManagement.Data.Interfaces;
using Tasks = ProjectManagement.Entities.Tasks;

namespace ProjectManagement.Api.Controllers
{
    [ApiController]
    [Route("api/Task")]
    public class TaskController : BaseController<Tasks>
    {
        public TaskController(IBaseRepository<Tasks> baseRepository) : base(baseRepository)
        {

        }
    }
}

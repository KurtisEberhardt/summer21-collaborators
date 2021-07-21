using System.Threading.Tasks;
using collaborators.Models;
using collaborators.Services;
using Microsoft.AspNetCore.Mvc;

namespace collaborators.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProjectController : ControllerBase
    {
        private readonly ProjectService _service;

        public ProjectController(ProjectService service)
        {
            _service = service;
        }

        [HttpGet("{id}")]
        public ActionResult<Project> getById(int id){
            try
            {
                return Ok(_service.getById(id));
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPost]
        public ActionResult<Project> Create([FromBody] Project newProject){
            try
            {
                Project created = _service.Create(newProject);
                return Ok(created);
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
using collaborators.Models;
using collaborators.Services;
using Microsoft.AspNetCore.Mvc;

namespace collaborators.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProjectProfileController : ControllerBase
    {
        private readonly ProfileProjectService _service;

        public ProjectProfileController(ProfileProjectService service)
        {
            _service = service;
        }

        [HttpPost]
        public ActionResult<ProfileProject> createProfileProject([FromBody] ProfileProject newProfProj){
            try
            {
                return Ok(_service.Create(newProfProj));
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpGet("{id}")]
        public ActionResult<ProfileProject> getById(int id){
            try
            {
                return Ok(_service.getById(id));
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
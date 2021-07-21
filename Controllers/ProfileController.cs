using System.Threading.Tasks;
using collaborators.Models;
using collaborators.Services;
using Microsoft.AspNetCore.Mvc;

namespace collaborators.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfileController : ControllerBase
    {
        private readonly ProfileService _pservice;

        public ProfileController(ProfileService pservice)
        {
            _pservice = pservice;
        }
    [HttpPost]
    public ActionResult<Profile> Create([FromBody] Profile newProfile){
        try
        {
            return Ok(_pservice.Create(newProfile));
        }
        catch (System.Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    [HttpGet("{id}")]
    public ActionResult<Profile> getById(int id){
        try
        {
            return Ok(_pservice.getById(id));
        }
        catch (System.Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}
}
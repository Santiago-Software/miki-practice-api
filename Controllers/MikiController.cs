using Microsoft.AspNetCore.Mvc;
using miki_practice_api.Services;
using miki_practice_api.Models;

namespace miki_practice_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MikiController : ControllerBase
    {
        private readonly MikiService mikiService; //DI for my service
        public MikiController(MikiService mikiService) //constructor for DI
        {
            this.mikiService = mikiService; //Assign the injected service to the private field.
        }

        // GET: api/Miki
        [HttpGet]
        public IActionResult GetAllData()
        {
            var data = mikiService.GetAll();
            return Ok(data);// Returns the data as JSON with a 200 OK status.
        }

    }
}

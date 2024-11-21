using Microsoft.AspNetCore.Mvc;
using Miki.Services;
using Miki.Models;

namespace miki_practice_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MikiController : ControllerBase
    {
        private readonly MikiService mikiService; //DI for my service
        public MikiController(MikiService mikiService) //constructor for DI
        {
            this.mikiService = mikiService;
        }
    }
}

using Microsoft.AspNetCore.Mvc;

namespace webAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : ControllerBase
    {
        [HttpGet]
        public string Get()
        {
          
            return "Test Result";
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using webAPI.Interface;
using webAPI.Parameters;

namespace webAPI.Controllers
{


    [ApiController]
    [Route("[controller]")]
    public class GameController: ControllerBase
    {
        private readonly IGameService _gameController;

        public GameController(IGameService gameService)
        {
            _gameController = gameService;
        }

        [HttpPost]
        public IActionResult Post([FromBody] RequestParamters request)
        {
            return new OkObjectResult(_gameController.CreateAsync(request));
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using webAPI.Interface;
using webAPI.Parameters;

namespace webAPI.Controllers
{


    [ApiController]
    [Route("[controller]")]
    public class GameController : ControllerBase
    {
        private readonly IGameService _gameController;

        public GameController(IGameService gameService)
        {
            _gameController = gameService;
        }

        [HttpGet("{number}/{switchNeeded}")]
        public string Get(int number, string switchNeeded)
        {
            RequestParamters requestParamters = new RequestParamters
            {
                wantSwitch = switchNeeded,
                numberOfGames = number
            };
            return _gameController.GetResultAsync(requestParamters);
        }
    }
}

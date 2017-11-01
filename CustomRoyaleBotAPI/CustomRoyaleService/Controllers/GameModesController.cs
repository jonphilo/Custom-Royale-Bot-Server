using CustomRoyaleService.Models;
using CustomRoyaleService.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace CustomRoyaleService.Controllers
{
    public class GameModesController : ApiController
    {
        private readonly IGameModeService _gameModeService;

        public GameModesController()
        {
            _gameModeService = new GameModeService();
        }

        public GameModesController(IGameModeService gameModeService)
        {
            _gameModeService = gameModeService;
        }

        [Route("api/gamemodes")]
        [HttpGet]
        public IHttpActionResult GetAllGameModes()
        {
            return Ok(_gameModeService.GetAll());
        }

        [Route("api/gamemodes/random")]
        [HttpGet]
        public IHttpActionResult GetRandomGameMode()
        {
            return Ok(_gameModeService.GetRandom());
        }

        [Route("api/gamemodes")]
        [HttpPost]
        public IHttpActionResult RegisterGameMode([FromBody] GameMode mode)
        {
            try
            {
                _gameModeService.Register(mode);
                return Ok();
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }

        }
    }
}

using Microsoft.AspNetCore.Mvc;
using TowerOfHanoi.Logic;

namespace TowerOfHanoi.Host
{
    [ApiController]
    public class GameController : ControllerBase
    {
        [HttpGet]
        [Route("api/solveTowerOfHanoi/numberOfDisks/{numberOfDisks}")]
        public ActionResult<GameState> SolveTowerOfHanoi(int numberOfDisks)
        {
            return Ok(TowerOfHanoiLogic.SolveTowerOfHanoi(numberOfDisks));
        }
    }
}
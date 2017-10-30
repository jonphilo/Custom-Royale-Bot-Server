using CustomRoyaleService.Data;
using CustomRoyaleService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomRoyaleService.Services
{
    public class GameModeService : IGameModeService
    {
        public IEnumerable<GameMode> GetAll()
        {
            using (var ctx = new CustomRoyaleContext())
            {
                return ctx.GameModes as IEnumerable<GameMode>;
            }
        }

        public GameMode GetRandom()
        {
            using (var ctx = new CustomRoyaleContext())
            {
                int totalGameModes = ctx.GameModes.Count();
                Random random = new Random();
                int index = random.Next(0, totalGameModes - 1);
                return ctx.GameModes.ElementAt(index);
            }
        }

        public void Register(GameMode gameMode)
        {
            using (var ctx = new CustomRoyaleContext())
            {
                ctx.GameModes.Add(gameMode);
                ctx.SaveChanges();
            }
        }
    }
}

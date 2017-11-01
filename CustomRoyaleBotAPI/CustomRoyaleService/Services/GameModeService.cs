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
                return ctx.GameModes.ToList();
            }
        }

        public GameMode GetRandom()
        {
            using (var ctx = new CustomRoyaleContext())
            {
                int totalGameModes = ctx.GameModes.Count();
                if (totalGameModes == 0)
                {
                    return null;
                }
                Random random = new Random();
                int index = random.Next(0, totalGameModes);
                return ctx.GameModes.ToList()[index];
            }
        }

        public void Register(GameMode gameMode)
        {
            using (var ctx = new CustomRoyaleContext())
            {
                if (ctx.GameModes.Where(gm => gm.Name.Equals(gameMode.Name)).Any())
                {
                    throw new ArgumentException("Duplicate Game Mode");
                }
                ctx.GameModes.Add(gameMode);
                ctx.SaveChanges();
            }
        }
    }
}

using CustomRoyaleService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomRoyaleService.Services
{
    public interface IGameModeService
    {
        void Register(GameMode mode);
        IEnumerable<GameMode> GetAll();
        GameMode GetRandom();
    }
}

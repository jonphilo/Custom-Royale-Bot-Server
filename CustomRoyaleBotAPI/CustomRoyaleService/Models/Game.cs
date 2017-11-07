using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomRoyaleService.Models
{
    public class Game
    {
        [Key]
        public long GameId { get; set; }
        public DateTime TimeStamp { get; set; }
        public bool IsComplete { get; set; }

        public virtual ICollection<GameMode> GameModes { get; set; } = new HashSet<GameMode>();
    }
}

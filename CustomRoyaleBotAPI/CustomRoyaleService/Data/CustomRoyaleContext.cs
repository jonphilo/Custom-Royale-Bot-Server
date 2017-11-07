using CustomRoyaleService.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomRoyaleService.Data
{
    public class CustomRoyaleContext : DbContext
    {
        public DbSet<Game> Games { get; set; }
        public DbSet<GameMode> GameModes { get; set; }
    }
}

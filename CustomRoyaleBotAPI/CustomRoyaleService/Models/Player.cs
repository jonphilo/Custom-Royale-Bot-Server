using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomRoyaleService.Models
{
    public class Player
    {
        [Key]
        public long PlayerId { get; set; }
        public string PlayerName { get; set; } 
    }
}

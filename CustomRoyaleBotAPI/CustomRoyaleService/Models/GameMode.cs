using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomRoyaleService.Models
{
    public class GameMode
    {
        [Key]
        public long GameModeId { get; set; }
        [StringLength(50), Required]
        public string Name { get; set; }
        [StringLength(256), Required]
        public string Description { get; set; }
        [StringLength(50)]
        public string Submitter { get; set; }
    }
}

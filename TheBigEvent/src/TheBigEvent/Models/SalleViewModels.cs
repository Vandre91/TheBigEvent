using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheBigEvent.Models
{
    public class SalleViewModels
    {
        public int SalleId { get; set; }
        public int NbPlace { get; set; }
        public int UserId { get; set; }
        public string Description { get; set; }
        public float Prix { get; set; }
        public string Nom { get; set; }
    }
}

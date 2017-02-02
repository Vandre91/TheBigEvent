using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheBigEvent.Models
{
    public class InviteViewModels
    {
        public int InviteId { get; set; }
        public int BigSelecteId { get; set; }
        public string Nom { get; set; }
        public string Mail { get; set; }
        public string Code { get; set; }
        public int dateid { get; set; }
        public int Etat { get; set; }
    }
}

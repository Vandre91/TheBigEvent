using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheBigEvent.DAL
{
    public class Traiteur
    {
        public int TraiteurId { get; set; }
        public int UserId { get; set; }
        public string City { get; set; }
        public string Compagny { get; set; }
        public string Nom { get; set; }
        public string Descriptions { get; set; }
    }
}

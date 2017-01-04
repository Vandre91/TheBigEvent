using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheBigEvent.DAL
{
    public class Menu
    {
        public int MenuId { get; set; }
        public string Nom { get; set; }
        public string Cat { get; set; }
        public int Prix { get; set; }
        public int NbPersonnes { get; set; }
        public int TraiteurId { get; set; }
    }
}

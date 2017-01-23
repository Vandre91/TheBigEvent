using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheBigEvent.Models
{
    public class MenuViewModels
    {
        public int MenuId { get; set; }
        public string Nom { get; set; }
        public string Cat { get; set; }
        public int Prix { get; set; }
        public int NbPersonnes { get; set; }
        public int TraiteurId { get; set; }
        public string Compagny { get; set; }
    }
}

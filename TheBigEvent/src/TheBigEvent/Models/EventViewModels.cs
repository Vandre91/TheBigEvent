using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheBigEvent.Models
{
    public class EventViewModels
    {
        public int EventId { get; set; }
        public string NomEvent { get; set; }
        public int NbInvite { get; set; }
        public int Prix { get; set; }
        public DateTime Dates { get; set; }
        public int MenuId { get; set; }
        public int SalleId { get; set; }
        public int TraiteurId { get; set; }
        public int DecoId { get; set; }
        public string Localisation { get; set; }
        public int UserId { get; set; }
        public int value { get; set; }
    }
}

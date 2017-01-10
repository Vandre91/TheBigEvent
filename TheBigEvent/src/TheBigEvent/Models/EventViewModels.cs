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
        public string NbInvite { get; set; }
        public string Prix { get; set; }
        public string Horaire { get; set; }
        public int MenuId { get; set; }
        public int SalleId { get; set; }
        public int TraiteurId { get; set; }
        public int DecoId { get; set; }
        public string Localisation { get; set; }
        public int UserId { get; set; }
    }
}

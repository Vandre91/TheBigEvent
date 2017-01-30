using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheBigEvent.DAL
{
    public class Event
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
        public string LastName { get; set; }
        public byte ValidationT { get; set; }
        public byte ValidationS { get; set; }
        public byte ValidationD { get; set; }
        public int existPS { get; set; }
        public int existPD { get; set; }
        public int existPT { get; set; }
    }
}
